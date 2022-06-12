using Katalyst_TDD_Starter.Bags;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Katalyst_TDD_Starter.Test.Bags
{
    [TestClass]
    public class StorageBagTests
    {
        public Item LeatherItem { get; }
        public Item SilkItem { get; }
        public Item CopperItem { get; }

        public StorageBagTests()
        {
            LeatherItem = new Item("Leather", ItemCategory.Cloth);
            SilkItem = new Item("Silk", ItemCategory.Cloth);
            CopperItem = new Item("Copper", ItemCategory.Metal);
        }

        [TestMethod]
        [DataRow("Leather", ItemCategory.Cloth)]
        [DataRow("Silk", ItemCategory.Cloth)]
        [DataRow("Copper", ItemCategory.Metal)]
        public void Single_items_should_be_added_to_bag(string name, ItemCategory category)
        {
            var bag = new StorageBag(1);

            var item = new Item(name, category);
            bag.Add(item);

            Assert.IsTrue(bag.Items.Contains(item));
        }

        [TestMethod]
        public void Bag_should_retain_previously_added_items()
        {
            var bag = new StorageBag(4);

            bag.Add(LeatherItem);
            bag.Add(SilkItem);
            bag.Add(CopperItem);

            Assert.IsTrue(bag.Items.Contains(LeatherItem));
            Assert.IsTrue(bag.Items.Contains(SilkItem));
            Assert.IsTrue(bag.Items.Contains(CopperItem));
        }

        [TestMethod]
        public void Bag_should_be_able_to_add_multiple_items_at_once()
        {
            var bag = new StorageBag(4);

            bag.Add(new List<Item> { LeatherItem, SilkItem, CopperItem});

            Assert.IsTrue(bag.Items.Contains(LeatherItem));
            Assert.IsTrue(bag.Items.Contains(SilkItem));
            Assert.IsTrue(bag.Items.Contains(CopperItem));
        }

        [TestMethod]
        public void Bags_should_be_able_to_hold_as_many_items_as_their_storage_limit()
        {
            var limit = 4;
            var bag = new StorageBag(limit);

            for(int i = 0; i < limit; i++)
            {
                bag.Add(new Item("Leather", ItemCategory.Cloth));
            }

            Assert.IsTrue(bag.Items.Count == limit);
        }

        [TestMethod]
        public void Bag_contents_should_be_alphebatised_after_ordering()
        {
            var bag = new StorageBag(4);

            bag.Add(new List<Item> { LeatherItem, SilkItem, CopperItem });

            bag.Organise();

            Assert.AreEqual(bag.Items[0], CopperItem);
            Assert.AreEqual(bag.Items[1], LeatherItem);
            Assert.AreEqual(bag.Items[2], SilkItem);
        }

        [TestMethod]
        [DataRow (ItemCategory.NotSpecified)]
        [DataRow (ItemCategory.Cloth)]
        public void Bags_can_be_set_with_item_category(ItemCategory category)
        {
            var bag = new StorageBag(4, category);

            Assert.AreEqual(bag.Category, category);
        }
    }
}
