using System;

namespace Jazzy.Library
{
    public static class EnumHelper
    {
        /// <summary>
        /// 把字符串转化为枚举类型
        /// </summary>
        /// <typeparam name="T">枚举类型</typeparam>
        /// <param name="value">需要转换的字符串</param>
        /// <returns>转化后的枚举</returns>
        public static T Parse<T>(string value) where T : struct
        {
            T result;
            if (Enum.TryParse<T>(value, out result))
            {
                return result;
            }

            return default(T);
        }
    }
}
