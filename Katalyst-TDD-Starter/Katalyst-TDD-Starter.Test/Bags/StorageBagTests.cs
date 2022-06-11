using Katalyst_TDD_Starter.Bags;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Katalyst_TDD_Starter.Test.Bags
{
    [TestClass]
    public class StorageBagTests
    {
        [TestMethod]
        [DataRow("Leather")]
        [DataRow("Silk")]
        [DataRow("Copper")]
        public void Single_items_should_be_added_to_bag(string input)
        {
            var bag = new StorageBag(1);

            bag.Add(input);

            Assert.IsTrue(bag.Items.Contains(input));
        }

        [TestMethod]
        public void Bag_should_retain_previously_added_items()
        {
            var bag = new StorageBag(4);
            var item1 = "Leather";
            var item2 = "Silk";
            var item3 = "Copper";

            bag.Add(item1);
            bag.Add(item2);
            bag.Add(item3);

            Assert.IsTrue(bag.Items.Contains(item1));
            Assert.IsTrue(bag.Items.Contains(item2));
            Assert.IsTrue(bag.Items.Contains(item3));
        }

        [TestMethod]
        public void Bag_should_be_able_to_add_multiple_items_at_once()
        {
            var bag = new StorageBag(4);
            var item1 = "Leather";
            var item2 = "Silk";
            var item3 = "Copper";

            bag.Add(new List<string> { item1, item2, item3 });

            Assert.IsTrue(bag.Items.Contains(item1));
            Assert.IsTrue(bag.Items.Contains(item2));
            Assert.IsTrue(bag.Items.Contains(item3));
        }

        [TestMethod]
        public void Bags_should_be_able_to_hold_as_many_items_as_their_storage_limit()
        {
            var limit = 4;
            var bag = new StorageBag(limit);

            for(int i = 0; i < limit; i++)
            {
                bag.Add("Leather");
            }

            Assert.IsTrue(bag.Items.Count == limit);
        }

        [TestMethod]
        public void Bag_contents_should_be_alphebatised_after_ordering()
        {
            var bag = new StorageBag(4);
            var item1 = "Leather";
            var item2 = "Silk";
            var item3 = "Copper";

            bag.Add(new List<string> { item1, item2, item3 });

            bag.Organise();

            Assert.AreEqual(bag.Items[0], item3);
            Assert.AreEqual(bag.Items[1], item1);
            Assert.AreEqual(bag.Items[2], item2);
        }
    }
}
