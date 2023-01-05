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
            var secondBag = new Mock<IBag>();
            var thirdBag = new Mock<IBag>();
            var bags = new List<IBag> { firstBag.Object, secondBag.Object, thirdBag.Object };

            underTest.Organize(bags);

            firstBag.Verify(x => x.TakeAllItems(), Times.Once);
            secondBag.Verify(x => x.TakeAllItems(), Times.Once);
            thirdBag.Verify(x => x.TakeAllItems(), Times.Once);
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
