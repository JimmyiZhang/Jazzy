using Jazzy.Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Jazzy.Infrastructure.Test.Library
{
    [TestClass]
    public class CollectionExtensionTest
    {
        private IList<SimpleModel> sources;
        private IList<SimpleModel> compared;
        private IList<SimpleModelTarget> targets;

        [TestInitialize]
        public void Init()
        {
            this.sources = new List<SimpleModel>()
            {
                 new SimpleModel(){ Name="Jimmy",Age=30},
                 new SimpleModel(){ Name="Fay",Age=18},
                 new SimpleModel(){Name="Amy",Age=60},
                 new SimpleModel(){ Name="David",Age=20},
            };

            this.compared = new List<SimpleModel>()
            {
                 new SimpleModel(){ Name="Jimmy",Age=22},
                 new SimpleModel(){ Name="Jimmy1",Age=23},
                 new SimpleModel(){ Name="Jimmy2",Age=24},
            };

            this.targets = new List<SimpleModelTarget>()
            {
                 new SimpleModelTarget(){ Name="Jimmy",Age=30},
                 new SimpleModelTarget(){ Name="Fay",Age=18},
                 new SimpleModelTarget(){Name="Amy",Age=60},
                 new SimpleModelTarget(){ Name="David",Age=20},
            };
        }

        [TestMethod]
        public void CollectionExtension_Distinct1()
        {
            var dist = this.sources.Distinct(k => k.Name);

            var actual = dist.Count();
            var expected = 4;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void CollectionExtension_Distinct2()
        {
            var dist = this.sources.Distinct((a, b) => a.Name == b.Name);

            var actual = dist.Count();
            var expected = 4;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void CollectionExtension_Merge()
        {
            // 满足Name相同进行合并
            this.sources.Merge(this.compared, (a, b) => a.Name == b.Name);

            var jimmy = this.sources.First();
            Assert.AreEqual(this.sources.Count(), 1);
            Assert.AreEqual(jimmy.Age, 22);
        }

        [TestMethod]
        public void CollectionExtension_Merge_Map()
        {
            // 满足Name相同进行合并
            this.sources.Merge(this.targets,
                a => new SimpleModel()
                {
                    Age = a.Age,
                    Name = a.Name
                });

            var count = this.sources.Count();
            Assert.AreEqual(count, 8);
        }

        [TestMethod]
        public void CollectionExtension_Merge_Arange()
        {
            // 满足Name相同进行合并
            this.sources.Merge(this.compared);

            var count = this.sources.Count();
            Assert.AreEqual(count, 7);
        }

        [TestMethod]
        public void CollectionExtension_Sort1()
        {
            var dist = this.sources.Sort((a, b) => a.Age > b.Age);

            var name = dist.First().Name;
            Assert.AreEqual(name, "Fay");
        }

        [TestMethod]
        public void CollectionExtension_Sort2()
        {
            this.sources.OrderBy(a => a.Age);

            var name = this.sources.First().Name;
            Assert.AreEqual(name, "Jimmy");
        }
    }
}
