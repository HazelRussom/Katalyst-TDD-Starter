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
            var delimiters = new List<char> { ',', '\n'};
            
            if (input.StartsWith("//"))
            {
                delimiters.Add(input[2]);
                input = input.Substring(4);
            }

            var numbers = input.Split(delimiters.ToArray());

            foreach (var number in numbers)
            {
                result += int.Parse(number);
            }

            return result;
        }
    }
}
