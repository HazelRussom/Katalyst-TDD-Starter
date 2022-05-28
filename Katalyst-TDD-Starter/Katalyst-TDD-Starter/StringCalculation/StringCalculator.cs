namespace Katalyst_TDD_Starter.StringCalculation
{
    public class StringCalculator
    {
        public int Add(string input)
        {
            if (input.Equals(string.Empty))
            {
                return 0;
            }

            var result = 0;
            var delimiters = new char[] { ',', '\n' };
            var numbers = input.Split(delimiters);

            foreach (var number in numbers)
            {
                result += int.Parse(number);
            }

            return result;
        }
    }
}
