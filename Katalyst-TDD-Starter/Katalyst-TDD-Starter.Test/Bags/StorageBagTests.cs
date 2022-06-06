using Katalyst_TDD_Starter.Bags;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Katalyst_TDD_Starter.Test.Bags
{
    [TestClass]
    public class StorageBagTests
    {
        [TestMethod]
        public void Leather_should_be_added_to_bag()
        {
            var bag = new StorageBag();
            var input = "Leather";

            bag.Add(input);

            Assert.IsTrue(bag.Items.Contains(input));
        }        
    }
}
