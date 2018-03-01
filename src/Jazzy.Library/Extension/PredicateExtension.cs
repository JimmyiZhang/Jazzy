using System;
using System.Linq.Expressions;

namespace Jazzy.Library
{
    public static class PredicateExtension
    {
        public static Expression<Func<T, bool>> True<T>() { return exp => true; }
        public static Expression<Func<T, bool>> False<T>() { return exp => false; }

        /// <summary>
        /// Or表达式
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expression1">表达式1</param>
        /// <param name="expression2">表达式2</param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> expression1, Expression<Func<T, bool>> expression2)
        {
            var ie = Expression.Invoke(expression2, expression1.Parameters);
            return Expression.Lambda<Func<T, bool>>(Expression.Or(expression1.Body, ie), expression1.Parameters);
        }

        /// <summary>
        /// And表达式
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expression1">表达式1</param>
        /// <param name="expression2">表达式2</param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> expression1, Expression<Func<T, bool>> expression2)
        {
            var ie = Expression.Invoke(expression2, expression1.Parameters);
            return Expression.Lambda<Func<T, bool>>(Expression.And(expression1.Body, ie), expression1.Parameters);
        }
    }
}
