using Katalyst_TDD_Starter.NumberGuessingGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Katalyst_TDD_Starter.Test.NumberGuessingGame
{
    [TestClass]
    public class NumberGuessingGameEngineShould
    {
        [TestMethod]
        public void Display_win_message()
        {
            var correctNumber = 2;
            var expected = "You are correct!";
            var numberGenerator = new Mock<IRandomNumberGenerator>();
            var underTest = new NumberGuessingGameEngine(numberGenerator.Object);
            numberGenerator.Setup(x => x.Generate(It.IsAny<int>())).Returns(correctNumber);

            var result = underTest.Guess(correctNumber);

            Assert.AreEqual(expected, result);
        }
    }
}
