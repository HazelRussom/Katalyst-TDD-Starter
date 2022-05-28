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


            var numbers = input.Split(',');

            if (input.Contains('\n'))
            {
                numbers = input.Split('\n');
            }

            var result = 0;

            foreach (var number in numbers)
            {
                result += int.Parse(number);
            }

            return result;
        }
    }
}
