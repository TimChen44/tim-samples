﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CCP.Web
{
    public static class BuildWebApiToTS
    {
        public static string Build(Assembly assembly, string prefix = "api/")
        {
            List<Controller> controllers = GetApis(assembly);
            string code = CreateCode(controllers);
            return code.ToString();
        }


        public static void BuildToFile(Assembly assembly, string path, string prefix = "api/")
        {
            var code = Build(assembly, prefix);
            string existsCode = "";
            if (System.IO.File.Exists(path) == true)
                existsCode = System.IO.File.ReadAllText(path);

            if (existsCode != code)
            {
                System.IO.File.WriteAllText(path, code);
            }
        }

        #region 构造代码

        public static string CreateCode(List<Controller> controllers, string prefix = "api/")
        {
            StringBuilder code = new StringBuilder();
            code.AppendLine("export const WebAPI = {");

            foreach (var coll in controllers.OrderBy(x => x.Name))
            {
                code.AppendLine($"  /** {coll.ApiComments?.Title} */");
                code.AppendLine($"  {coll.Name}: {{");
                code.AppendLine($"    Controller: `{prefix}{coll.Name}`,");
                foreach (var action in coll.Actions.OrderBy(x => x.Name))
                {
                    code.AppendLine($"    /** {action.Type} {action.ApiComments?.Title} */");
                    code.AppendLine($"    {action.Name}: `{prefix}{coll.Name}/{action.Name}`,");
                }
                code.AppendLine($"  }},");
            }

            code.AppendLine($"}};");
            return code.ToString();
        }

        #endregion

        #region 获得接口清单

        public static List<Controller> GetApis(Assembly assembly)
        {
            List<Controller> controllers = new List<Controller>();

            var collTypes = assembly.GetTypes().Where(x => x.GetCustomAttributes(typeof(ApiControllerAttribute), false).Count() > 0);
            foreach (var collType in collTypes)
            {
                var controller = new Controller(collType.Name.Replace("Controller", ""));
                controller.ApiComments = collType.GetCustomAttribute<ApiCommentsAttribute>();
                controllers.Add(controller);

                controller.Actions.AddRange(GetTypeMembers(collType, typeof(HttpGetAttribute), "GET"));
                controller.Actions.AddRange(GetTypeMembers(collType, typeof(HttpPostAttribute), "POST"));
                controller.Actions.AddRange(GetTypeMembers(collType, typeof(HttpPutAttribute), "PUT"));
                controller.Actions.AddRange(GetTypeMembers(collType, typeof(HttpDeleteAttribute), "DELETE"));
            }

            return controllers;
        }
        private static List<Action> GetTypeMembers(Type type, Type whereType, string saveType)
        {
            var actonTypes = type.GetMembers().Where(x => x.GetCustomAttributes(whereType, false).Count() > 0);

            List<Action> actons = new List<Action>();
            foreach (var actonType in actonTypes)
            {
                var action = new Action(saveType, actonType.Name);
                action.ApiComments = actonType.GetCustomAttribute<ApiCommentsAttribute>();
                actons.Add(action);
            }

            return actons;
        }

        public record Controller(string Name)
        {
            public ApiCommentsAttribute ApiComments { get; set; }
            public List<Action> Actions { get; set; } = new List<Action>();
        }

        public record Action(string Type, string Name)
        {
            public ApiCommentsAttribute ApiComments { get; set; }
        }

        #endregion


    }

    public class ApiCommentsAttribute : Attribute
    {
        public string Title { get; set; }
        public ApiCommentsAttribute(string title)
        {
            Title = title;
        }
    }
}

