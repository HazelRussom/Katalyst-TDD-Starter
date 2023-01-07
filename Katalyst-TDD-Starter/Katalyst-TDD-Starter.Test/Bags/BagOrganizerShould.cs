using Katalyst_TDD_Starter.Bags;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace Katalyst_TDD_Starter.Test.Bags
{
    [TestClass]
    public class BagOrganizerShould
    {
        private readonly Mock<IBag> _defaultBag;
        private readonly Mock<IBag> _clothBag;
        private readonly Item _clothItem;
        private BagOrganizer _underTest;

        public BagOrganizerShould()
        {
            _underTest = new BagOrganizer();

            _defaultBag = new Mock<IBag>();
            _defaultBag.Setup(x => x.GetCategory()).Returns(ItemCategory.NotSpecified);
            _defaultBag.Setup(x => x.HasSpace()).Returns(true);

            _clothBag = new Mock<IBag>();
            _clothBag.Setup(x => x.GetCategory()).Returns(ItemCategory.Cloth);
            _clothBag.Setup(x => x.TakeAllItems()).Returns(new List<Item>());
            _clothBag.Setup(x => x.HasSpace()).Returns(true);

            _clothItem = new Item("ClothItem", ItemCategory.Cloth);
        }

        [TestMethod]
        public void Take_all_items_out_from_bags()
        {
            _defaultBag.Setup(x => x.TakeAllItems()).Returns(new List<Item>());
            var bags = new List<IBag> { _defaultBag.Object, _clothBag.Object };

            _underTest.Organize(bags);

            _defaultBag.Verify(x => x.TakeAllItems(), Times.Once);
            _clothBag.Verify(x => x.TakeAllItems(), Times.Once);
        }

        [TestMethod]
        public void Move_single_cloth_item_into_first_slot_cloth_bag()
        {
            _defaultBag.Setup(x => x.TakeAllItems()).Returns(new List<Item> { _clothItem });
            var bags = new List<IBag> { _clothBag.Object, _defaultBag.Object };

            _underTest.Organize(bags);

            _defaultBag.Verify(x => x.AddItem(It.IsAny<Item>()), Times.Never);
            _clothBag.Verify(x => x.AddItem(_clothItem), Times.Once());
        }

        [TestMethod]
        public void Move_single_cloth_item_into_second_slot_cloth_bag()
        {
            _defaultBag.Setup(x => x.TakeAllItems()).Returns(new List<Item> { _clothItem });
            var bags = new List<IBag> { _defaultBag.Object, _clothBag.Object };

            _underTest.Organize(bags);

            _defaultBag.Verify(x => x.AddItem(It.IsAny<Item>()), Times.Never);
            _clothBag.Verify(x => x.AddItem(_clothItem), Times.Once());
        }

        [TestMethod]
        public void Put_cloth_item_into_first_bag()
        {
            _defaultBag.Setup(x => x.TakeAllItems()).Returns(new List<Item> { _clothItem });
            var bags = new List<IBag> { _defaultBag.Object };

            _underTest.Organize(bags);

            _defaultBag.Verify(x => x.AddItem(_clothItem), Times.Once);
        }

        [TestMethod]
        public void Put_cloth_item_into_first_bag_with_space()
        {
            _defaultBag.Setup(x => x.TakeAllItems()).Returns(new List<Item> { _clothItem });
            _defaultBag.Setup(x => x.HasSpace()).Returns(false);
            _clothBag.Setup(x => x.HasSpace()).Returns(false);
            var herbBag = new Mock<IBag>();
            herbBag.Setup(x => x.GetCategory()).Returns(ItemCategory.Herb);
            herbBag.Setup(x => x.TakeAllItems()).Returns(new List<Item>());
            herbBag.Setup(x => x.HasSpace()).Returns(true);
            var bags = new List<IBag> { _defaultBag.Object, _clothBag.Object, herbBag.Object };

            _underTest.Organize(bags);

            _defaultBag.Verify(x => x.AddItem(It.IsAny<Item>()), Times.Never);
            _clothBag.Verify(x => x.AddItem(It.IsAny<Item>()), Times.Never);
            herbBag.Verify(x => x.AddItem(_clothItem), Times.Once);
        }

        [TestMethod]
        public void Move_two_cloth_items_to_cloth_bag()
        {
            _defaultBag.Setup(x => x.TakeAllItems()).Returns(new List<Item> { _clothItem, _clothItem });
            var bags = new List<IBag> { _defaultBag.Object, _clothBag.Object };

            _underTest.Organize(bags);

            _defaultBag.Verify(x => x.AddItem(It.IsAny<Item>()), Times.Never);
            _clothBag.Verify(x => x.AddItem(_clothItem), Times.Exactly(2));
        }

        [TestMethod]
        public void Organize_items_in_alphabetical_order()
        {
            _clothBag.SetupSequence(x => x.HasSpace()).Returns(true).Returns(false);
            var firstAlphabeticalItem = new Item("A", ItemCategory.Cloth);
            var secondAlphabeticalItem = new Item("B", ItemCategory.Cloth);
            _defaultBag.Setup(x => x.TakeAllItems()).Returns(new List<Item> { secondAlphabeticalItem, firstAlphabeticalItem });
            var bags = new List<IBag> { _defaultBag.Object, _clothBag.Object };

            _underTest.Organize(bags);

            _clothBag.Verify(x => x.AddItem(firstAlphabeticalItem));
            _defaultBag.Verify(x => x.AddItem(secondAlphabeticalItem));
        }

        // What still needs doing?
        //TODO Item Categories other than Cloth
    }
}
