using System;

namespace Jazzy.Library
{
    /// <summary>
    /// 时间扩展
    /// </summary>
    public static class DateTimeExtension
    {
        /// <summary>
        /// 今天此时
        /// </summary>
        /// <param name="moment"></param>
        /// <returns></returns>
        public static DateTime Today(this DateTime moment)
        {
            return moment;
        }

        /// <summary>
        /// 昨天此时
        /// </summary>
        /// <param name="moment"></param>
        /// <returns></returns>
        public static DateTime Yesterday(this DateTime moment)
        {
            return moment.AddDays(-1);
        }

        /// <summary>
        /// 本周此时
        /// </summary>
        /// <param name="moment"></param>
        /// <returns></returns>
        public static DateTime WeekDay(this DateTime moment)
        {
            var days = moment.DayOfWeek == DayOfWeek.Sunday ? 7 : (int)moment.DayOfWeek;
            return moment.AddDays(1 - days);
        }

        /// <summary>
        /// 本月此时
        /// </summary>
        /// <param name="moment"></param>
        /// <returns></returns>
        public static DateTime MonthDay(this DateTime moment)
        {
            return moment.AddDays(1 - moment.Day);
        }
    }
}
