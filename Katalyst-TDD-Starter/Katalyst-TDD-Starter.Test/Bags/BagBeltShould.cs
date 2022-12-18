using Katalyst_TDD_Starter.Bags;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Katalyst_TDD_Starter.Test.Bags
{
    [TestClass]
    public class BagBeltShould
    {
        [TestMethod]
        public void Start_with_no_bags()
        {
            var underTest = new BagBelt();

            Assert.IsFalse(underTest.GetBags().Any());
        }
    }
}
