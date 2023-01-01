namespace Katalyst_TDD_Starter.Bags
{
    public interface IBag
    {
        void AddItem(Item itemToAdd);
        bool HasSpace();
        object SortItems();
        void Organise();
        ItemCategory GetCategory();
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

        public object SortItems()
        {
            throw new NotImplementedException();
        }

        public void Organise()
        {
            throw new NotImplementedException();
        }

        public ItemCategory GetCategory()
        {
            throw new NotImplementedException();
        }

        public List<Item> TakeAllItems()
        {
            throw new NotImplementedException();
        }
    }
}