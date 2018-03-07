using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Carbycar.Logistics.Domain.Test
{
    [TestClass]
    public class AccountTest
    {
        [TestMethod]
        public void CreateAccount()
        {
            Account account = new Account("admin", "admin", UserType.Accountant);
            Console.WriteLine("PASSWORD:" + account.Password + ",SALT:" + account.Salt);
            Assert.IsNotNull(account.Password);
        }

        [TestMethod]
        public void PasswordAccount()
        {
            Account account = new Account("13911006493", "123456", UserType.Accountant);

            var result = account.ComparePassword("123456");
            Assert.IsTrue(result);
        }
    }
}
