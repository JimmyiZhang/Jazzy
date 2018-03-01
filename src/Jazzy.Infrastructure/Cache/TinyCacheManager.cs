using System;

namespace Jazzy.Infrastructure
{
    public class TinyCacheManager
    {
        private TinyCacheManager() { }
        public TinyCacheSetting Setting { get; private set; }
        public static TinyCacheManager Instance { get; private set; }

        public static void Build(Action<TinyCacheSetting> action)
        {
            if (Instance != null) return;

            Instance = new TinyCacheManager();
            Instance.Setting = new TinyCacheSetting();
            action(Instance.Setting);
        }
    }
}
