namespace Katalyst_TDD_Starter.NumberGuessingGame
{
    public class NumberGuessingGameEngine
    {
        private readonly IRandomNumberGenerator randomNumberGenerator;
        private int correctNumber = -1;
        private int currentTurn;

        private const int NumberLimit = 10;
        private const int TurnLimit = 3;
        private const string CorrectMessage = "You are correct!";
        private const string LowGuessMessage = "Incorrect! My number is higher.";
        private const string HighGuessMessage = "Incorrect! My number is lower.";
        private const string LoseMessage = $"You lose! My number was ";


        public NumberGuessingGameEngine(IRandomNumberGenerator randomNumberGenerator)
        {
            this.randomNumberGenerator = randomNumberGenerator;
        }

        public NumberGuessingGameResult Guess(int guessedNumber)
        {
            currentTurn++;

            if (correctNumber < 0)
            {
                correctNumber = randomNumberGenerator.Generate(NumberLimit);
            }

            return BuildResult(guessedNumber);
        }

        private NumberGuessingGameResult BuildResult(int guessedNumber)
        {
            if (guessedNumber == correctNumber)
            {
                correctNumber = -1;
                return new NumberGuessingGameResult(CorrectMessage);
            }

            if (currentTurn == TurnLimit)
            {
                return new NumberGuessingGameResult(LoseMessage + correctNumber + ".");
            }

            if (guessedNumber < correctNumber)
            {
                return new NumberGuessingGameResult(LowGuessMessage);
            }

            return new NumberGuessingGameResult(HighGuessMessage);
        }
    }
}