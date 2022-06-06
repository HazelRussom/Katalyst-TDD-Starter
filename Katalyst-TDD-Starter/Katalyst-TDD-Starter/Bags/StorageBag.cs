namespace Katalyst_TDD_Starter.Bags
{
    public class StorageBag
    {
        public StorageBag()
        {
        }

        public List<string> Items { get; internal set; } = new();

        public void Add(string input)
        {
            Items.Add(input); 
        }
    }
}