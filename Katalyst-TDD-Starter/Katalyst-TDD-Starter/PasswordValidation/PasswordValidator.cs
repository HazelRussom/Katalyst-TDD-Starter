namespace Katalyst_TDD_Starter.PasswordValidation
{
    public class PasswordValidator
    {
        public int InputLength { get; private set; }
        public bool RequireCapitalLetter { get; private set; }
        public bool RequireLowercaseLetter { get; private set; }
        public bool RequireNumericCharacter { get; private set; }
        public bool RequireUnderscore { get; private set; }

        public PasswordValidator()
        {
            InputLength = 9;
            RequireCapitalLetter = true;
            RequireLowercaseLetter = true;
            RequireNumericCharacter = true;
            RequireUnderscore = true;
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

            if (RequireLowercaseLetter && !LowercaseLetterExists(input))
            {
                return false;
            }

            if (RequireNumericCharacter && !NumericCharacterExists(input))
            {
                return false;
            }

            if (RequireUnderscore && !UnderscoreExists(input))
            {
                return false;
            }

            return true;
        }

        private static bool UnderscoreExists(string input)
        {
            return input.Contains('_');
        }

        private static bool NumericCharacterExists(string input)
        {
            return input.Any(char.IsDigit);
        }

        private static bool CapitalLetterExists(string input)
        {
            return input.Any(char.IsUpper);
        }

        private static bool LowercaseLetterExists(string input)
        {
            return input.Any(char.IsLower);
        }

        public PasswordValidator SetInputLength(int inputLength)
        {
            InputLength = inputLength;
            return this;
        }

        public PasswordValidator SetCapitalsConfig(bool configSetting)
        {
            RequireCapitalLetter = configSetting;
            return this;
        }

        public PasswordValidator SetLowercaseConfig(bool configSetting)
        {
            RequireLowercaseLetter = configSetting;
            return this;
        }

        public PasswordValidator SetNumericConfig(bool configSetting)
        {
            RequireNumericCharacter = configSetting;
            return this;
        }

        public PasswordValidator SetUnderscoreConfig(bool configSetting)
        {
            RequireUnderscore = configSetting;
            return this;
        }
    }
}