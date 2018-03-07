namespace Jazzy.Domain
{
    /// <summary>
    /// 账号状态
    /// </summary>
    public enum AccountStatus
    {
        /// <summary>
        /// 激活
        /// </summary>
        Activated = 1,

        /// <summary>
        /// 锁定
        /// </summary>
        Locked = 2,

        /// <summary>
        /// 无效的
        /// </summary>
        Disabled = 10,
    }
}