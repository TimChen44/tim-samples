//var person = new Person();
////这里好像忘写什么了

//var name = person.Name?.ToUpper();

//public class Person
//{
//    public Person() { }
//    public string Name { get; set; }
//    public int? Age { get; set; }
//}


//var person = new Person() { Name = "CC" };

//public class Person
//{
//    public Person() { }
//    public required string Name { get; set; }
//    public int? Age { get; set; }
//}

using System.Diagnostics.CodeAnalysis;

var person = new Person("超超");

public class Person
{
    [SetsRequiredMembers]
    //指定此构造函数为当前类型设置所有必需成员，
    //调用方不需要自己设置任何必需成员。
    public Person(string name)
    {
        Name = name;

    }
    public required string Name { get; set; }
    public required string Name2 { get; set; }
    public int? Age { get; set; }
}

//Docs：https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/keywords/required?WT.mc_id=DT-MVP-5004310
