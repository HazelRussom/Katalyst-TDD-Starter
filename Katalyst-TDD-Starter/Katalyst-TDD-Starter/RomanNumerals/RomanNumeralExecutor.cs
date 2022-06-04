namespace Katalyst_TDD_Starter.RomanNumerals
{
    public class RomanNumeralExecutor
    {
        public RomanNumeralExecutor(IRomanNumeralConverter converter)
        {
            Converter = converter;
        }

        public IRomanNumeralConverter Converter { get; }

        public void Execute(int input)
        {
            Converter.Convert(input);
        }
    }
}