using BatchDemo.Models;
using Microsoft.EntityFrameworkCore;

#region 批量更新

//EFDemoContext context = new EFDemoContext();

//context.Company
//    .Where(x => x.Title=="超超")
//    .ExecuteUpdate(x => x.SetProperty(f => f.ModifyTime, f => DateTime.Now)
//                         .SetProperty(f => f.ModifyUser, f => "Tim"));

//var localCount = context.Company.Local.Count();

//Console.ReadLine();

#endregion

#region 批量删除

EFDemoContext context = new EFDemoContext();

context.Company.Where(x => x.Title.StartsWith("超")).ExecuteDelete();

#endregion

