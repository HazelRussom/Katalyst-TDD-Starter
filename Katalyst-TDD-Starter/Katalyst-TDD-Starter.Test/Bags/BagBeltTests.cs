using Katalyst_TDD_Starter.Bags;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Katalyst_TDD_Starter.Test.Bags
{
    [TestClass]
    public class BagBeltTests
    {
        public BagBelt ToTest { get; private set; }
        public Item LeatherItem { get; }

        public BagBeltTests()
        {
            ToTest = new BagBelt();
            LeatherItem = new Item("Leather", ItemCategory.Cloth);
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

            ToTest.AddItem(LeatherItem);

            var firstBag = ToTest.Bags[0];
            Assert.AreEqual(firstBag.Items.Count, 1);
            Assert.IsTrue(firstBag.Items.Contains(LeatherItem));
        }

        [TestMethod]
        [DataRow(2)]
        [DataRow(3)]
        [DataRow(10)]
        public void Adding_items_should_not_exceed_any_held_bag_size_limits(int bagCount)
        {
            for(int i = 0; i < bagCount; i++)
            {
                ToTest.AddBag(new StorageBag(1));
                ToTest.AddItem(LeatherItem);
            }

            foreach(var bag in ToTest.Bags)
            {
                Assert.AreEqual(bag.Items.Count, 1);
            }
        }

        [TestMethod]
        public void Items_should_be_put_into_first_bag_open_bag()
        {
            ToTest.AddBag(new StorageBag(1));
            ToTest.AddBag(new StorageBag(1, ItemCategory.Cloth));

            ToTest.AddItem(LeatherItem);

            var firstBag = ToTest.Bags[0];
            Assert.AreEqual(firstBag.Items.Count, 1);
            Assert.IsTrue(firstBag.Items.Contains(LeatherItem));

            var secondBag = ToTest.Bags[1];
            Assert.AreEqual(secondBag.Items.Count, 0);
        }

        [TestMethod]
        public void Items_added_to_full_bags_should_not_be_stored()
        {
            ToTest.AddBag(new StorageBag(0));

            ToTest.AddItem(LeatherItem);

            var firstBag = ToTest.Bags[0];
            Assert.AreEqual(firstBag.Items.Count, 0);
        }
    }
}
