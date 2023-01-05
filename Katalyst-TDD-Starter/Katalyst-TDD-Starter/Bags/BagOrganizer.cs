namespace Katalyst_TDD_Starter.Bags
{
    public interface IBagOrganizer
    {
        void Organize(List<IBag> expectedBags);
    }

    public class BagOrganizer : IBagOrganizer
    {
        public void Organize(List<IBag> bagsToOrganize)
        {
            throw new NotImplementedException();
            //var takenItems = _storedBags[0].TakeAllItems();

            //foreach (var item in takenItems)
            //{
            //    var firstClothBag = _storedBags.Where(x => x.GetCategory() == ItemCategory.Cloth && x.HasSpace()).FirstOrDefault();
            //    if (firstClothBag != null)
            //    {
            //        firstClothBag.AddItem(item);
            //    } 
            //}
        }
    }
}