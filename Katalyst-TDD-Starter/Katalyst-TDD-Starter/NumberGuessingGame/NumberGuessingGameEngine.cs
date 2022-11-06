namespace Katalyst_TDD_Starter.NumberGuessingGame
{
    public class NumberGuessingGameEngine
    {
        private readonly IRandomNumberGenerator randomNumberGenerator;

        public NumberGuessingGameEngine(IRandomNumberGenerator randomNumberGenerator)
        {
            this.randomNumberGenerator = randomNumberGenerator;
        }

        public string Guess(int guessedNumber)
        {

            return "You are correct!";
        }
    }
}