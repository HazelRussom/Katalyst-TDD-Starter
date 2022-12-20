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
            var underTest = new Bag(1);

            Assert.IsTrue(underTest.HasSpace());
        }

        [TestMethod]
        public void Not_have_space()
        {
            var underTest = new Bag(1);

            underTest.AddItem(new Item(string.Empty, ItemCategory.Cloth));

            Assert.IsFalse(underTest.HasSpace());
        }
    }
}
