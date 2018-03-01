using Jazzy.Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Jazzy.Infrastructure.Test.Library
{
    [TestClass]
    public class StringExtensionTest
    {
        [TestMethod]
        public void StringExtension_GetAt()
        {
            string source = "ACDEFGHIJKLMNOPQRSTUWXYZ";
            var dist = source.GetAt(1, 2, 4, 5);

            Assert.AreEqual(dist, "CDFG");
        }

        [TestMethod]
        public void StringExtension_Mask()
        {
            string source = "13911006493";
            var dist = source.Mask(7, 4, '*');

            Assert.AreEqual(dist, "1391100****");
        }

        [TestMethod]
        public void StringExtension_Group()
        {
            var dist1 = "ABCDEF".Group(2, '-');
            var dist2 = "ABCDEFG".Group(2, '-');

            Assert.AreEqual(dist1, "AB-CD-EF");
            Assert.AreEqual(dist2, "AB-CD-EF-G");
        }

        [TestMethod]
        public void StringExtension_Sub()
        {
            var dist1 = "ABCEDFGH".Sub(5, 10);
            var dist2 = "ABC".Sub(4, 10);

            Assert.AreEqual(dist1, "FGH");
            Assert.AreEqual(dist2, string.Empty);

        }
    }
}
