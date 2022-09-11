using CC.CodeGenerator;
using LinqExpressions.Entity;
using Microsoft.AspNetCore.Mvc;

namespace LinqExpressions.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    [AutoInject(typeof(DemoContext), "Context")]
    public partial class DemoController : ControllerBase
    {
        [HttpPost]
        public List<Table1> Search(Table1QueryDto queryDto)
        {
            var query = (IQueryable<Table1>)Context.Table1;

            //#region 查询

            //if (!string.IsNullOrEmpty(queryDto.T1)) query = query.Where(x => x.T1.Contains(queryDto.T1));
            //if (!string.IsNullOrEmpty(queryDto.T2)) query = query.Where(x => x.T2.Contains(queryDto.T2));
            //if (!string.IsNullOrEmpty(queryDto.T3)) query = query.Where(x => x.T3.Contains(queryDto.T3));
            ///* 此处省略 N~ 行相似代码 😖*/
            //if (!string.IsNullOrEmpty(queryDto.T4)) query = query.Where(x => x.T4.Contains(queryDto.T4));

            //#endregion

            //#region 查询初级改进

            //query = query.IfWhere(queryDto.T1, x => x.T1.Contains(queryDto.T1))
            //    .IfWhere(queryDto.T2, x => x.T1.Contains(queryDto.T2))
            //    .IfWhere(queryDto.T3, x => x.T1.Contains(queryDto.T3))
            //    /* 此处省略 N~ 行相似代码 😖*/
            //    .IfWhere(queryDto.T4, x => x.T1.Contains(queryDto.T4));

            //#endregion

            #region 查询终极

            query = query.DtoWhere(queryDto);

            #endregion

            return query.ToList();
        }

        public class Table1QueryDto
        {
            public string T1 { get; set; }
            public string T2 { get; set; }
            public string T3 { get; set; }
            public string T4 { get; set; }
        }
    }


}