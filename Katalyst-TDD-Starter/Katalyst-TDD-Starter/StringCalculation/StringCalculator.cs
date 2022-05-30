namespace Katalyst_TDD_Starter.StringCalculation
{
    public class StringCalculator
    {
        private const string CustomDelimeterFlag = "//";
        private const char EndOfConfigFlag = '\n';

        public int Add(string input)
        {
            if (input.Equals(string.Empty))
            {
                return 0;
            }

            var result = 0;
            var invalidNumbers = new List<string>();
            var delimiters = new List<string> {",", "\n"};

            if (input.StartsWith(CustomDelimeterFlag))
            {
                var endOfConfigIndex = input.IndexOf(EndOfConfigFlag);

                var delimiterConfig = input.Substring(CustomDelimeterFlag.Length, endOfConfigIndex - CustomDelimeterFlag.Length);
                input = input.Substring(endOfConfigIndex + 1);
             
                if (delimiterConfig.StartsWith('[') && delimiterConfig.EndsWith(']'))
                {
                    delimiterConfig = delimiterConfig.Substring(1, delimiterConfig.Length - 2);
                }

                var customDelimiters = delimiterConfig.Split("][");
                delimiters.AddRange(customDelimiters);
            }

            var numbers = input.Split(delimiters.ToArray(), StringSplitOptions.None);

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
