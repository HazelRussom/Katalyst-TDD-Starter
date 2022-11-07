namespace Katalyst_TDD_Starter.NumberGuessingGame
{
    public class NumberGuessingGameResult
    {
        private readonly string message;

        public NumberGuessingGameResult(string message)
        {
            this.message = message;
        }

        public string GetMessage()
        {
            return message;
        }
    }
}