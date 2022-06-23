using Katalyst_TDD_Starter.Test.Bags;

namespace Katalyst_TDD_Starter.Bags
{
    public class StorageBag
    {
        public StorageBag(int sizeLimt)
        {
            SizeLimit = sizeLimt;
        }

        public StorageBag(int sizeLimt, ItemCategory category) : this(sizeLimt)
        {
            Category = category;
        }

        public ItemCategory Category { get; set; }

        public List<Item> Items { get; internal set; } = new();

        public int SizeLimit { get; }

        public bool HasSpace()
        {
            return Items.Count < SizeLimit;
        }

        public void Add(Item item)
        {
            Items.Add(item);
        }

        public void Add(IList<Item> input)
        {
            Items.AddRange(input);
        }

        public void Organise()
        {
            Items = Items.OrderBy(x => x.Name).ToList();
        }

        public void Remove(Item itemToRemove)
        {
            Items.Remove(itemToRemove);
        }

        public void Remove(List<Item> itemsToRemove)
        {
            foreach(var item in itemsToRemove)
            {
                Remove(item);
            }
        }
    }
}