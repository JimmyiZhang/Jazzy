using System;
using System.Collections.Generic;

namespace Jazzy.Library
{
    /// <summary>
    /// 异常扩展
    /// </summary>
    public static class ExceptionExtension
    {
        /// <summary>
        /// 检查是否为null, null抛出异常
        /// </summary>
        /// <param name="obj">检查对象</param>
        /// <param name="message">异常参数</param>
        public static void NullCheck(this object obj, string message)
        {
            if (obj == null) throw new Exception(message);
        }

        /// <summary>
        /// 检查是否为空字符串
        /// </summary>
        /// <param name="str"></param>
        /// <param name="message"></param>
        public static void EmptyCheck(this string str, string message)
        {
            if (str.IsNullOrEmpty()) throw new Exception(message);
        }

        /// <summary>
        /// 检查是否为true, true抛出异常
        /// </summary>
        /// <param name="obj">检查对象</param>
        /// <param name="message">异常参数</param>
        public static void TrueCheck(this bool obj, string message)
        {
            if (obj) throw new Exception(message);
        }

        /// <summary>
        /// 检查是否为false, false抛出异常
        /// </summary>
        /// <param name="obj">检查对象</param>
        /// <param name="message">异常参数</param>
        public static void FalseCheck(this bool obj, string message)
        {
            if (!obj) throw new Exception(message);
        }

        /// <summary>
        /// 检查是否在集合内, 不在则抛出异常
        /// </summary>
        /// <typeparam name="T">检查类型</typeparam>
        /// <param name="objs">要检查的集合类型</param>
        /// <param name="check">检查函数</param>
        /// <param name="message">异常信息</param>
        public static void NotInCheck<T>(this IEnumerable<T> objs, Func<T, bool> check, string message)
        {
            bool has = false;
            foreach (var obj in objs)
            {
                if (check(obj))
                {
                    has = true;
                    break;
                }
            }

            if (!has) throw new Exception(message);
        }

        /// <summary>
        /// 检查是否在集合内, 在则抛出异常
        /// </summary>
        /// <typeparam name="T">检查类型</typeparam>
        /// <param name="objs">要检查的集合类型</param>
        /// <param name="check">检查函数</param>
        /// <param name="message">异常信息</param>
        public static void InCheck<T>(this IEnumerable<T> objs, Func<T, bool> check, string message)
        {
            bool has = false;
            foreach (var obj in objs)
            {
                if (check(obj))
                {
                    has = true;
                    break;
                }
            }

            if (has) throw new Exception(message);
        }
    }
}
