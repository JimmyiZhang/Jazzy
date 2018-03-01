using System;
using System.Collections.Generic;
using System.Linq;

namespace Jazzy.Library
{
    /// <summary>
    /// 集合扩展
    /// </summary>
    public static class CollectionExtension
    {
        /// <summary>
        /// 自定义排序
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="data">排序数据</param>
        /// <param name="comparer">比较器</param>
        /// <returns></returns>
        public static IEnumerable<T> Sort<T>(this IEnumerable<T> data, Func<T, T, bool> comparer)
        {
            var arrData = data.ToArray();

            IComparer<T> geComparer = new GeneralCompare<T>(comparer);
            Array.Sort<T>(arrData, geComparer);

            return arrData;
        }

        /// <summary>
        /// 自定义比较
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <param name="comparer"></param>
        /// <returns></returns>
        public static IEnumerable<T> Distinct<T>(this IEnumerable<T> data, Func<T, T, bool> comparer)
        {
            IEqualityComparer<T> eqComparer = new GeneralEqualityCompare<T>(comparer);
            return Enumerable.Distinct<T>(data, eqComparer);
        }

        /// <summary>
        /// 自定义比较
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="source"></param>
        /// <param name="keySelector"></param>
        /// <returns></returns>
        public static IEnumerable<TSource> Distinct<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();
            foreach (TSource element in source)
            {
                var elementValue = keySelector(element);
                if (seenKeys.Add(elementValue))
                {
                    yield return element;
                }
            }
        }

        /// <summary>
        /// 自定义与非
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <param name="comparer"></param>
        /// <returns></returns>
        public static IEnumerable<T> Except<T>(this IEnumerable<T> first, IEnumerable<T> second, Func<T, T, bool> comparer)
        {
            IEqualityComparer<T> comparerClass = new GeneralEqualityCompare<T>(comparer);
            return Enumerable.Except<T>(first, second, comparerClass);
        }

        /// <summary>
        /// 自定义相交
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <param name="comparer"></param>
        /// <returns></returns>
        public static IEnumerable<T> Intersect<T>(this IEnumerable<T> first, IEnumerable<T> second, Func<T, T, bool> comparer)
        {
            IEqualityComparer<T> comparerClass = new GeneralEqualityCompare<T>(comparer);
            return Enumerable.Intersect<T>(first, second, comparerClass);
        }

        /// <summary>
        /// 自定义合并
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <param name="comparer"></param>
        /// <returns></returns>
        public static IEnumerable<T> Union<T>(this IEnumerable<T> first, IEnumerable<T> second, Func<T, T, bool> comparer)
        {
            IEqualityComparer<T> comparerClass = new GeneralEqualityCompare<T>(comparer);
            return Enumerable.Union<T>(first, second, comparerClass);
        }

        /// <summary>
        /// 集合是否为空
        /// </summary>
        /// <typeparam name="T">集合类型</typeparam>
        /// <param name="collection">集合</param>
        /// <returns>true则为空, 否则为false</returns>
        public static bool IsEmpty<T>(this IEnumerable<T> collection)
        {
            return !collection.Any();
        }

        /// <summary>
        /// 根据条件合并到集合中
        /// 只合并第一条满足条件的数据
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="sources">源数据</param>
        /// <param name="selector">合并的条件</param>
        /// <param name="target">合并的数据</param>
        public static void Merge<T>(this IList<T> sources, Func<T, bool> selector, T target)
        {
            bool has = false;
            for (int i = 0; i < sources.Count; i++)
            {
                if (selector(sources[i]))
                {
                    sources[i] = target;
                    has = true;
                    break;
                }
            }

            if (!has)
            {
                sources.Add(target);
            }
        }

        /// <summary>
        /// 根据条件合并到集合中
        /// 满足条件的target合并到source中
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="sources">源数据</param>
        /// <param name="targets">合并的数据</param>
        /// <param name="codition">合并的条件</param>
        public static void Merge<T>(this IList<T> sources, IList<T> targets, Func<T, T, bool> codition)
        {
            if (targets == null) return;
            if (codition == null) return;

            for (int i = sources.Count; i > 0; i--)
            {
                bool has = false;
                for (int j = targets.Count; j > 0; j--)
                {
                    if (codition(sources[i - 1], targets[j - 1]))
                    {
                        sources[i - 1] = targets[j - 1];
                        has = true;
                        break;
                    }
                }

                if (!has)
                {
                    sources.RemoveAt(i - 1);
                }
            }
        }
    }
}
