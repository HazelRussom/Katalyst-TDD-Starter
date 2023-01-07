using Katalyst_TDD_Starter.Bags;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Katalyst_TDD_Starter.Test.Bags
{
    [TestClass]
    public class BagOrganizerFeatureShould
    {
        [TestMethod]
        public void Organise_bags()
        {
            // Arrange :
            // Create bag belt to hold one bag of each category
            BagBelt bagBelt = BuildBagBelt();

            var leatherItem = new Item("Leather", ItemCategory.Cloth);
            var linenItem = new Item("Linen", ItemCategory.Cloth);
            var silkItem = new Item("Silk", ItemCategory.Cloth);
            var woolItem = new Item("Wool", ItemCategory.Cloth);

            var cherryBlossomItem = new Item("Cherry Blossom", ItemCategory.Herb);
            var marigoldItem = new Item("Marigold", ItemCategory.Herb);
            var roseItem = new Item("Rose", ItemCategory.Herb);

            var copperItem = new Item("Copper", ItemCategory.Metal);
            var goldItem1 = new Item("Gold", ItemCategory.Metal);
            var goldItem2 = new Item("Gold", ItemCategory.Metal);
            var platinumItem = new Item("Platinum", ItemCategory.Metal);
            var silverItem = new Item("Silver", ItemCategory.Metal);

            var axeItem = new Item("Axe", ItemCategory.Weapon);
            var maceItem = new Item("Mace", ItemCategory.Weapon);

            // Add items of each category to bags
            bagBelt.AddItem(linenItem);
            bagBelt.AddItem(leatherItem);
            bagBelt.AddItem(woolItem);
            bagBelt.AddItem(silkItem);
            bagBelt.AddItem(roseItem);
            bagBelt.AddItem(cherryBlossomItem);
            bagBelt.AddItem(marigoldItem);
            bagBelt.AddItem(copperItem);
            bagBelt.AddItem(goldItem1);
            bagBelt.AddItem(goldItem2);
            bagBelt.AddItem(platinumItem);
            bagBelt.AddItem(silverItem);
            bagBelt.AddItem(maceItem);
            bagBelt.AddItem(axeItem);

            // Act:
            // Call method to organise bags
            bagBelt.Organize();

            // Assert:
            Assert.AreEqual(5, bagBelt.GetBags().Count);

            // Verify each bag contains expected items in alphabetical order
            var expectedBag1Contents = new List<Item> { silverItem };
            var expectedBag2Contents = new List<Item> { leatherItem, linenItem, silkItem, woolItem };
            var expectedBag3Contents = new List<Item> { cherryBlossomItem, marigoldItem, roseItem };
            var expectedBag4Contents = new List<Item> { copperItem, goldItem1, goldItem2, platinumItem };
            var expectedBag5Contents = new List<Item> { axeItem, maceItem };

            CollectionAssert.AreEqual(expectedBag1Contents, new List<Item>(bagBelt.GetItemsInBag(0)));
            CollectionAssert.AreEqual(expectedBag2Contents, new List<Item>(bagBelt.GetItemsInBag(1)));
            CollectionAssert.AreEqual(expectedBag3Contents, new List<Item>(bagBelt.GetItemsInBag(2)));
            CollectionAssert.AreEqual(expectedBag4Contents, new List<Item>(bagBelt.GetItemsInBag(3)));
            CollectionAssert.AreEqual(expectedBag5Contents, new List<Item>(bagBelt.GetItemsInBag(4)));
        }

        private static BagBelt BuildBagBelt()
        {
            var bagBelt = new BagBelt(new BagOrganizer());
            bagBelt.AddBag(new Bag(8));
            bagBelt.AddBag(new Bag(ItemCategory.Cloth, 4));
            bagBelt.AddBag(new Bag(ItemCategory.Herb, 4));
            bagBelt.AddBag(new Bag(ItemCategory.Metal, 4));
            bagBelt.AddBag(new Bag(ItemCategory.Weapon, 4));
            return bagBelt;
        }
    }
}
