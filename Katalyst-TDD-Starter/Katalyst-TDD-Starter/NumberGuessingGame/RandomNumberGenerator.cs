namespace Katalyst_TDD_Starter.NumberGuessingGame
{
    public class RandomNumberGenerator : IRandomNumberGenerator
    {
        public int Generate(int limit)
        {
            return new Random().Next(limit) + 1;
        }
    }
}