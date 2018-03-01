using Jazzy.Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Jazzy.Infrastructure.Test.Library
{
    [TestClass]
    public class RandomHelperTest
    {
        [TestMethod]
        public void RandomHelper_NewComb()
        {
            for (int i = 0; i < 100; i++)
            {
                var guid = RandomHelper.NewComb();
                Console.WriteLine(guid.ToString("N"));
            }

            var guid1 = RandomHelper.NewComb();
            Assert.AreNotEqual(guid1, Guid.Empty);
        }

        [TestMethod]
        public void RandomHelper_Random()
        {
            for (int i = 0; i < 100; i++)
            {
                var rnd = RandomHelper.Random(10, true);
                Console.WriteLine(rnd);
            }

            var actual = RandomHelper.Random(10);
            Assert.IsTrue(actual.Length == 10);
        }

        [TestMethod]
        public void RandomHelper_RandomNumber()
        {
            for (int i = 0; i < 100; i++)
            {
                var rnd = RandomHelper.RandomNumber(5);
                Console.WriteLine(rnd);
            }

            var actual = RandomHelper.RandomNumber(6);
            Assert.IsTrue(actual > 0);
        }
    }
}
