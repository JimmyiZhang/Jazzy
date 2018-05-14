using System.Text.RegularExpressions;

namespace Jazzy.Library
{
    public class RegexUtility
    {
        /// <summary>
        /// 是否Email格式
        /// </summary>
        /// <returns></returns>
        public static bool IsEmail(string input)
        {
            if (input.IsNullOrEmpty()) return false;
            return Regex.IsMatch(input, @"^[a-z]([a-z0-9]*[-_]?[a-z0-9]+)*@([a-z0-9]*[-_\.]?[a-z0-9]+)+[\.][a-z]{2,3}([\.][a-z]{2})?$");
        }

        public static bool IsPhone(string input)
        {
            if (input.IsNullOrEmpty()) return false;
            return Regex.IsMatch(input, @"^1\d{10}");
        }
    }
}
