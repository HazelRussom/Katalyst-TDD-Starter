namespace Katalyst_TDD_Starter.Bags
{
    public interface IBag
    {
        void AddItem(Item itemToAdd);
        bool HasSpace();
    }

    public class Bag : IBag
    {
        private readonly int size;
        private ItemCategory category;

        public Bag(int size)
        {
            this.size = size;
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

        public bool HasSpace()
        {
            return true;
        }
    }
}