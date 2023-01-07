namespace Katalyst_TDD_Starter.Bags
{
    public interface IBag
    {
        void AddItem(Item itemToAdd);
        bool HasSpace();
        List<Item> TakeAllItems();
        ItemCategory GetCategory();
    }

    public class Bag : IBag
    {
        private readonly int size;
        private readonly ItemCategory category;
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

        public ItemCategory GetCategory()
        {
            return category;
        }

        public bool HasSpace()
        {
            return Items.Count < size;
        }

        public IReadOnlyList<Item> GetItems()
        {
            return Items;
        }

        public void AddItem(Item itemToAdd)
        {
            if (!HasSpace())
            {
                throw new BagException("This bag is full, no more items can be added!");
            }

            Items.Add(itemToAdd);
        }

        public List<Item> TakeAllItems()
        {
            var itemsToReturn = new List<Item>(Items);
            Items.Clear();
            return itemsToReturn;
        }
    }
}