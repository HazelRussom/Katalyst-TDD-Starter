using Katalyst_TDD_Starter.NumberGuessingGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Katalyst_TDD_Starter.Test.NumberGuessingGame
{
    [TestClass]
    public class NumberGuessingGameEngineShould
    {
        private readonly Mock<IRandomNumberGenerator> _numberGenerator;
        private readonly NumberGuessingGameEngine _underTest;

        public NumberGuessingGameEngineShould()
        {
            _numberGenerator = new Mock<IRandomNumberGenerator>();
            _underTest = new NumberGuessingGameEngine(_numberGenerator.Object);
        }

        [TestMethod]
        [DataRow(2)]
        [DataRow(1)]
        public void Display_win_message(int correctNumber)
        {
            var expected = "You are correct!";
            _numberGenerator.Setup(x => x.Generate(It.IsAny<int>())).Returns(correctNumber);

            var result = _underTest.Guess(correctNumber);

            _numberGenerator.Verify(x => x.Generate(It.IsAny<int>()), Times.Once);
            Assert.AreEqual(expected, result.GetMessage());
        }

        [TestMethod]
        public void Display_correct_number_is_higher_message()
        {
            var correctNumber = 2;
            var expected = "Incorrect! My number is higher.";
            _numberGenerator.Setup(x => x.Generate(It.IsAny<int>())).Returns(correctNumber);

            var result = _underTest.Guess(correctNumber - 1);

            _numberGenerator.Verify(x => x.Generate(It.IsAny<int>()), Times.Once);
            Assert.AreEqual(expected, result.GetMessage());
        }

        [TestMethod]
        public void Display_correct_number_is_lower_message()
        {
            var correctNumber = 4;
            var expected = "Incorrect! My number is lower.";
            _numberGenerator.Setup(x => x.Generate(It.IsAny<int>())).Returns(correctNumber);

            var result = _underTest.Guess(correctNumber + 1);

            _numberGenerator.Verify(x => x.Generate(It.IsAny<int>()), Times.Once);
            Assert.AreEqual(expected, result.GetMessage());
        }

        [TestMethod]
        public void Display_correct_number_after_losing_three_turns()
        {
            var correctNumber = 4;
            var expected = $"You lose! My number was {correctNumber}.";
            _numberGenerator.Setup(x => x.Generate(It.IsAny<int>())).Returns(correctNumber);

            _underTest.Guess(correctNumber + 1);
            _underTest.Guess(correctNumber + 2);
            var result = _underTest.Guess(correctNumber + 3);

            _numberGenerator.Verify(x => x.Generate(It.IsAny<int>()), Times.Once);
            Assert.AreEqual(expected, result.GetMessage());
        }

        [TestMethod]
        public void Pick_new_number_after_a_correct_guess()
        {
            var firstCorrectNumber = 5;
            var secondCorrectNumber = 3;
            var firstExpectedMessage = "You are correct!";
            var secondExpectedMessage = "Incorrect! My number is lower.";
            _numberGenerator.Setup(x => x.Generate(It.IsAny<int>())).Returns(firstCorrectNumber);
            var firstResult = _underTest.Guess(firstCorrectNumber);

            _numberGenerator.Setup(x => x.Generate(It.IsAny<int>())).Returns(secondCorrectNumber);
            var secondResult = _underTest.Guess(firstCorrectNumber);

            _numberGenerator.Verify(x => x.Generate(It.IsAny<int>()), Times.Exactly(2));
            Assert.AreEqual(firstExpectedMessage, firstResult.GetMessage());
            Assert.AreEqual(secondExpectedMessage, secondResult.GetMessage());
        }

        [TestMethod]
        public void Pick_new_number_after_losing()
        {
            var firstCorrectNumber = 4;
            var secondCorrectNumber = 3;
            var firstExpectedMessage = $"You lose! My number was {firstCorrectNumber}.";
            var secondExpectedMessage = "Incorrect! My number is lower.";
            _numberGenerator.Setup(x => x.Generate(It.IsAny<int>())).Returns(firstCorrectNumber);

            _underTest.Guess(firstCorrectNumber + 1);
            _underTest.Guess(firstCorrectNumber + 2);
            var firstResult = _underTest.Guess(firstCorrectNumber + 3);

            _numberGenerator.Setup(x => x.Generate(It.IsAny<int>())).Returns(secondCorrectNumber);
            var secondResult = _underTest.Guess(firstCorrectNumber);

            _numberGenerator.Verify(x => x.Generate(It.IsAny<int>()), Times.Exactly(2));
            Assert.AreEqual(firstExpectedMessage, firstResult.GetMessage());
            Assert.AreEqual(secondExpectedMessage, secondResult.GetMessage());
        }
    }
}
