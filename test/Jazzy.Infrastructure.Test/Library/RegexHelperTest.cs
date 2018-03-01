using Jazzy.Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text.RegularExpressions;

namespace Jazzy.Infrastructure.Test.Library
{
    [TestClass]
    public class RegexHelperTest
    {
        [TestMethod]
        public void RegexHelper_ReplaceBefore()
        {
            // 空格前加,
            var expected = "Plants, and, animals, live, together";
            var actual = RegexHelper.ReplaceBefore("Plants and animals live together", "(\\s)", ",");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RegexHelper_ReplaceAfter()
        {
            // 空格前后,
            var expected = "Plants ,live ,in ,most ,places";
            var actual = RegexHelper.ReplaceAfter("Plants live in most places", "(\\s)", ",");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RegexHelper_MatchGroup()
        {
            // 匹配分组
            var input = "Some animals eat other animals for food";
            var actual = RegexHelper.MatchGroup(input,"(?<an>a\\w)","an");

            Assert.AreEqual(actual, "an");
        }

        [TestMethod]
        public void RegexHelper_MatchGroups()
        {
            // 匹配分组
            var input = "Some animals eat other animals for food";
            var actual = RegexHelper.MatchGroups(input, "(?<aw>\\w*a\\w*)", "aw");

            Assert.AreEqual(actual, "an");
        }
    }
}
