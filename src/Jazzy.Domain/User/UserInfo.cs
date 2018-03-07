namespace Jazzy.Domain
{
    /// <summary>
    /// 用户信息
    /// </summary>
    public class UserInfo
    {
        /// <summary>
        /// 用户编号
        /// </summary>
        public long UserCode { get; set; }

        /// <summary>
        /// 登陆名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 显示名
        /// </summary>
        public string DisplayName { get; set; }
    }
}
