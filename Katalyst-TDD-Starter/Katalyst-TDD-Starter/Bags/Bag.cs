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
        protected virtual List<Item> Items { get; } = new();

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
            Items.Add(itemToAdd);
        }

        public IReadOnlyCollection<Item> GetItems()
        {
            throw new NotImplementedException();
        }

        public bool HasSpace()
        {
            return Items.Count < size;
        }
    }
}