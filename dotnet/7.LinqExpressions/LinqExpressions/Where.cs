using System.Linq.Expressions;

namespace LinqExpressions
{
    public static class Where
    {
        public static IQueryable<TSource> IfWhere<TSource>(this IQueryable<TSource> source, string value, Expression<Func<TSource, bool>> predicate)
        {
            if (string.IsNullOrEmpty(value))
                return source;
            else
                return source.Where(predicate);
        }
    }
}
