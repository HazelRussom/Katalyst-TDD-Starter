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
            InitialiseBag(1, ItemCategory.Cloth);
            InitialiseBag(1, ItemCategory.Metal);
            InitialiseBag(1, ItemCategory.Herb);
            InitialiseBag(4, category);

            ToTest.AddItem(new Item("Test", category));
            ToTest.AddItem(new Item("Test2", category));

            ToTest.OrganiseBags();

            var categoryBags = ToTest.Bags.Where(x => x.Category == category).ToList();

            Assert.IsFalse(categoryBags[0].HasSpace());
            Assert.AreEqual(categoryBags[1].Items.Count, 1);

            var nonCategoryBags = ToTest.Bags.Where(x => x.Category != category).ToList();
            foreach(var bag in nonCategoryBags)
            {
                Assert.IsFalse(bag.Items.Any());
            }
        }

        [TestMethod]
        public void Items_should_enter_the_first_open_bag_when_category_bags_are_full()
        {
            InitialiseBag(8);
            InitialiseBag(1, ItemCategory.Cloth);

            ToTest.AddItem(new Item("Test", ItemCategory.Cloth));
            ToTest.AddItem(new Item("Test2", ItemCategory.Cloth));

            ToTest.OrganiseBags();

            Assert.IsFalse(ToTest.Bags[1].HasSpace());
            Assert.AreEqual(ToTest.Bags[0].Items.Count, 1);
        }

        [TestMethod]
        [Ignore]
        public void Organisation_should_work_for_multiple_categories_at_once()
        {
            var unspecifiedBag = new StorageBag(2);
            var clothBag = new StorageBag(1, ItemCategory.Cloth);
            var metalBag = new StorageBag(4, ItemCategory.Metal);

            ToTest.AddBag(unspecifiedBag);
            ToTest.AddBag(clothBag);
            ToTest.AddBag(metalBag);

            ToTest.AddItem(CopperItem);
            ToTest.AddItem(CopperItem);
            ToTest.AddItem(CopperItem);
            ToTest.AddItem(LeatherItem);
            ToTest.AddItem(LeatherItem);

            ToTest.OrganiseBags();

            Assert.IsTrue(unspecifiedBag.Items.Count == 1);
            Assert.IsTrue(unspecifiedBag.Items.All(x => x.Category == ItemCategory.Cloth));

            Assert.IsFalse(clothBag.Items.Count == 1);
            Assert.IsTrue(clothBag.Items.All(x => x.Category == ItemCategory.Cloth));

            Assert.IsFalse(metalBag.Items.Count == 3);
            Assert.IsTrue(metalBag.Items.All(x => x.Category == ItemCategory.Metal));
        }
    }
}
