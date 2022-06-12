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
        [Ignore]
        public void Bag_belt_can_add_items_to_held_bags()
        {
            ToTest.AddBag(new StorageBag(4));

            //ToTest.AddItem(new Item("Leather", ItemCategory.Cloth);

            //var firstBag = ToTest.Bags[0];
            //Assert.AreEqual(firstBag.Items.Count, 1);
            //Assert.IsTrue(firstBag.Items.Contains("Leather"));
        }

        [TestMethod]
        [Ignore]
        public void Adding_items_should_not_exceed_any_held_bag_size_limits()
        {
            ToTest.AddBag(new StorageBag(1));
            ToTest.AddBag(new StorageBag(1));

            ToTest.AddItem(new Item("Leather", ItemCategory.Cloth));
            //ToTest.AddItem("Copper");

            //var firstBag = ToTest.Bags[0];
            //Assert.AreEqual(firstBag.Items.Count, 1);
            //Assert.IsTrue(firstBag.Items.Contains("Leather"));

            //var secondBag = ToTest.Bags[1];
            //Assert.AreEqual(secondBag.Items.Count, 1);
            //Assert.IsTrue(secondBag.Items.Contains("Copper"));
        }

        [TestMethod]
        public void Items_should_be_put_into_open_bags_of_same_category()
        {
            ToTest.AddBag(new StorageBag(1));
            ToTest.AddBag(new StorageBag(1, ItemCategory.Cloth));

            var item = new Item("Leather", ItemCategory.Cloth);

            ToTest.AddItem(item);

            var firstBag = ToTest.Bags[0];
            Assert.AreEqual(firstBag.Items.Count, 0);

            var secondBag = ToTest.Bags[1];
            Assert.AreEqual(secondBag.Items.Count, 1);
            Assert.IsTrue(secondBag.Items.Contains(item));
        }
    }
}
