using System;

namespace Jazzy.Library
{
    /// <summary>
    /// 字符串扩展
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        /// 获取相应位置的字符串
        /// </summary>
        /// <param name="source">数据源</param>
        /// <param name="indexs">位置</param>
        /// <returns>结果字符串</returns>
        public static string GetAt(this string source, params int[] indexs)
        {
            if (string.IsNullOrEmpty(source)) return source;
            if (indexs == null && indexs.Length == 0) return source;

            char[] targetChar = new char[indexs.Length];
            for (int i = 0; i < indexs.Length; i++)
            {
                if (i > source.Length) throw new IndexOutOfRangeException();
                targetChar[i] = source[indexs[i]];
            }

            return new string(targetChar);
        }

        /// <summary>
        /// 以特定字符代替原字符
        /// </summary>
        /// <param name="source">原字符</param>
        /// <param name="beginIndex">开始位置</param>
        /// <param name="length">长度</param>
        /// <param name="mask">替代字符</param>
        /// <returns>替代后的字符</returns>
        public static string Mask(this string source, int beginIndex, int length, char mask)
        {
            if (beginIndex >= source.Length - 1) return source;

            char[] target = source.ToCharArray();
            for (int i = beginIndex; i < source.Length && length > 0; i++)
            {
                target[i] = mask;
                length--;
            }
            return new string(target);
        }

        /// <summary>
        /// 按特定长度分组并在分组之间填充字符
        /// </summary>
        /// <param name="source">源数据</param>
        /// <param name="group">分组长度</param>
        /// <param name="mask">替代字符</param>
        /// <returns>替代后的字符</returns>
        public static string Group(this string source, int group, char mask)
        {
            if (group >= source.Length - 1) return source;

            int n = source.Length + source.Length / group + (source.Length % group == 0 ? -1 : 0);
            char[] target = new char[n];

            int nIndex = 0;
            int mIndex = 0;
            for (int i = 0; i < source.Length;)
            {
                if (mIndex == group)
                {
                    mIndex = 0;
                    target[nIndex] = mask;
                    nIndex++;
                }
                else
                {
                    mIndex++;
                    target[nIndex] = source[i];
                    nIndex++;
                    i++;
                }
            }
            return new string(target);
        }

        /// <summary>
        /// 获取指定位置开始指定长度的子串
        /// 开始位置大于长度, 返回空串
        /// 长度超过可获取最大长度, 则返回最可能的长度
        /// </summary>
        /// <param name="source">源字符串</param>
        /// <param name="startIndex">开始位置</param>
        /// <param name="length">指定长度</param>
        /// <returns></returns>
        public static string Sub(this string source, int startIndex, int length = 0)
        {
            if (string.IsNullOrEmpty(source)) return source;

            int sourceLen = source.Length - 1;
            if (startIndex > sourceLen) return string.Empty;

            if (startIndex < 0) startIndex = 0;
            if (length <= 0 || length > sourceLen - startIndex) return source.Substring(startIndex);

            return source.Substring(startIndex, length);
        }

        /// <summary>
        /// 判断字符串为空(包括null和empty)
        /// </summary>
        /// <param name="source">数据源</param>
        /// <returns>空返回true</returns>
        public static bool IsNullOrEmpty(this string source)
        {
            return string.IsNullOrEmpty(source);
        }

        /// <summary>
        /// 判断字符串不为空和null
        /// </summary>
        /// <param name="source">数据源</param>
        /// <returns>null或空返回true, 否则false</returns>
        public static bool IsNotEmpty(this string source)
        {
            return !string.IsNullOrWhiteSpace(source);
        }
    }
}
