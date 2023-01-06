namespace Katalyst_TDD_Starter.Bags
{
    public interface IBag
    {
        void AddItem(Item itemToAdd);
        bool HasSpace();
        List<Item> TakeAllItems();
    }

    public class Bag : IBag
    {
        private readonly int size;
        private ItemCategory category;
        protected virtual List<Item> Items { get; set; } = new();

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
            if (!HasSpace())
            {
                throw new BagException("This bag is full, no more items can be added!");
            }

            Items.Add(itemToAdd);
        }

        public IReadOnlyList<Item> GetItems()
        {
            return Items;
        }

        public bool HasSpace()
        {
            return Items.Count < size;
        }

        public List<Item> TakeAllItems()
        {
            throw new NotImplementedException();
        }
    }
}