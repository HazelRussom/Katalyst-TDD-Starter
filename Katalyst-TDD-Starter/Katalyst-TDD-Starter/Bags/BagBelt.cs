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
            var unsortedCloth = Bags[0].Items.Where(x => x.Category == ItemCategory.Cloth).ToList();
            var clothBag = Bags.Where(x => x.Category == ItemCategory.Cloth).First();

            foreach(var item in unsortedCloth)
            {
                clothBag.Items.Add(item);
                Bags[0].Remove(item);
            }

        }
    }
}