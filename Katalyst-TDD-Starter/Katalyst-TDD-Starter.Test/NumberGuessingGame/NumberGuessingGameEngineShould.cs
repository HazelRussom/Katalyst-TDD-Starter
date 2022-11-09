using Katalyst_TDD_Starter.NumberGuessingGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Katalyst_TDD_Starter.Test.NumberGuessingGame
{
    [TestClass]
    public class NumberGuessingGameEngineShould
    {
        [TestMethod]
        [DataRow(2)]
        [DataRow(1)]
        public void Display_win_message(int correctNumber)
        {
            var expected = "You are correct!";
            var numberGenerator = new Mock<IRandomNumberGenerator>();
            var underTest = new NumberGuessingGameEngine(numberGenerator.Object);
            numberGenerator.Setup(x => x.Generate(It.IsAny<int>())).Returns(correctNumber);

            var result = underTest.Guess(correctNumber);

            numberGenerator.Verify(x => x.Generate(It.IsAny<int>()), Times.Once);
            Assert.AreEqual(expected, result.GetMessage());
        }

        [TestMethod]
        public void Display_number_is_higher_message()
        {
            var correctNumber = 2;
            var expected = "Incorrect! My number is higher.";
            var numberGenerator = new Mock<IRandomNumberGenerator>();
            var underTest = new NumberGuessingGameEngine(numberGenerator.Object);
            numberGenerator.Setup(x => x.Generate(It.IsAny<int>())).Returns(correctNumber);

            var result = underTest.Guess(correctNumber - 1);

            numberGenerator.Verify(x => x.Generate(It.IsAny<int>()), Times.Once);
            Assert.AreEqual(expected, result.GetMessage());
        }
    }
}
