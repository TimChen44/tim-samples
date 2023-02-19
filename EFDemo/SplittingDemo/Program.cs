using SplittingDemo.Models;

#region 新建

//EFDemoContext context = new EFDemoContext();

//var customers = new Customers()
//{
//    CustomersId = Guid.NewGuid(),
//    Name = "超超",
//    PhoneNumber = "137***",
//    City = "上海",
//};

//context.Add(customers);

//context.SaveChanges();

#endregion

#region 编辑

//EFDemoContext context = new EFDemoContext();
//var cust = context.Customers.Where(x => x.Name == "超超").FirstOrDefault();
//cust.Name = "超超_UP";

//context.SaveChanges();

#endregion

#region 删除

EFDemoContext context = new EFDemoContext();

var cust = context.Customers.Where(x => x.Name == "超超_UP").FirstOrDefault();
context.Remove(cust);

context.SaveChanges();

#endregion


