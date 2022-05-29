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
            var invalidNumbers = new List<string>();
            var delimiters = new List<char> {',', '\n'};
            
            if (input.StartsWith("//"))
            {
                delimiters.Add(input[2]);
                input = input.Substring(4);
            }

            var numbers = input.Split(delimiters.ToArray());

            foreach (var number in numbers)
            {
                var parsedNumber = int.Parse(number);

                if(parsedNumber <= 1000)
                {
                    result += parsedNumber;
                }

                if(parsedNumber < 0)
                {
                    invalidNumbers.Add(number);
                }
            }

            if (invalidNumbers.Any())
            {
                var invalidNumberString = string.Join(" ", invalidNumbers);
                throw new ArgumentException($"Error: Negatives not allowed: {invalidNumberString}");
            }
            
            return result;
        }
    }
}
