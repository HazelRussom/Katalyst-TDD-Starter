namespace Katalyst_TDD_Starter.Bags
{
    public class Item
    {
        private string name;
        private ItemCategory category;

        public Item(string name, ItemCategory category)
        {
            this.name = name;
            this.category = category;
        }
    }
}