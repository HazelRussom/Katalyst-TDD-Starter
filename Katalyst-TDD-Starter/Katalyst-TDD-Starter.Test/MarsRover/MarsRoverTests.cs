using Katalyst_TDD_Starter.MarsRover;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Katalyst_TDD_Starter.Test.MarsRover
{
    [TestClass]
    public class MarsRoverTests
    {
        [TestMethod ("Movement Tests")]
        [DataRow ("", "0:0:N", DisplayName = "No movement")]
        [DataRow ("R", "0:0:E", DisplayName = "Turn right")]
        [DataRow ("RR", "0:0:S", DisplayName = "Turn right 2x")]
        [DataRow ("RRR", "0:0:W", DisplayName = "Turn right 3x")]
        [DataRow ("RRRR", "0:0:N", DisplayName = "Turn right 4x")]
        [DataRow ("L", "0:0:W", DisplayName = "Turn left")]
        [DataRow ("LL", "0:0:S", DisplayName = "Turn left 2x")]
        [DataRow ("LLL", "0:0:E", DisplayName = "Turn left 3x")]
        [DataRow ("LLLL", "0:0:N", DisplayName = "Turn left 4x")]
        [DataRow ("M", "0:1:N", DisplayName = "Move north once")]
        [DataRow ("MMMMMMMMM", "0:9:N", DisplayName = "Move to the top")]
        [DataRow ("MMMMMMMMMM", "0:0:N", DisplayName = "Loop over the top")]
        [DataRow ("RRM", "0:9:S", DisplayName = "Move south once")]
        [DataRow ("MMRRM", "0:1:S", DisplayName = "Move up, then down")]
        [DataRow ("RM", "1:0:E", DisplayName = "Move east once")]
        [DataRow ("RMMMMMMMMMM", "0:0:E", DisplayName = "Loop over the right")]
        [DataRow ("LM", "9:0:W", DisplayName = "Move west once")]
        [DataRow ("LMLMRR", "9:9:N", DisplayName = "Move to 9,9")]
        [DataRow ("MRMMMLMMM", "3:4:N", DisplayName = "Move to 3,4")]
        public void Rover_should_turn(string input, string expected)
        {
            var UnderTest = new Rover();

            var result = UnderTest.Execute(input);

            Assert.AreEqual(expected, result);
        }
    }
}
