namespace Katalyst_TDD_Starter.Bags
{
    public class Item
    {
        public string name;
        private ItemCategory category;

        public Item(string name, ItemCategory category)
        {
            this.name = name;
            this.category = category;
        }

        internal ItemCategory GetCategory()
        {
            return category;
        }
    }
}