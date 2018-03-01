using System.Text.RegularExpressions;

namespace Jazzy.Library
{
    /// <summary>
    /// 正则帮助类
    /// </summary>
    public class RegexHelper
    {
        /// <summary>
        /// 前置替换, 在替换表达式之前加前置字符串
        /// </summary>
        /// <param name="source">替换源</param>
        /// <param name="pattern">替换表达式</param>
        /// <param name="replacement">前置字符串</param>
        /// <returns>替换后的字符串</returns>
        public static string ReplaceBefore(string source, string pattern, string replacement)
        {
            if (string.IsNullOrEmpty(source)) return source;
            return Regex.Replace(source, pattern, replacement + "$1");
        }

        /// <summary>
        /// 后置替换, 在替换表达式之后加后置字符串
        /// </summary>
        /// <param name="source">替换源</param>
        /// <param name="pattern">替换表达式</param>
        /// <param name="replacement">后置字符串</param>
        /// <returns>替换后的字符串</returns>
        public static string ReplaceAfter(string source, string pattern, string replacement)
        {
            if (string.IsNullOrEmpty(source)) return source;
            return Regex.Replace(source, pattern, "$1" + replacement);
        }

        /// <summary>
        /// 获取分组匹配(第一个匹配)的字符串
        /// </summary>
        /// <param name="input">输入</param>
        /// <param name="pattern">表达式</param>
        /// <param name="groups">分组集合</param>
        /// <returns>匹配结果</returns>
        public static string[] MatchGroups(string input, string pattern, params string[] groups)
        {
            if (string.IsNullOrEmpty(input) || string.IsNullOrEmpty(pattern) || groups == null)
                return null;

            Regex reg = new Regex(pattern);
            var mathes = reg.Matches(input);
            if (mathes.Count == 0) return null;

            string[] result = new string[groups.Length];
            for (int i = 0; i < groups.Length; i++)
            {
                result[i] = mathes[0].Groups[groups[i]].Value;
            }

            return result;
        }

        /// <summary>
        /// 获取分组匹配(第一个匹配)的字符串
        /// </summary>
        /// <param name="input">输入</param>
        /// <param name="pattern">表达式</param>
        /// <param name="group">分组</param>
        /// <returns>匹配结果</returns>
        public static string MatchGroup(string input, string pattern, string group)
        {
            if (string.IsNullOrEmpty(input) || string.IsNullOrEmpty(pattern) || string.IsNullOrEmpty(group))
                return null;

            Regex reg = new Regex(pattern);
            var mathes = reg.Matches(input);
            if (mathes.Count == 0) return null;

            return mathes[0].Groups[group].Value;
        }

        /// <summary>
        /// 获取是否匹配, 支持*
        /// </summary>
        /// <param name="input">输入</param>
        /// <param name="pattern">模式</param>
        /// <returns></returns>
        public static bool Match(string input, string pattern, bool ignoreCase = true)
        {
            if (ignoreCase)
            {
                input = input.ToLower();
                pattern = pattern.ToLower();
            }

            bool match = false;
            bool wildcard = false;
            int j = 0;

            for (int i = 0; i < input.Length; i++)
            {
                for (; j < pattern.Length;)
                {
                    // 匹配*
                    if (pattern[j] == '*')
                    {
                        wildcard = true;
                        match = true;
                        j++;
                        break;
                    }

                    // 匹配, 下一个input
                    if (input[i] == pattern[j])
                    {
                        wildcard = false;
                        match = true;
                        j++;
                        break;
                    }
                    // 不匹配
                    // 通配符模式, 下一个
                    if (wildcard)
                    {
                        match = true;
                        j++;
                        continue;
                    }
                    // 从头开始
                    match = false;
                    j = 0;
                    break;
                }

            }

            return match && (j == pattern.Length);
        }
    }
}
