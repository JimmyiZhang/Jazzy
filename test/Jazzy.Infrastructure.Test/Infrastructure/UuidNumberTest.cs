using Jazzy.Infrastructure.Uuid;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Jazzy.Infrastructure.Test.Infrastructure
{
    [TestClass]
    public class UuidNumberTest
    {
        [TestMethod]
        public void UuidNumber_Build()
        {
            UuidNumber.Build(n =>
            {
                n.SetWorkId(0).SetDatacenterId(0);
            });

            Assert.IsNotNull(UuidNumber.Instance);
        }

        [TestMethod]
        public void UuidNumber_NextNumber()
        {
            UuidNumber.Build(n =>
            {
                n.SetWorkId(0).SetDatacenterId(0);
            });

            var actual = 0L;
            for (int i = 0; i < 1000; i++)
            {
                actual = UuidNumber.Instance.Next();
                Console.WriteLine(actual.ToString());
            }

            Assert.IsTrue(actual > 0);
        }
    }
}
