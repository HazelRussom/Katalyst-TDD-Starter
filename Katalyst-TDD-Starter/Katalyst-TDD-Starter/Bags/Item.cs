namespace Katalyst_TDD_Starter.Bags
{
    public class Item
    {
        private readonly string name;
        private readonly ItemCategory category;

        public Item(string name, ItemCategory category)
        {
            this.name = name;
            this.category = category;
        }

        internal string GetName()
        {
            return name;
        }

        internal ItemCategory GetCategory()
        {
            return category;
        }
    }
}