namespace Katalyst_TDD_Starter.FizzBuzz
{
    public class FizzBuzzExecutor
    {
        public FizzBuzzExecutor(IFizzBuzzConverter converter)
        {
            Converter = converter;
        }

        public IFizzBuzzConverter Converter { get; }

        public void Execute(int limit)
        {
            for(int i = 1; i <= limit; i++)
            {
                Console.WriteLine(Converter.Convert(i));
            }
        }
    }
}
