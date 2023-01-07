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
            var allItems = new List<Item>();
            foreach(var bag in bagsToOrganize)
            {
                allItems.AddRange(bag.TakeAllItems());
            }

            allItems = allItems.OrderBy(x => x.GetName()).ToList();

            foreach(var item in allItems)
            {
                var bagsWithSpace = bagsToOrganize.Where(x => x.HasSpace());
                var categoryBag = bagsWithSpace.Where(x => x.GetCategory() == item.GetCategory()).FirstOrDefault();
                
                if(categoryBag != null)
                {
                    categoryBag.AddItem(item);
                    continue;
                }

                bagsWithSpace.First().AddItem(item);
            }
        }
    }
}