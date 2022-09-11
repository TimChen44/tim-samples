using System.Linq;
using System.Linq.Expressions;

namespace LinqExpressions
{
    public static class ListWhere
    {
        public static IQueryable<TSource> DtoWhere<TSource, TDto>(this IQueryable<TSource> source, TDto dto)
        {
            var sProps = typeof(TSource).GetProperties();
            var dProps = typeof(TDto).GetProperties();

            var dtoProps = dProps.Where(x => x.PropertyType.FullName == "System.String" && sProps.Any(y => y.Name == x.Name));

            foreach (var dtoProp in dtoProps)
            {
                var value = dtoProp.GetValue(dto).ToString();

                if (!string.IsNullOrEmpty(value))
                {
                    var func = WhereFunc<TSource>(dtoProp.Name, value);
                    source = source.Where(func);
                }
            }
            return source;
        }

        public static Expression<Func<TSource, bool>> WhereFunc<TSource>(string propName, string value)
        {
            ParameterExpression entityPar = Expression.Parameter(typeof(TSource), "x");
            var entityParT1 = Expression.Property(entityPar, propName);
            //entityParT1: x.T1

            ConstantExpression dtoValue = Expression.Constant(value);
            MethodCallExpression containsExp = Expression.Call(entityParT1, typeof(string).GetMethod("Contains", new Type[] { typeof(string) }), dtoValue);
            //containsExp: x.T1.Contains(value)

            var whereLambda = Expression.Lambda<Func<TSource, bool>>(containsExp, entityPar);
            //whereLambda: x => x.T1.Contains(value)

            return whereLambda;
        }
    }
}
