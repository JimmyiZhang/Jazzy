using Microsoft.Extensions.Caching.Memory;
using System;

namespace Jazzy.Infrastructure
{
    public static class TinyMemoryCaching
    {
        public static void Clear(this IMemoryCache cache)
        {
            cache.Clear();
        }

        public static T Get<T>(this IMemoryCache cache, string key)
        {
            cache.TryGetValue<T>(key, out T result);
            return result;
        }

        public static T Get<T>(this IMemoryCache cache, string key, Func<T> action)
        {
            var ok = cache.TryGetValue(key, out T result);
            if (ok) return result;

            result = action();
            var option = TinyCacheManager.Instance.Setting.ToOption();
            cache.Set(key, result, option);

            return result;
        }

        public static void Remove(this IMemoryCache cache, string key)
        {
            cache.Remove(key);
        }

        public static void Set<T>(this IMemoryCache cache, string key, T value)
        {
            var option = TinyCacheManager.Instance.Setting.ToOption();
            cache.Set(key, value, option);
        }

        public static void Set<T>(this IMemoryCache cache, string key, T value, TinyCacheExpirationMode mode, int minutes)
        {
            MemoryCacheEntryOptions option = new MemoryCacheEntryOptions();
            var expiration = TimeSpan.FromMinutes(minutes);

            switch (mode)
            {
                case TinyCacheExpirationMode.None:
                case TinyCacheExpirationMode.Sliding:
                    option.SetSlidingExpiration(expiration);
                    break;
                case TinyCacheExpirationMode.Absolute:
                    option.SetAbsoluteExpiration(expiration);
                    break;
            }

            cache.Set(key, value, option);
        }
    }
}
