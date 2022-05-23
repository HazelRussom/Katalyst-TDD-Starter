namespace Katalyst_TDD_Starter.FizzBuzz
{
    public class FizzBuzzExecutor
    {
        public FizzBuzzExecutor(IFizzBuzzConverter converter)
        {
            Converter = converter;
        }

        public IFizzBuzzConverter Converter { get; }

        public void Execute()
        {

        }
    }
}
