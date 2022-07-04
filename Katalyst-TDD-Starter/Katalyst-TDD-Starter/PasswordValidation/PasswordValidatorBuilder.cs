namespace Katalyst_TDD_Starter.PasswordValidation
{
    public class PasswordValidatorBuilder
    {
        private int _inputLength = 9;
        private bool _requireCapitalLetter = true;
        private bool _requireLowercaseLetter = true;

        public PasswordValidatorBuilder()
        {
        }

        public PasswordValidator Build()
        {
            return new PasswordValidator(_inputLength, _requireCapitalLetter, _requireLowercaseLetter, true, true);
        }

        public PasswordValidatorBuilder WithInputLength(int inputLength)
        {
            _inputLength = inputLength;
            return this;
        }

        public PasswordValidatorBuilder WithRequiredCapital(bool input)
        {
            _requireCapitalLetter = input;
            return this;
        }

        public PasswordValidatorBuilder WithRequiredLowercase(bool input)
        {
            _requireLowercaseLetter = input;
            return this;
        }
    }
}