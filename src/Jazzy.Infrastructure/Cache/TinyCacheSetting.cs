using Microsoft.Extensions.Caching.Memory;
using System;

namespace Jazzy.Infrastructure
{
    public class TinyCacheSetting
    {
        private TinyCacheExpirationMode mode { get; set; }
        private int minutes { get; set; }

        public TinyCacheSetting()
        {
            this.mode = TinyCacheExpirationMode.None;
            this.minutes = 7 * 24 * 60;
        }

        public TinyCacheSetting WithExpiration(TinyCacheExpirationMode mode, int minutes)
        {
            this.mode = mode;
            this.minutes = minutes;
            return this;
        }

        internal MemoryCacheEntryOptions ToOption()
        {
            MemoryCacheEntryOptions option = new MemoryCacheEntryOptions();
            var expiration = TimeSpan.FromMinutes(this.minutes);

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

            return option;
        }
    }
}
