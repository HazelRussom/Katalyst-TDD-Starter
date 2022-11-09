namespace Katalyst_TDD_Starter.NumberGuessingGame
{
    public class NumberGuessingGameEngine
    {
        private readonly IRandomNumberGenerator randomNumberGenerator;

        private const int Limit = 10;
        private const string LowGuessMessage = "Incorrect! My number is higher.";
        private const string HighGuessMessage = "Incorrect! My number is lower.";
        private const string CorrectMessage = "You are correct!";

        public NumberGuessingGameEngine(IRandomNumberGenerator randomNumberGenerator)
        {
            this.randomNumberGenerator = randomNumberGenerator;
        }

        public NumberGuessingGameResult Guess(int guessedNumber)
        {
            var correctNumber = randomNumberGenerator.Generate(Limit);

            if (guessedNumber < correctNumber)
            {
                return new NumberGuessingGameResult(LowGuessMessage);
            }

            if (guessedNumber > correctNumber)
            {
                return new NumberGuessingGameResult(HighGuessMessage);
            }

            return new NumberGuessingGameResult(CorrectMessage);
        }
    }
}