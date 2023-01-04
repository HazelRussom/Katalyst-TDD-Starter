using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Katalyst_TDD_Starter.Test.Bags
{
    [TestClass]
    public class BagOrganizerShould
    {

    }

    //[TestMethod]
    //public void Tell_bags_to_organise()
    //{
    //    _underTest.AddBag(_bagWithoutSpace.Object);
    //    _underTest.AddBag(_bagWithSpace.Object);

    //    _underTest.Organise();

    //    _bagWithoutSpace.Verify(x => x.Organise(), Times.Once);
    //    _bagWithSpace.Verify(x => x.Organise(), Times.Once);
    //}

    //[TestMethod]
    //public void Move_cloth_item_into_second_slot_cloth_bag()
    //{
    //    var clothItem = new Item(string.Empty, ItemCategory.Cloth);

    //    var defaultBag = CreateBag(ItemCategory.NotSpecified);
    //    defaultBag.Setup(x => x.TakeAllItems()).Returns(new List<Item> { clothItem });
    //    _underTest.AddBag(defaultBag.Object);
    //    _underTest.AddBag(defaultBag.Object);
    //    var clothBag = CreateBag(ItemCategory.Cloth);
    //    _underTest.AddBag(clothBag.Object);

    //    _underTest.Organise();

    //    defaultBag.Verify(x => x.TakeAllItems(), Times.Once);
    //    clothBag.Verify(x => x.AddItem(clothItem), Times.Once);
    //}

    //[TestMethod]
    //public void Move_cloth_item_into_third_slot_cloth_bag()
    //{
    //    var clothItem = new Item(string.Empty, ItemCategory.Cloth);

    //    var defaultBag = CreateBag(ItemCategory.NotSpecified);
    //    defaultBag.Setup(x => x.TakeAllItems()).Returns(new List<Item> { clothItem });
    //    _underTest.AddBag(defaultBag.Object);
    //    var herbBag = CreateBag(ItemCategory.Herb);
    //    _underTest.AddBag(herbBag.Object);
    //    var clothBag = CreateBag(ItemCategory.Cloth);
    //    _underTest.AddBag(clothBag.Object);

    //    _underTest.Organise();

    //    defaultBag.Verify(x => x.TakeAllItems(), Times.Once);
    //    herbBag.Verify(x => x.AddItem(It.IsAny<Item>()), Times.Never);
    //    clothBag.Verify(x => x.AddItem(clothItem), Times.Once);
    //}

    //private static Mock<IBag> CreateBag(ItemCategory category)
    //{
    //    var bag = new Mock<IBag>();
    //    bag.Setup(x => x.HasSpace()).Returns(true);
    //    bag.Setup(x => x.GetCategory()).Returns(category);
    //    return bag;
    //}

    //[TestMethod]
    //public void Not_move_item_into_full_bag()
    //{
    //    var clothItem = new Item(string.Empty, ItemCategory.Cloth);
    //    _bagWithoutSpace.Setup(x => x.GetCategory()).Returns(ItemCategory.Cloth);
    //    var defaultBag = new Mock<IBag>();
    //    defaultBag.Setup(x => x.GetCategory()).Returns(ItemCategory.NotSpecified);
    //    defaultBag.Setup(x => x.TakeAllItems()).Returns(new List<Item> { clothItem });
    //    _underTest.AddBag(defaultBag.Object);
    //    _underTest.AddBag(_bagWithoutSpace.Object);

    //    _underTest.Organise();

    //    defaultBag.Verify(x => x.TakeAllItems(), Times.Once);
    //    _bagWithoutSpace.Verify(x => x.AddItem(It.IsAny<Item>()), Times.Never);
    //}

    //// What still needs doing?
    ////TODO Don't move items from first bag (Only one bag? First bag is same category?)
    ////TODO Don't put into full bag
    ////TODO Moving multiple items
    ////TODO Alphabetize takenItems instead of making bags do it?
    ////TODO Item Categories other than Cloth
    ////TODO Move organisation into a seperate class? Or make SortableItemList? 
}
