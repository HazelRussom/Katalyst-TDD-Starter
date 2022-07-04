namespace Katalyst_TDD_Starter.PasswordValidation
{
    public class PasswordValidatorBuilder
    {
        private int _inputLength = 9;
        private bool _requireCapitalLetter = true;

        public PasswordValidatorBuilder()
        {
        }

        public PasswordValidator Build()
        {
            return new PasswordValidator(_inputLength, _requireCapitalLetter, true, true, true);
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
    }
}