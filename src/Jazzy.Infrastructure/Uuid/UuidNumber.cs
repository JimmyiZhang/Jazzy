using System;

namespace Jazzy.Infrastructure.Uuid
{
    /// <summary>
    /// 全局唯一ID生成器
    /// 满足唯一, 顺序但不连续
    /// </summary>
    public class UuidNumber
    {
        private static IdWorker idWorker;
        public static readonly UuidNumber Instance = new UuidNumber();
        private UuidNumber() { }

        public static void Build(Action<UuidNumberSetting> action)
        {
            if (idWorker != null) return;

            UuidNumberSetting setting = new UuidNumberSetting();
            action(setting);

            idWorker = setting.Build();
        }

        public long Next()
        {
             return idWorker.NextId();
        }
    }
}
