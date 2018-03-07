using Jazzy.Component;
using Jazzy.Library;
using System;

namespace Jazzy.Domain
{
    /// <summary>
    /// 账号信息
    /// </summary>
    public class Account : IEntity
    {
        /// <summary>
        /// 编码
        /// </summary>
        public long Code { get; set; }

        /// <summary>
        /// 登录名称
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 登陆密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 账号状态
        /// </summary>
        public AccountStatus Status { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// 密码盐, 长度要求16位无规则字符
        /// </summary>
        public string Salt { get; set; }

        /// <summary>
        /// 默认构造函数
        /// </summary>
        public Account() { }

        /// <summary>
        /// 通过登陆名称，登录密码和类型构造账号
        /// </summary>
        /// <param name="userName">登陆名称</param>
        /// <param name="password">登陆密码</param>
        public Account(string userName, string password)
        {
            this.CreateTime = DateTime.Now;
            this.UpdateTime = DateTime.Now;

            this.Salt = RandomHelper.Random(36);
            this.Password = HashPassword(password, this.Salt);
            this.Status = AccountStatus.Activated;
            this.UserName = userName;
        }

        /// <summary>
        /// 比较密码
        /// </summary>
        /// <param name="password">密码</param>
        /// <returns>是否匹配</returns>
        public bool ComparePassword(string password)
        {
            this.Salt.EmptyCheck("password is empty");

            string hashPassword = HashPassword(password, this.Salt);
            return this.Password == hashPassword;
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public void ChangePassword(string password)
        {
            this.Salt = RandomHelper.Random(36);
            this.Password = HashPassword(password, this.Salt);
            this.UpdateTime = DateTime.Now;
        }

        private string HashPassword(string password, string salt)
        {
            string hashPassword = SecurityHelper.HashBySHA256(password + salt);
            return hashPassword;
        }
    }
}