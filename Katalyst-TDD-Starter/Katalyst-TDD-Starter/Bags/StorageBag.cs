using Katalyst_TDD_Starter.Test.Bags;

namespace Katalyst_TDD_Starter.Bags
{
    public class StorageBag
    {
        public StorageBag(int sizeLimt)
        {
            SizeLimt = sizeLimt;
        }

        public StorageBag(int sizeLimt, ItemCategory category) : this(sizeLimt)
        {
            Category = category;
        }

        public ItemCategory Category { get; set; }

        public List<string> Items { get; internal set; } = new();

        public int SizeLimt { get; }

        public void Add(string input)
        {
            Items.Add(input);
        }

        public void Add(IList<string> input)
        {
            Items.AddRange(input);
        }

        public void Organise()
        {
            Items = Items.OrderBy(x => x).ToList();
        }
    }
}