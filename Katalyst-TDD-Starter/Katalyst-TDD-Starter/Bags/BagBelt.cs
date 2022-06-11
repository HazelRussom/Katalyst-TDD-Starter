namespace Katalyst_TDD_Starter.Bags
{
    public class BagBelt
    {
        public List<StorageBag> Bags { get; set; } = new();

        public void AddBag(StorageBag input)
        {
            Bags.Add(input);
        }

        public void AddItem(string item)
        {
            if (Bags[0].Items.Count < Bags[0].SizeLimt)
            {
                Bags[0].Add(item);
                return;
            }

            Bags[1].Add(item);
        }
    }
}