namespace Katalyst_TDD_Starter.Bags
{
    public class BagBelt
    {
        private readonly List<IBag> _storedBags;
        private const string FullBagsErrorMessage = "All bags are full, no more items can be added!";

        public BagBelt()
        {
            _storedBags = new List<IBag>();
        }

        public IReadOnlyCollection<IBag> GetBags()
        {
            return _storedBags;
        }
        
        public void AddBag(IBag bagToAdd)
        {
            _storedBags.Add(bagToAdd);
        }

        public void AddItem(Item itemToAdd)
        {
            var openBags = _storedBags.Where(x => x.HasSpace());

            if(!openBags.Any())
            {
                throw new BagException(FullBagsErrorMessage);
            }

            openBags.First().AddItem(itemToAdd);
        }

        public void Organise()
        {
            throw new NotImplementedException();
        }

        public List<Item> ItemsInBag(int bagIndex)
        {
            throw new NotImplementedException();
        }
    }
}