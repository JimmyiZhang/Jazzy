using Jazzy.Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Jazzy.Infrastructure.Test.Library
{
    [TestClass]
    public class DateTimeExtensionTest
    {
        [TestMethod]
        public void DateTimeExtension_Today()
        {
            var date = new DateTime(2018, 2, 28, 12, 34, 56);
            var actual = date.Today();
            var expected = date;
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void DateTimeExtension_Yesterday()
        {
            var date = new DateTime(2018, 2, 28, 12, 34, 56);
            var actual = date.Yesterday();
            var expected = new DateTime(2018, 2, 27, 12, 34, 56);
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void DateTimeExtension_WeekDay()
        {
            var date = new DateTime(2018, 2, 28, 12, 34, 56);
            var actual = date.WeekDay();
            var expected = new DateTime(2018, 2, 26, 12, 34, 56);
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void DateTimeExtension_MonthDay()
        {
            var date = new DateTime(2018, 2, 28, 12, 34, 56);
            var actual = date.MonthDay();
            var expected = new DateTime(2018, 2, 1, 12, 34, 56);
            Assert.AreEqual(actual, expected);

        }
    }
}
