namespace Katalyst_TDD_Starter.NumberGuessingGame
{
    public class NumberGuessingGameEngine
    {
        private readonly IRandomNumberGenerator randomNumberGenerator;
        private const int Limit = 10;
        private const string LowGuessMessage = "Incorrect! My number is higher.";
        private const string CorrectMessage = "You are correct!";

        public NumberGuessingGameEngine(IRandomNumberGenerator randomNumberGenerator)
        {
            this.randomNumberGenerator = randomNumberGenerator;
        }

        public NumberGuessingGameResult Guess(int guessedNumber)
        {
            randomNumberGenerator.Generate(Limit);

            if(guessedNumber < 2)
            {
                return new NumberGuessingGameResult(LowGuessMessage);
            }

            return new NumberGuessingGameResult(CorrectMessage);
        }
    }
}