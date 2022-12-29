using Katalyst_TDD_Starter.Bags;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Katalyst_TDD_Starter.Test.Bags
{
    [TestClass]
    public class BagBeltOrganizerShould
    {

        [TestMethod]
        public void Alphabetize_bag_contents()
        {

            var underTest = new BagBeltOrganizer();

            var unsortedBagBelt = new BagBelt();
            var clothBag = new Bag(ItemCategory.Cloth, 4);
            unsortedBagBelt.AddBag(clothBag);
            var firstAlphabeticalItem = new Item("TestItem", ItemCategory.Cloth);
            var secondAlphabeticalItem = new Item("XTestItem", ItemCategory.Cloth);

            clothBag.AddItem(secondAlphabeticalItem);
            clothBag.AddItem(firstAlphabeticalItem);

            var bagBeltResult = underTest.Organize(unsortedBagBelt);
            var bagResult = bagBeltResult.GetBags()[0];

            Assert.AreEqual(firstAlphabeticalItem, bagResult.Items[0]);
            Assert.AreEqual(firstAlphabeticalItem, bagResult.Items[1]);
        }

        // Organisation 
        // Move single item to category bag
        // Move multiple items to different category bags
        // Leave item in first bag when no category bag exists
        // Leave item in first bag when only full category bags exist
        // Alphabetize items in bags
        // Test for when all bags are full and unordered
    }
}
