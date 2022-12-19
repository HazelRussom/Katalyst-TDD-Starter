using Katalyst_TDD_Starter.Bags;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Linq;

namespace Katalyst_TDD_Starter.Test.Bags
{
    [TestClass]
    public class BagBeltShould
    {
        [TestMethod]
        public void Start_with_no_bags()
        {
            var underTest = new BagBelt();

            Assert.IsFalse(underTest.GetBags().Any());
        }

        [TestMethod]
        public void Add_bags()
        {
            var underTest = new BagBelt();
            var firstBagToAdd = new Bag();
            var secondBagToAdd = new Bag(ItemCategory.Metal);

            underTest.AddBag(firstBagToAdd);
            underTest.AddBag(secondBagToAdd);

            var bags = underTest.GetBags();
            Assert.IsTrue(bags.Contains(firstBagToAdd));
            Assert.IsTrue(bags.Contains(secondBagToAdd));
            Assert.AreEqual(2, bags.Count);
        }

        [TestMethod]
        public void Add_item_to_empty_bag()
        {
            var underTest = new BagBelt();
            var bag = new Mock<IBag>();
            bag.Setup(x => x.HasSpace()).Returns(true);
            underTest.AddBag(bag.Object);
            var itemToAdd = new Item("TestItem", ItemCategory.Cloth);

            underTest.AddItem(itemToAdd);

            bag.Verify(x => x.AddItem(itemToAdd), Times.Once);
        }

        [TestMethod]
        public void Add_item_when_first_bag_is_full()
        {
            var underTest = new BagBelt();
            var fullBag = new Mock<IBag>();
            fullBag.Setup(x => x.HasSpace()).Returns(false);
            var emptyBag = new Mock<IBag>();
            emptyBag.Setup(x => x.HasSpace()).Returns(true);
            underTest.AddBag(fullBag.Object);
            underTest.AddBag(emptyBag.Object);
            
            var itemToAdd = new Item("TestItem", ItemCategory.Cloth);

            underTest.AddItem(itemToAdd);

            fullBag.Verify(x => x.AddItem(itemToAdd), Times.Never);
            emptyBag.Verify(x => x.AddItem(itemToAdd), Times.Once);
        }

        [TestMethod]
        public void Not_add_item_when_all_bags_are_full()
        {
            var underTest = new BagBelt();
            var fullBag = new Mock<IBag>();
            fullBag.Setup(x => x.HasSpace()).Returns(false);
            underTest.AddBag(fullBag.Object);

            var itemToAdd = new Item("TestItem", ItemCategory.Cloth);
            var exception = Assert.ThrowsException<BagException>(() => underTest.AddItem(itemToAdd));

            fullBag.Verify(x => x.AddItem(itemToAdd), Times.Never);
            Assert.AreEqual("All bags are full, no more items can be added!", exception.Message);
        }

        // Add item to bags where all are full -> Don't add item. Throw exception?
    }

}
