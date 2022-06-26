using Katalyst_TDD_Starter.Bags;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Katalyst_TDD_Starter.Test.Bags
{
    [TestClass]
    public class BagBeltTests
    {
        public BagBelt ToTest { get; private set; }
        public Item LeatherItem { get; }
        public Item LinenItem { get; }
        public Item CopperItem { get; }

        public BagBeltTests()
        {
            ToTest = new BagBelt();
            
            LeatherItem = new Item("Leather", ItemCategory.Cloth);
            LinenItem = new Item("Linen", ItemCategory.Cloth);

            CopperItem = new Item("Copper", ItemCategory.Metal);
        }

        private void InitialiseBag(int size)
        {
            ToTest.AddBag(new StorageBag(size));
        }

        private void InitialiseBag(int size, ItemCategory category)
        {
            ToTest.AddBag(new StorageBag(size, category));
        }

        [TestMethod]
        [DataRow (1)]
        [DataRow (2)]
        [DataRow (4)]
        public void Bag_belt_can_hold_bags(int numberOfBags)
        {
            for (int i = 0; i < numberOfBags; i++)
            {
                InitialiseBag(1);
            }

            Assert.IsTrue(ToTest.Bags.Count == numberOfBags);
        }

        [TestMethod]
        public void Bag_belt_can_add_items_to_held_bags()
        {
            InitialiseBag(4);

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
                InitialiseBag(1);
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
            InitialiseBag(1);
            InitialiseBag(1, ItemCategory.Cloth);

            ToTest.AddItem(LeatherItem);

            var firstBag = ToTest.Bags[0];
            Assert.AreEqual(firstBag.Items.Count, 1);
            Assert.IsTrue(firstBag.Items.Contains(LeatherItem));

            var secondBag = ToTest.Bags[1];
            Assert.AreEqual(secondBag.Items.Count, 0);
        }

        [TestMethod]
        public void When_all_bags_are_full_new_items_should_not_be_stored()
        {
            InitialiseBag(0);

            ToTest.AddItem(LeatherItem);

            var firstBag = ToTest.Bags[0];
            Assert.AreEqual(firstBag.Items.Count, 0);
        }

        [TestMethod]
        [DataRow (ItemCategory.Cloth)]
        [DataRow (ItemCategory.Metal)]
        [DataRow (ItemCategory.Herb)]
        public void Items_should_be_organised_into_their_category_bag(ItemCategory category)
        {
            InitialiseBag(8);
            InitialiseBag(4, ItemCategory.Cloth);
            InitialiseBag(4, ItemCategory.Metal);
            InitialiseBag(4, ItemCategory.Herb);

            var testItem = new Item("Test", category);

            ToTest.AddItem(testItem);

            ToTest.OrganiseBags();

            var categoryBag = ToTest.Bags.Where(x => x.Category == category).First();
            Assert.AreEqual(categoryBag.Items.Count, 1);
            Assert.IsTrue(categoryBag.Items.Contains(testItem));
        }

        [TestMethod]
        [DataRow(ItemCategory.Cloth)]
        [DataRow(ItemCategory.Metal)]
        [DataRow(ItemCategory.Herb)]
        public void Items_should_not_overfill_their_category_bags(ItemCategory category)
        {
            InitialiseBag(8);
            InitialiseBag(1, category);
            InitialiseBag(4, category);

            ToTest.AddItem(new Item("Test", category));
            ToTest.AddItem(new Item("Test2", category));

            ToTest.OrganiseBags();

            var categoryBags = ToTest.Bags.Where(x => x.Category == category).ToList();

            Assert.IsFalse(categoryBags[0].HasSpace());
            Assert.AreEqual(categoryBags[1].Items.Count, 1);
        }
    }
}
