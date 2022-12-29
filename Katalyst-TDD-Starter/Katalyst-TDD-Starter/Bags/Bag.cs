namespace Katalyst_TDD_Starter.Bags
{
    public interface IBag
    {
        public List<Item> Items { get; }

        void AddItem(Item itemToAdd);
        bool HasSpace();
    }

    public class Bag : IBag
    {
        private readonly int size;
        private ItemCategory category;
        public virtual List<Item> Items { get; set; } = new();

        public Bag(int size)
        {
            this.size = size;
        }

        public Bag(ItemCategory category, int size)
        {
            this.category = category;
            this.size = size;
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