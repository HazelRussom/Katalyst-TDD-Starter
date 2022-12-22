using Katalyst_TDD_Starter.Bags;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Katalyst_TDD_Starter.Test.Bags
{
    [TestClass]
    public class BagShould
    {
        [TestMethod]
        public void Have_space_for_an_empty_bag()
        {
            var underTest = new Bag(1);

            Assert.IsTrue(underTest.HasSpace());
        }

        [TestMethod]
        public void Have_space_for_a_bag_with_some_items()
        {
            var testItem = new Item(string.Empty, ItemCategory.Cloth);
            var items = new List<Item> { testItem, testItem, testItem };
            var underTest = new TestableBag(4, items);

            Assert.IsTrue(underTest.HasSpace());
        }

        [TestMethod]
        public void Not_have_space()
        {
            var items = new List<Item> { new Item(string.Empty, ItemCategory.Cloth) };
            var underTest = new TestableBag(1, items);

            Assert.IsFalse(underTest.HasSpace());
        }

        [TestMethod]
        public void Add_an_item()
        {
            var underTest = new TestableBag(1, new List<Item>());
            var expectedItem = new Item(string.Empty, ItemCategory.Cloth);

            underTest.AddItem(expectedItem);

            var storedItems = underTest.GetItems();
            Assert.IsTrue(storedItems.Contains(expectedItem));
            Assert.AreEqual(1, storedItems.Count);
        }

        //Add multiple items

        private class TestableBag : Bag
        {
            public TestableBag(int size, List<Item> items) : base(size)
            {
                Items = items;
            }

            public new List<Item> GetItems() { return Items; }

            protected override List<Item> Items { get; }
        }
    }
}
