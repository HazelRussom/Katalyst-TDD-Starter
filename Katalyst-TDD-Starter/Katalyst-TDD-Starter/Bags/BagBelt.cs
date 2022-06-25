using Katalyst_TDD_Starter.Test.Bags;

namespace Katalyst_TDD_Starter.Bags
{
    public class BagBelt
    {
        public List<StorageBag> Bags { get; set; } = new();

        public void AddBag(StorageBag input)
        {
            Bags.Add(input);
        }

        public void AddItem(Item item)
        {
            var openBags = Bags.Where(x => x.HasSpace()).ToList();
            if (openBags.Any())
            {
                openBags.First().Add(item);
                return;
            }
        }

        public void OrganiseBags()
        {
            // Get all items that are in the wrong bag
            // Remove items from their bags
            // Store locally
            // Put each item into the correct bag
            //var clothBags = Bags.Where(x => x.Category == ItemCategory.Cloth);

            //if (clothBags.Count() > 0)
            //{
            //    var unsortedCloth = new List<Item>();
            //    foreach (StorageBag bag in Bags)
            //    {
            //        var currentUnsortedItems = bag.Items.Where(x => x.Category != bag.Category && x.Category == ItemCategory.Cloth).ToList();
            //        bag.Remove(currentUnsortedItems);
            //        unsortedCloth.AddRange(currentUnsortedItems);
            //    }

            //}

            //if(Bags.Any(x => x.Category == ItemCategory.Cloth && x.HasSpace()))
            //{

            //}

            var unsortedCloth = Bags[0].Items.Where(x => x.Category == ItemCategory.Cloth).ToList();
            var clothBag = Bags.Where(x => x.Category == ItemCategory.Cloth).First();

            foreach (var item in unsortedCloth)
            {
                clothBag.Items.Add(item);
                Bags[0].Remove(item);
            }

            var unsortedMetal = Bags[0].Items.Where(x => x.Category == ItemCategory.Metal).ToList();
            var metalBag = Bags.Where(x => x.Category == ItemCategory.Metal).FirstOrDefault();

            if (metalBag != null)
            {
                foreach (var item in unsortedMetal)
                {
                    metalBag.Items.Add(item);
                    Bags[0].Remove(item);
                }
            }

            var unsortedHerbs = Bags[0].Items.Where(x => x.Category == ItemCategory.Herb).ToList();
            var herbBag = Bags.Where(x => x.Category == ItemCategory.Herb).FirstOrDefault();

            if (herbBag != null)
            {
                foreach (var item in unsortedHerbs)
                {
                    herbBag.Items.Add(item);
                    Bags[0].Remove(item);
                }
            }
        }
    }
}