using System;

namespace Jazzy.Infrastructure
{
    public static class DateTimeConfig
    {
        public static readonly DateTime MinDbValue = new DateTime(1900, 1, 1);
        public static DateTime ToMinDbValue(this DateTime dt)
        {
            if (dt == DateTime.MinValue) return MinDbValue;
            return dt;
        }
    }
}
