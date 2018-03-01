using System;

namespace Jazzy.Infrastructure.Uuid
{
    internal static class TimeExtensions
    {
        public static Func<long> currentTimeFunc = InternalCurrentTimeMillis;
 
        public static long CurrentTimeMillis()
        {
            return currentTimeFunc();
        }

        public static IDisposable StubCurrentTime(Func<long> func)
        {
            currentTimeFunc = func;
            return new DisposableAction(() =>
            {
                currentTimeFunc = InternalCurrentTimeMillis;
            });  
        }

        public static IDisposable StubCurrentTime(long millis)
        {
            currentTimeFunc = () => millis;
            return new DisposableAction(() =>
            {
                currentTimeFunc = InternalCurrentTimeMillis;
            });
        }

        private static readonly DateTime StartingTime = new DateTime
           (2012, 12, 21, 0, 0, 0, DateTimeKind.Utc);

        private static long InternalCurrentTimeMillis()
        {
            return (long)(DateTime.UtcNow - StartingTime).TotalMilliseconds;
        }        
    }
}
