using System;

namespace Jazzy.Library
{
    /// <summary>
    /// 时间扩展
    /// </summary>
    public static class DateTimeExtension
    {
        private static DateTime unixTime = new DateTime(1970, 1, 1);

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
        /// 本周第一天
        /// </summary>
        /// <param name="moment"></param>
        /// <returns></returns>
        public static DateTime WeekDay(this DateTime moment)
        {
            var days = moment.DayOfWeek == DayOfWeek.Sunday ? 7 : (int)moment.DayOfWeek;
            return moment.AddDays(1 - days);
        }

        /// <summary>
        /// 本月第一天
        /// </summary>
        /// <param name="moment"></param>
        /// <returns></returns>
        public static DateTime MonthDay(this DateTime moment)
        {
            return moment.AddDays(1 - moment.Day);
        }

        /// <summary>
        /// 是否周末
        /// </summary>
        /// <param name="moment"></param>
        /// <returns></returns>
        public static bool IsWeekend(this DateTime moment)
        {
            return moment.DayOfWeek == DayOfWeek.Sunday || moment.DayOfWeek == DayOfWeek.Saturday;
        }

        /// <summary>
        /// 时间戳
        /// </summary>
        /// <param name="moment"></param>
        /// <returns></returns>
        public static long Timestamp(this DateTime moment)
        {
            if (moment < unixTime) return 0;
            return (long)(moment - unixTime).TotalSeconds;
        }
    }
}
