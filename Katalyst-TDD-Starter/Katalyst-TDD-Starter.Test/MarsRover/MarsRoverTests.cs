using Katalyst_TDD_Starter.MarsRover;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Katalyst_TDD_Starter.Test.MarsRover
{
    [TestClass]
    public class MarsRoverTests
    {
        [TestMethod ("Turning Right Tests")]
        [DataRow ("R", "0:0:E", DisplayName = "Turn right once")]
        [DataRow ("RR", "0:0:S", DisplayName = "Turn right twice")]
        public void Rover_should_turn_right(string input, string expected)
        {
            var UnderTest = new Rover();

            var result = UnderTest.Move(input);

            Assert.AreEqual(expected, result);
        }
    }
}
