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
            var underTest = new Bag(4);
            underTest.AddItem(testItem);
            underTest.AddItem(testItem);
            underTest.AddItem(testItem);


            Assert.IsTrue(underTest.HasSpace());
        }

        [TestMethod]
        public void Not_have_space()
        {
            var underTest = new Bag(1);
            underTest.AddItem(new Item(string.Empty, ItemCategory.Cloth));

            Assert.IsFalse(underTest.HasSpace());
        }

        [TestMethod]
        public void Add_an_item()
        {
            var underTest = new Bag(1);
            var expectedItem = new Item(string.Empty, ItemCategory.Cloth);

            underTest.AddItem(expectedItem);

            var storedItems = underTest.GetItems();
            Assert.AreEqual(expectedItem, storedItems[0]);
            Assert.AreEqual(1, storedItems.Count);
        }

        [TestMethod]
        public void Add_multiple_items()
        {
            var underTest = new Bag(4);
            var expectedItem1 = new Item("1", ItemCategory.Cloth);
            var expectedItem2 = new Item("2", ItemCategory.Metal);

            underTest.AddItem(expectedItem1);
            underTest.AddItem(expectedItem2);

            var storedItems = underTest.GetItems();
            Assert.AreEqual(expectedItem1, storedItems[0]);
            Assert.AreEqual(expectedItem2, storedItems[1]);
            Assert.AreEqual(2, storedItems.Count);
        }

        [TestMethod]
        public void Not_add_item_when_bag_is_full()
        {
            var underTest = new Bag(1);
            var expectedItem1 = new Item("1", ItemCategory.Cloth);
            var expectedItem2 = new Item("2", ItemCategory.Metal);

            underTest.AddItem(expectedItem1);

            var exception = Assert.ThrowsException<BagException>(() =>
                underTest.AddItem(expectedItem2));

            Assert.AreEqual("This bag is full, no more items can be added!", exception.Message);

            var storedItems = underTest.GetItems();
            Assert.AreEqual(expectedItem1, storedItems[0]);
            Assert.AreEqual(1, storedItems.Count);
        }

        [TestMethod]
        public void Get_items_from_bag()
        {
            var underTest = new Bag(4);
            var firstItem = new Item("First", ItemCategory.Cloth);
            var secondItem = new Item("Second", ItemCategory.Herb);
            underTest.AddItem(firstItem);
            underTest.AddItem(secondItem);
            var expectedItems = new List<Item> { firstItem, secondItem };

            var actualItems = underTest.GetItems();

            Assert.AreEqual(expectedItems.Count, actualItems.Count);
            Assert.AreEqual(expectedItems[0], actualItems[0]);
            Assert.AreEqual(expectedItems[1], actualItems[1]);
        }
    }
}
