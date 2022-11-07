using Katalyst_TDD_Starter.NumberGuessingGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Katalyst_TDD_Starter.Test.NumberGuessingGame
{
    [TestClass]
    public class NumberGuessingGameFeatureShould
    {
        [TestMethod]
        public void Alert_player_of_win_on_third_turn()
        {
            var correctNumber = 5;
            var randomNumberGenerator = new Mock<IRandomNumberGenerator>();
            randomNumberGenerator.Setup(x => x.Generate(It.IsAny<int>())).Returns(correctNumber);
            var gameEngine = new NumberGuessingGameEngine(randomNumberGenerator.Object);

            var firstGuess = correctNumber - 1;
            var firstResult = gameEngine.Guess(firstGuess);

            var expectedFirstMessage = "Incorrect! My number is higher.";
            Assert.AreEqual(expectedFirstMessage, firstResult.GetMessage());

            var secondGuess = correctNumber + 1;
            var secondResult = gameEngine.Guess(secondGuess);

            var expectedSecondMessage = "Incorrect! My number is lower.";
            Assert.AreEqual(expectedSecondMessage, secondResult.GetMessage());

            var finalGuess = correctNumber;
            var finalResult = gameEngine.Guess(finalGuess);

            var expectedFinalMessage = "You are correct!";
            Assert.AreEqual(expectedFinalMessage, finalResult);
        }
    }
}
