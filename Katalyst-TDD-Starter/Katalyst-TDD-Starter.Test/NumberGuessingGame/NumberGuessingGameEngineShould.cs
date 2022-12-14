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

        private const string CorrectMessage = "You are correct!";
        private const string LowGuessMessage = "Incorrect! My number is higher.";
        private const string HighGuessMessage = "Incorrect! My number is lower.";
        private const string LoseMessage = "You lose! My number was ";

        private const int _correctNumber = 4;


        public NumberGuessingGameEngineShould()
        {
            _numberGenerator = new Mock<IRandomNumberGenerator>();
            _underTest = new NumberGuessingGameEngine(_numberGenerator.Object);
            _numberGenerator.Setup(x => x.Generate(It.IsAny<int>())).Returns(_correctNumber);
        }

        [TestMethod]
        [DataRow(2)]
        [DataRow(1)]
        public void Display_win_message(int correctNumber)
        {
            var expected = CorrectMessage;
            _numberGenerator.Setup(x => x.Generate(It.IsAny<int>())).Returns(correctNumber);

            var result = _underTest.Guess(correctNumber);

            _numberGenerator.Verify(x => x.Generate(It.IsAny<int>()), Times.Once);
            Assert.AreEqual(expected, result.GetMessage());
        }

        [TestMethod]
        public void Display_correct_number_is_higher_message()
        {
            var expected = LowGuessMessage;

            var result = _underTest.Guess(_correctNumber - 1);

            _numberGenerator.Verify(x => x.Generate(It.IsAny<int>()), Times.Once);
            Assert.AreEqual(expected, result.GetMessage());
        }

        [TestMethod]
        public void Display_correct_number_is_lower_message()
        {
            var expected = HighGuessMessage;

            var result = _underTest.Guess(_correctNumber + 1);

            _numberGenerator.Verify(x => x.Generate(It.IsAny<int>()), Times.Once);
            Assert.AreEqual(expected, result.GetMessage());
        }

        [TestMethod]
        public void Display_correct_number_after_losing_three_turns()
        {
            var expected = $"{LoseMessage}{_correctNumber}.";

            _underTest.Guess(_correctNumber + 1);
            _underTest.Guess(_correctNumber + 2);
            var result = _underTest.Guess(_correctNumber + 3);

            _numberGenerator.Verify(x => x.Generate(It.IsAny<int>()), Times.Once);
            Assert.AreEqual(expected, result.GetMessage());
        }

        [TestMethod]
        public void Pick_new_number_after_a_correct_guess()
        {
            var secondCorrectNumber = 3;
            var firstExpectedMessage = CorrectMessage;
            var secondExpectedMessage = HighGuessMessage;

            var firstResult = _underTest.Guess(_correctNumber);
            _numberGenerator.Setup(x => x.Generate(It.IsAny<int>())).Returns(secondCorrectNumber);
            var secondResult = _underTest.Guess(secondCorrectNumber + 1);

            _numberGenerator.Verify(x => x.Generate(It.IsAny<int>()), Times.Exactly(2));
            Assert.AreEqual(firstExpectedMessage, firstResult.GetMessage());
            Assert.AreEqual(secondExpectedMessage, secondResult.GetMessage());
        }

        [TestMethod]
        public void Pick_new_number_after_losing()
        {
            var secondCorrectNumber = 3;
            var firstExpectedMessage = $"{LoseMessage}{_correctNumber}.";
            var secondExpectedMessage = HighGuessMessage;

            _underTest.Guess(_correctNumber + 1);
            _underTest.Guess(_correctNumber + 2);
            var firstResult = _underTest.Guess(_correctNumber + 3);

            _numberGenerator.Setup(x => x.Generate(It.IsAny<int>())).Returns(secondCorrectNumber);
            var secondResult = _underTest.Guess(secondCorrectNumber + 1);

            _numberGenerator.Verify(x => x.Generate(It.IsAny<int>()), Times.Exactly(2));
            Assert.AreEqual(firstExpectedMessage, firstResult.GetMessage());
            Assert.AreEqual(secondExpectedMessage, secondResult.GetMessage());
        }
    }
}
