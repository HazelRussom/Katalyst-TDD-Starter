# Bags Brainstorming
---

## Features:
### Objects:
*Bags* {
	Can have a Category
	Can contain *Items*
	Has a limit to the number of items it can contain
	Example has Backpack with 8, category bags with 4
}
*Items* {
	Must have a Category
	Must have a name
	Examples by Category: {
		Cloth: ["Leather", "Linen", "Silk", "Wool"],
		Herb : ["Cherry Blossom", "Marigold", "Rose", "Seaweed"],
		Metal : ["Copper", "Gold", "Iron", "Silver"],
		Weapon : ["Axe", "Dagger", "Mace", "Sword"]
	}
}
*Categories* {
	An enum?
	Examples: Cloth, Herb, Metal, Weapon
}

### Functionality:
Add items to a bag
Display items from a bag
Organise bags





### Dumping from Organizer class
  //[TestMethod]
        //public void Alphabetize_bag_contents()
        //{

        //    var underTest = new BagBeltOrganizer();

        //    var unsortedBagBelt = new BagBelt();
        //    var clothBag = new Bag(ItemCategory.Cloth, 4);
        //    unsortedBagBelt.AddBag(clothBag);
        //    var firstAlphabeticalItem = new Item("TestItem", ItemCategory.Cloth);
        //    var secondAlphabeticalItem = new Item("XTestItem", ItemCategory.Cloth);

        //    clothBag.AddItem(secondAlphabeticalItem);
        //    clothBag.AddItem(firstAlphabeticalItem);

        //    var bagBeltResult = underTest.Organize(unsortedBagBelt);
        //    var bagResult = bagBeltResult.GetBags()[0];

        //    Assert.AreEqual(firstAlphabeticalItem, bagResult.Items[0]);
        //    Assert.AreEqual(firstAlphabeticalItem, bagResult.Items[1]);
        //}

        // Organisation 
        // Move single item to category bag
        // Move multiple items to different category bags
        // Leave item in first bag when no category bag exists
        // Leave item in first bag when only full category bags exist
        // Alphabetize items in bags
        // Test for when all bags are full and unordered