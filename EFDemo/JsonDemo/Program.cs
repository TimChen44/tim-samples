using EFDemo.Models;
using Microsoft.EntityFrameworkCore;

#region 新增

//EFDemoContext context = new EFDemoContext();

//User user = new User()
//{
//    UserId = Guid.NewGuid(),
//    Name = "超超",
//    Address = new Address()
//    {
//        City = "上海",
//        Details = "保密",
//    }
//};

//context.Add(user);

//var result = context.SaveChanges();

#endregion

#region 检索&编辑

//EFDemoContext context = new EFDemoContext();

//var user = context.User.Where(x => x.Address.City == "上海").First();

//user.Address.City = "北京";

//context.SaveChanges();

#endregion

#region 设置为Null

//EFDemoContext context = new EFDemoContext();

//var user1 = context.User.Where(x => x.Address.City == "北京").FirstOrDefault();

//user1.Address = null;

//context.SaveChanges();

#endregion

#region 空对象查询

//EFDemoContext context = new EFDemoContext();

//var user2 = context.User.Where(x => x.Address.City == "ABC").FirstOrDefault();



#endregion

#region 新增

//EFDemoContext context = new EFDemoContext();

//User user = new User()
//{
//    UserId = Guid.NewGuid(),
//    Name = "超超",
//    Address = new Address()
//    {
//        City = "上海",
//        Details = "保密",
//        Phone = new List<Phone>()
//        {
//            new Phone() {Number="137***"}
//        }
//    }
//};

//context.Add(user);

//var result = context.SaveChanges();

#endregion

#region 检索&编辑

//EFDemoContext context = new EFDemoContext();

//var user = context.User.Where(x => x.Address.City == "上海").First();

//user.Address.Phone.Add(new Phone { Number = "138***" });

//context.SaveChanges();

#endregion

#region 删除

EFDemoContext context = new EFDemoContext();

var user = context.User.Where(x => x.Address.City == "上海").First();

user.Address.Phone.Clear();

context.SaveChanges();

#endregion

Console.WriteLine("OK✌️");
