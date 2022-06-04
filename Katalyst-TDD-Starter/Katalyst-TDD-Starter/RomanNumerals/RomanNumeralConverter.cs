namespace Katalyst_TDD_Starter.RomanNumerals
{
    public enum RomanNumerals
    {
        I = 1,
        IV = 4,
        V = 5,
        IX = 9,
        X = 10,
        XL = 40,
        L = 50,
        XC = 90,
        C = 100,
        CD = 400,
        D = 500,
        CM = 900,
        M = 1000,
    }

    public interface IRomanNumeralConverter
    {
        public string Convert(int input);
    }

    public class RomanNumeralConverter : IRomanNumeralConverter
    {
        public string Convert(int input)
        {
            var result = string.Empty;

            var numerals = Enum.GetValues(typeof(RomanNumerals)).Cast<RomanNumerals>().ToList();
            numerals.Reverse();

            foreach(var numeral in numerals)
            {
                var number = (int)numeral;

                while (input >= number)
                {
                    input -= number;
                    result += numeral;
                }
            }          

            return result;
        }
    }
}