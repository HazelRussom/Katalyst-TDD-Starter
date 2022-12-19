namespace Katalyst_TDD_Starter.Bags
{
    public interface IBag
    {
        void AddItem(Item itemToAdd);
    }

    public class Bag : IBag
    {
        private ItemCategory category;

        public Bag()
        {
        }

        public Bag(ItemCategory category)
        {
            this.category = category;
        }

        public void AddItem(Item itemToAdd)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyCollection<Item> GetItems()
        {
            throw new NotImplementedException();
        }
    }
}