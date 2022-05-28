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

            if (input.Contains(","))
            {
                var numbers = input.Split(',');

                var num1 = int.Parse(numbers[0]);
                var num2 = int.Parse(numbers[1]);

                return num1 + num2;
            }

            return int.Parse(input);
        }
    }
}
