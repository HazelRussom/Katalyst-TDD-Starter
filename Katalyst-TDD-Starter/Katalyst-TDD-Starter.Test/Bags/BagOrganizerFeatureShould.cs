using Katalyst_TDD_Starter.Bags;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Katalyst_TDD_Starter.Test.Bags
{
    [TestClass]
    public class BagOrganizerFeatureShould
    {
        [TestMethod]
        public void Organise_bags()
        {
            // Arrange :
            // Create bag with no category
            var defaultBag = new Bag();
            // Create bag with one of each category
            var clothBag = new Bag(ItemCategory.Cloth);
            var herbBag = new Bag(ItemCategory.Herb);
            var metalBag = new Bag(ItemCategory.Metal);
            var weaponBag = new Bag(ItemCategory.Weapon);
            // Create bag belt to hold bags
            var bagBelt = new BagBelt();
            bagBelt.AddBag(defaultBag);
            bagBelt.AddBag(clothBag);
            bagBelt.AddBag(herbBag);
            bagBelt.AddBag(metalBag);
            bagBelt.AddBag(weaponBag);
            // Add items of each category to bags
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
            var goldItem3 = new Item("Gold", ItemCategory.Metal);
            var silverItem = new Item("Silver", ItemCategory.Metal);

            var axeItem = new Item("Axe", ItemCategory.Weapon);
            var maceItem = new Item("Mace", ItemCategory.Weapon);

            bagBelt.AddItem(leatherItem);
            bagBelt.AddItem(linenItem);
            bagBelt.AddItem(silkItem);
            bagBelt.AddItem(woolItem);
            bagBelt.AddItem(cherryBlossomItem);
            bagBelt.AddItem(marigoldItem);
            bagBelt.AddItem(roseItem);
            bagBelt.AddItem(copperItem);
            bagBelt.AddItem(goldItem1);
            bagBelt.AddItem(goldItem2);
            bagBelt.AddItem(goldItem3);
            bagBelt.AddItem(silverItem);
            bagBelt.AddItem(axeItem);
            bagBelt.AddItem(maceItem);


            // Act:
            // Call method to organise bags
            bagBelt.Organise();

            // Assert:
            // Find how to see contents of bags
            // Verify each bag contains expected items
            // Verify each bag contains items in alphabetical order
        }
    }
}
