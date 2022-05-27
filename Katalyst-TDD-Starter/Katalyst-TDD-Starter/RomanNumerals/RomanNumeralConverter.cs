namespace Katalyst_TDD_Starter.RomanNumerals
{
    public enum RomanNumerals
    {
        I = 1,
        V = 5,
        X = 10,
        L = 50,
        C = 100,
        D = 500,
        M = 1000,
    }

    public class RomanNumeralConverter
    {
        public string Convert(int input)
        {
            var result = string.Empty;

            var numerals = Enum.GetValues(typeof(RomanNumerals)).Cast<RomanNumerals>().ToList();
            numerals.Reverse();

            foreach(var numeral in numerals)
            {
                ConvertGivenCharacter(ref input, ref result, numeral);
            }          

            return result;
        }

        private static void ConvertGivenCharacter(ref int input, ref string result, RomanNumerals numeral)
        {
            var number = (int)numeral;

            while (input >= number)
            {
                input -= number;
                result += numeral;
            }
        }
    }
}