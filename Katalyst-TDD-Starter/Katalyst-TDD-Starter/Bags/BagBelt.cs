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
            // Identify items in incorrect bags
            // Check for room in correct bags
            // If room exists:
            // - Remove from old bag
            // - Add to new bag
        }
    }
}