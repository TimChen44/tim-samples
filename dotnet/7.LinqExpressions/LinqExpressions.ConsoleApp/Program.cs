using LinqExpressions.Entity;
using System.Linq.Expressions;

// x => (x.A == True)

ParameterExpression demo = Expression.Parameter(typeof(Demo), "x");
Console.WriteLine(demo);// x

var demo_A = Expression.Property(demo, "A");
Console.WriteLine(demo_A);// x.A

ConstantExpression value = Expression.Constant(true);
Console.WriteLine(value);// true

BinaryExpression greaterThan= Expression.Equal(demo_A, value);
Console.WriteLine(greaterThan);// (x.A == True)

var lambda = Expression.Lambda<Func<Demo, bool>>(greaterThan, demo);
Console.WriteLine(lambda); // x => (x.A == True)

var lambdaFunc = lambda.Compile();
Console.WriteLine(lambdaFunc);// System.Func`2[Demo,System.Boolean]

var resultTrue = lambdaFunc(new Demo() { A = true });
Console.WriteLine(resultTrue);// True

var resultFalse = lambdaFunc(new Demo() { A = false });
Console.WriteLine(resultFalse);// False

Console.ReadLine();

class Demo
{
    public bool A { get; set; }
}