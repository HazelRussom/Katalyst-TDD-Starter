using Katalyst_TDD_Starter.Bags;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Katalyst_TDD_Starter.Test.Bags
{
    [TestClass]
    public class BagShould
    {
        [TestMethod]
        public void Have_space()
        {
            var underTest = new Bag();

            Assert.IsTrue(underTest.HasSpace());
        }
        // hasSpace == true when it isn't full
        // hasSpace == false when it's full
    }
}
