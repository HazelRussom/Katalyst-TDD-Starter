using Katalyst_TDD_Starter.Bags;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Katalyst_TDD_Starter.Test.Bags
{
    [TestClass]
    public class BagShould
    {
        private readonly Bag _underTest;
        private readonly Item _clothTestItem;
        private readonly Item _herbTestItem;

        public BagShould()
        {
            _underTest = new Bag(4);
            _clothTestItem = new Item("Cloth Item", ItemCategory.Cloth);
            _herbTestItem = new Item("Herb Item", ItemCategory.Herb);
        }

        [TestMethod]
        public void Have_space_for_an_empty_bag()
        {
            var underTest = new Bag(1);

            Assert.IsTrue(underTest.HasSpace());
        }

        [TestMethod]
        public void Have_space_for_a_bag_with_some_items()
        {
            _underTest.AddItem(_clothTestItem);
            _underTest.AddItem(_herbTestItem);


            Assert.IsTrue(_underTest.HasSpace());
        }

        [TestMethod]
        public void Not_have_space()
        {
            var underTest = new Bag(1);
            underTest.AddItem(_clothTestItem);

            Assert.IsFalse(underTest.HasSpace());
        }

        [TestMethod]
        public void Add_an_item()
        {
            var underTest = new Bag(1);

            underTest.AddItem(_clothTestItem);

            var storedItems = underTest.GetItems();
            Assert.AreEqual(_clothTestItem, storedItems[0]);
            Assert.AreEqual(1, storedItems.Count);
        }

        [TestMethod]
        public void Add_multiple_items()
        {

            _underTest.AddItem(_clothTestItem);
            _underTest.AddItem(_herbTestItem);

            var storedItems = _underTest.GetItems();
            Assert.AreEqual(_clothTestItem, storedItems[0]);
            Assert.AreEqual(_herbTestItem, storedItems[1]);
            Assert.AreEqual(2, storedItems.Count);
        }

        [TestMethod]
        public void Not_add_item_when_bag_is_full()
        {
            var underTest = new Bag(1);
            underTest.AddItem(_clothTestItem);

            var exception = Assert.ThrowsException<BagException>(() =>
                underTest.AddItem(_herbTestItem));

            Assert.AreEqual("This bag is full, no more items can be added!", exception.Message);
            var storedItems = underTest.GetItems();
            Assert.AreEqual(_clothTestItem, storedItems[0]);
            Assert.AreEqual(1, storedItems.Count);
        }

        [TestMethod]
        public void Get_items_from_bag()
        {
            _underTest.AddItem(_clothTestItem);
            _underTest.AddItem(_herbTestItem);
            var expectedItems = new List<Item> { _clothTestItem, _herbTestItem };

            var actualItems = _underTest.GetItems();

            Assert.AreEqual(expectedItems.Count, actualItems.Count);
            Assert.AreEqual(expectedItems[0], actualItems[0]);
            Assert.AreEqual(expectedItems[1], actualItems[1]);
        }

        [TestMethod]
        public void Take_out_all_items()
        {
            _underTest.AddItem(_clothTestItem);
            _underTest.AddItem(_herbTestItem);
            var expectedTakenItems = new List<Item> { _clothTestItem, _herbTestItem };

            var takenItems = _underTest.TakeAllItems();
            var storedItems = _underTest.GetItems();

            Assert.AreEqual(0, storedItems.Count);
            Assert.AreEqual(expectedTakenItems.Count, takenItems.Count);
            Assert.AreEqual(expectedTakenItems[0], takenItems[0]);
            Assert.AreEqual(expectedTakenItems[1], takenItems[1]);

        }
    }
}
