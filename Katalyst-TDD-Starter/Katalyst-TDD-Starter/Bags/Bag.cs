namespace Katalyst_TDD_Starter.Bags
{
    public class Bag
    {
        private ItemCategory category;

        public Bag()
        {
        }

        public Bag(ItemCategory category)
        {
            this.category = category;
        }

        public IReadOnlyCollection<Item> GetItems()
        {
            throw new NotImplementedException();
        }
    }
}