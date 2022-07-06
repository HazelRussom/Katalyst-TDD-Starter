namespace Katalyst_TDD_Starter.PasswordValidation
{
    public class PasswordValidator
    {
        private readonly int InputLength;
        private readonly bool RequireCapitalLetter;
        private readonly bool RequireLowercaseLetter;
        private readonly bool RequireNumericCharacter;
        private readonly bool RequireUnderscore;

        internal PasswordValidator(int _inputLength, bool _requireCapitalLetter, 
            bool _requiresLowercaseLetter, bool _requiresNumericCharacter, bool _requiresUnderscore)
        {
            InputLength = _inputLength;
            RequireCapitalLetter = _requireCapitalLetter;
            RequireLowercaseLetter = _requiresLowercaseLetter;
            RequireNumericCharacter = _requiresNumericCharacter;
            RequireUnderscore = _requiresUnderscore;
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
    }
}