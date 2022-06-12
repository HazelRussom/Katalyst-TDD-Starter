namespace Katalyst_TDD_Starter.Test.Bags
{
    public class Item
    {
        public string Name { get; set; }

        public ItemCategory Category { get; set; }

        public Item(string name, ItemCategory category)
        {
            Name = name;
            Category = category;
        }
    }
}