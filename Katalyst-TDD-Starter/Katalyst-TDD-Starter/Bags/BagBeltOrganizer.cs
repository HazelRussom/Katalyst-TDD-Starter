namespace Katalyst_TDD_Starter.Bags
{
    public class BagBeltOrganizer
    {
        public BagBeltOrganizer()
        {
        }

        public void Organize(BagBelt unsortedBagBelt)
        {
            var unorderedBagItems = unsortedBagBelt.GetBags()[0].SortItems();

        }
    }
}