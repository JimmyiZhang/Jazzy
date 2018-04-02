using Jazzy.Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jazzy.Infrastructure.Test.Library
{
    [TestClass]
    public class TypeExtensionTest
    {
        [TestMethod]
        public void TypeExtension_IsInterface_General()
        {
            var t = new SimpleGeneralType();
            var yes = t.GetType().AsInterface(typeof(SimpleInterface));
            Assert.IsTrue(yes);
        }

        [TestMethod]
        public void TypeExtension_IsInterface_Generic()
        {
            var t = new SimpleGenericType<string>();
            var yes = t.GetType().AsInterface(typeof(SimpleInterface));
            Assert.IsTrue(yes);
        }
    }
}
