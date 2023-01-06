using Katalyst_TDD_Starter.Bags;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace Katalyst_TDD_Starter.Test.Bags
{
    [TestClass]
    public class BagOrganizerShould
    {
        [TestMethod]
        public void Take_all_items_out_from_bags()
        {
            var underTest = new BagOrganizer();
            var firstBag = new Mock<IBag>();
            firstBag.Setup(x => x.TakeAllItems()).Returns(new List<Item>());
            var secondBag = new Mock<IBag>();
            secondBag.Setup(x => x.TakeAllItems()).Returns(new List<Item>());
            var thirdBag = new Mock<IBag>();
            thirdBag.Setup(x => x.TakeAllItems()).Returns(new List<Item>());
            var bags = new List<IBag> { firstBag.Object, secondBag.Object, thirdBag.Object };

            underTest.Organize(bags);

            firstBag.Verify(x => x.TakeAllItems(), Times.Once);
            secondBag.Verify(x => x.TakeAllItems(), Times.Once);
            thirdBag.Verify(x => x.TakeAllItems(), Times.Once);
        }

        [TestMethod]
        public void Move_single_cloth_item_into_cloth_bag()
        {
            var underTest = new BagOrganizer();
            var clothItem = new Item("ClothItem", ItemCategory.Cloth);
            var clothBag = new Mock<IBag>();
            clothBag.Setup(x => x.GetCategory()).Returns(ItemCategory.Cloth);
            clothBag.Setup(x => x.TakeAllItems()).Returns(new List<Item>());
            var defaultBag = new Mock<IBag>();
            defaultBag.Setup(x => x.GetCategory()).Returns(ItemCategory.NotSpecified);
            defaultBag.Setup(x => x.TakeAllItems()).Returns(new List<Item> { clothItem });
            var bags = new List<IBag> { defaultBag.Object, clothBag.Object };

            underTest.Organize(bags);

            defaultBag.Verify(x => x.AddItem(It.IsAny<Item>()), Times.Never);
            clothBag.Verify(x => x.AddItem(clothItem), Times.Once());
        }

        // What still needs doing?
        //TODO Move cloth item into cloth bag
        //TODO Don't move items from first bag (Only one bag? First bag is same category?)
        //TODO Don't put into full bag
        //TODO Moving multiple items
        //TODO Alphabetize takenItems instead of making bags do it?
        //TODO Item Categories other than Cloth
        //TODO Move organisation into a seperate class? Or make SortableItemList? 
    }
}
