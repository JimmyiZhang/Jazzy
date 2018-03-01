using Jazzy.Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Jazzy.Infrastructure.Test.Library
{
    [TestClass]
    public class EnumHelperTest
    {
        [TestMethod]
        public void EnumHelper_Parse()
        {
            SimpleEnum expected1 = SimpleEnum.One;
            SimpleEnum expected2 = SimpleEnum.Two;
            SimpleEnum expected6 = SimpleEnum.Six;

            var actual1 = EnumHelper.Parse<SimpleEnum>("One");
            var actual2 = EnumHelper.Parse<SimpleEnum>("two");
            var actual6 = EnumHelper.Parse<SimpleEnum>("6");

            Assert.AreEqual(expected1, actual1);
            Assert.AreNotEqual(expected2, actual2);
            Assert.AreEqual(expected6, actual6);
        }
    }
}
