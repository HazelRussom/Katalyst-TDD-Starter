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
            var openCategoryBags = Bags.Where(x => x.Category == item.Category && x.HasSpace()).ToList();

            if (openCategoryBags.Any())
            {
                openCategoryBags.First().Add(item);
                return;
            }

            if (Bags[0].HasSpace())
            {
                Bags[0].Add(item);
                return;
            }

            Bags[1].Add(item);
        }
    }
}