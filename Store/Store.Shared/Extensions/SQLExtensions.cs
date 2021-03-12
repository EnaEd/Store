using System;
using System.Linq;
using System.Linq.Expressions;

namespace Store.Shared.Extensions
{
    public static class SQLExtensions
    {
        public static IQueryable<T> OrderByExtension<T>(this IQueryable<T> source, string field, bool direction)
        {
            string command = direction ? Constants.Constant.Common.ORDER_DESC : Constants.Constant.Common.ORDER_ASC;
            var type = typeof(T);
            var property = type.GetProperty(field ?? type.GetProperties().First().ToString()) ?? type.GetProperties().First();
            var parameter = Expression.Parameter(type, Constants.Constant.Common.NAME_DECLARING_VARIABLE);
            var propertyAccess = Expression.MakeMemberAccess(parameter, property);
            var orderByExpression = Expression.Lambda(propertyAccess, parameter);
            var resultExpression = Expression.Call(typeof(Queryable), command, new Type[] { type, property.PropertyType },
                                          source.Expression, Expression.Quote(orderByExpression));
            return source.Provider.CreateQuery<T>(resultExpression);
        }
    }
}
