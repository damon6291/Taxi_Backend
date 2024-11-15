﻿using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Metadata;
using Taxi_Backend.Models;

namespace Taxi_Backend.Helper
{
    public static class ExpressionBuilder
    {
        private static MethodInfo startsWithMethod = typeof(string).GetMethod("StartsWith", new Type[] { typeof(string) });
        private static MethodInfo endsWithMethod = typeof(string).GetMethod("EndsWith", new Type[] { typeof(string) });


        public static Expression<Func<T, bool>> GetExpression<T>(IList<Filter> filters)
        {
            if (filters.Count == 0)
                return null;

            ParameterExpression param = Expression.Parameter(typeof(T), "t");
            Expression exp = null;

            if (filters.Count == 1)
                exp = GetExpression<T>(param, filters[0]);
            else if (filters.Count == 2)
                exp = GetExpression<T>(param, filters[0], filters[1]);
            else
            {
                while (filters.Count > 0)
                {
                    var f1 = filters[0];
                    var f2 = filters[1];

                    if (exp == null)
                        exp = GetExpression<T>(param, filters[0], filters[1]);
                    else
                        exp = Expression.AndAlso(exp, GetExpression<T>(param, filters[0], filters[1]));

                    filters.Remove(f1);
                    filters.Remove(f2);

                    if (filters.Count == 1)
                    {
                        exp = Expression.AndAlso(exp, GetExpression<T>(param, filters[0]));
                        filters.RemoveAt(0);
                    }
                }
            }

            return Expression.Lambda<Func<T, bool>>(exp, param);
        }

        private static Expression GetExpression<T>(ParameterExpression param, Filter filter)
        {
            MemberExpression member;
            ConstantExpression constant = Expression.Constant(filter.Value);

            List<Expression> expressions = new List<Expression>();
            try
            {
                switch (filter.Operation)
            {
                case Op.Equals:
                    foreach(var prop in filter.PropertyName)
                    {
                        member = Expression.Property(param, prop);
                        expressions.Add(Expression.Equal(member, constant));
                    }
                    break;

                //case Op.GreaterThan:
                //    return Expression.GreaterThan(member, constant);

                //case Op.GreaterThanOrEqual:
                //    return Expression.GreaterThanOrEqual(member, constant);

                //case Op.LessThan:
                //    return Expression.LessThan(member, constant);

                //case Op.LessThanOrEqual:
                //    return Expression.LessThanOrEqual(member, constant);

                case Op.Contains:
                    foreach (var prop in filter.PropertyName)
                    {
                        member = Expression.Property(param, prop);
                        var callEx = Expression.Call(member, typeof(string).GetMethod("IndexOf", new[] { typeof(string), typeof(StringComparison) }), Expression.Constant(filter.Value), Expression.Constant(StringComparison.OrdinalIgnoreCase));
                        expressions.Add(Expression.NotEqual(callEx, Expression.Constant(-1)));
                    }
                    break;

                    //case Op.StartsWith:
                    //    return Expression.Call(member, startsWithMethod, constant);

                    //case Op.EndsWith:
                    //    return Expression.Call(member, endsWithMethod, constant);
            }

            Expression ret = expressions[0];
            
                for (var i = 1; i < expressions.Count; i++)
                {
                    ret = Expression.Or(ret, expressions[i]);
                }
                return ret;
            }

            catch(Exception ex)
            {
                Console.WriteLine($"Error : {ex.Message}");
            }
       
            return null;
            

        }

        private static BinaryExpression GetExpression<T>(ParameterExpression param, Filter filter1, Filter filter2)
        {
            Expression bin1 = GetExpression<T>(param, filter1);
            Expression bin2 = GetExpression<T>(param, filter2);

            return Expression.AndAlso(bin1, bin2);
        }

        public static IQueryable<T> OrderBy<T>(this IQueryable<T> source, string orderByProperty,
                          bool isAscending)
        {
            string command = isAscending ? "OrderBy" : "OrderByDescending";
            var type = typeof(T);
            var property = type.GetProperty(orderByProperty);
            var parameter = Expression.Parameter(type, "p");
            var propertyAccess = Expression.MakeMemberAccess(parameter, property);
            var orderByExpression = Expression.Lambda(propertyAccess, parameter);
            var resultExpression = Expression.Call(typeof(Queryable), command, new Type[] { type, property.PropertyType },
                                          source.Expression, Expression.Quote(orderByExpression));
            return source.Provider.CreateQuery<T>(resultExpression);
        }
    }
}
