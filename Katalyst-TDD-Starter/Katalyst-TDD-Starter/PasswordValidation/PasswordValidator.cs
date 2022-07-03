namespace Katalyst_TDD_Starter.PasswordValidation
{
    public class PasswordValidator
    {
        public int InputLength { get; private set; }
        public bool RequireCapitalLetter { get; private set; }

        public PasswordValidator()
        {
            InputLength = 9;
            RequireCapitalLetter = true; 
        }

        public bool Validate(string input)
        {
            if (input.Length < InputLength)
            {
                return false;
            }

            if (RequireCapitalLetter && !CapitalLetterExists(input))
            {
                return false;
            }

            if (!input.Any(char.IsLower))
            {
                return false;
            }

            if (!input.Any(char.IsDigit))
            {
                return false;
            }

            if (!input.Contains('_'))
            {
                return false;
            }

            return true;
        }

        private bool CapitalLetterExists(string input)
        {
            return input.Any(char.IsUpper);
        }

        public void SetInputLength(int inputLength)
        {
            InputLength = inputLength;
        }

        public void SetCapitalsConfig(bool configSetting)
        {
            RequireCapitalLetter = configSetting;
        }
    }
}