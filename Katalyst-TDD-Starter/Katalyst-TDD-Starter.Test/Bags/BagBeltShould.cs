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
        private readonly Item _testItem = new("TestItem", ItemCategory.Cloth);
        private readonly BagBelt _underTest = new();

        [TestMethod]
        public void Start_with_no_bags()
        {
            Assert.IsFalse(_underTest.GetBags().Any());
        }

        [TestMethod]
        public void Add_bags()
        {
            var firstBagToAdd = new Bag(4);
            var secondBagToAdd = new Bag(ItemCategory.Metal, 4);

            _underTest.AddBag(firstBagToAdd);
            _underTest.AddBag(secondBagToAdd);

            var bags = _underTest.GetBags();
            Assert.IsTrue(bags.Contains(firstBagToAdd));
            Assert.IsTrue(bags.Contains(secondBagToAdd));
            Assert.AreEqual(2, bags.Count);
        }

        [TestMethod]
        public void Add_item_to_empty_bag()
        {
            var bag = new Mock<IBag>();
            bag.Setup(x => x.HasSpace()).Returns(true);
            _underTest.AddBag(bag.Object);

            _underTest.AddItem(_testItem);

            bag.Verify(x => x.AddItem(_testItem), Times.Once);
        }

        [TestMethod]
        public void Add_item_when_first_bag_is_full()
        {
            var fullBag = new Mock<IBag>();
            fullBag.Setup(x => x.HasSpace()).Returns(false);
            _underTest.AddBag(fullBag.Object);
            var emptyBag = new Mock<IBag>();
            emptyBag.Setup(x => x.HasSpace()).Returns(true);
            _underTest.AddBag(emptyBag.Object);
            
            _underTest.AddItem(_testItem);

            fullBag.Verify(x => x.AddItem(_testItem), Times.Never);
            emptyBag.Verify(x => x.AddItem(_testItem), Times.Once);
        }

        [TestMethod]
        public void Not_add_item_when_all_bags_are_full()
        {
            var fullBag = new Mock<IBag>();
            fullBag.Setup(x => x.HasSpace()).Returns(false);
            _underTest.AddBag(fullBag.Object);

            var exception = Assert.ThrowsException<BagException>(() => _underTest.AddItem(_testItem));

            fullBag.Verify(x => x.AddItem(_testItem), Times.Never);
            Assert.AreEqual("All bags are full, no more items can be added!", exception.Message);
        }
    }

}
