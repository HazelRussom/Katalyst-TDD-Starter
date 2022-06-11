using Katalyst_TDD_Starter.Bags;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Katalyst_TDD_Starter.Test.Bags
{
    [TestClass]
    public class BagBeltTests
    {
        public BagBelt ToTest { get; private set; }

        public BagBeltTests()
        {
            ToTest = new BagBelt();
        }

        [TestMethod]
        [DataRow (1)]
        [DataRow (2)]
        [DataRow (4)]
        public void Bag_belt_can_hold_bags(int numberOfBags)
        {
            for (int i = 0; i < numberOfBags; i++)
            {
                ToTest.AddBag(new StorageBag(1));
            }

            Assert.IsTrue(ToTest.Bags.Count == numberOfBags);
        }

        [TestMethod]
        public void Bag_belt_can_add_items_to_held_bags()
        {
            ToTest.AddBag(new StorageBag(4));

            ToTest.AddItem("Leather");

            var firstBag = ToTest.Bags[0];
            Assert.AreEqual(firstBag.Items.Count, 1);
            Assert.IsTrue(firstBag.Items.Contains("Leather"));
        }
    }
}
