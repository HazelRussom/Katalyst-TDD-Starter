using Katalyst_TDD_Starter.MarsRover;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Katalyst_TDD_Starter.Test.MarsRover
{
    [TestClass]
    public class MarsRoverTests
    {
        [TestMethod]
        public void Rover_should_turn_right()
        {
            var input = "R";

            var expected = "0:0:E";

            var UnderTest = new Rover();

            var result = UnderTest.Move(input);

            Assert.AreEqual(expected, result);
        }
    }
}
