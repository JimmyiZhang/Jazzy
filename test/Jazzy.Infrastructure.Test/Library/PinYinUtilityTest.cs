using Jazzy.Library.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Jazzy.Infrastructure.Test.Library
{
    [TestClass]
    public class PinYinUtilityTest
    {
        [TestMethod]
        public void PinYinUtility_Get()
        {
            var expected = "ZhongQing";
            var actual = PinYinUtility.Get("重庆");

            Assert.AreEqual(expected, actual);
        }
    }
}
