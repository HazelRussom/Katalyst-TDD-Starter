using Katalyst_TDD_Starter.Bags;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Katalyst_TDD_Starter.Test.Bags
{
    [TestClass]
    public class BagBeltShould
    {
        [TestMethod]
        public void Start_with_no_bags()
        {
            var underTest = new BagBelt();

            Assert.IsFalse(underTest.GetBags().Any());
        }

        [TestMethod]
        public void Add_a_bag()
        {
            var underTest = new BagBelt();
            var bagToAdd = new Bag();

            underTest.AddBag(bagToAdd);

            var bags = underTest.GetBags();
            Assert.IsTrue(bags.Contains(bagToAdd));
            Assert.AreEqual(1, bags.Count);
        }
    }
}
