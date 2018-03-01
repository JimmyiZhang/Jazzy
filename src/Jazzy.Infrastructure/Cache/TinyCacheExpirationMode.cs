namespace Jazzy.Infrastructure
{
    /// <summary>
    /// 缓存过期模式
    /// </summary>
    public enum TinyCacheExpirationMode
    {
        /// <summary>
        /// 无
        /// </summary>
        None = 0,

        /// <summary>
        /// 可调时间
        /// 自上次被访问后多长时间过期
        /// </summary>
        Sliding = 1,

        /// <summary>
        /// 绝对时间
        /// 在设定的时间后过期
        /// </summary>
        Absolute = 2,
    }
}
