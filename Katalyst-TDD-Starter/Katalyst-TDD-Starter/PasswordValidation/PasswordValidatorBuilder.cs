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
            return new PasswordValidator().SetInputLength(_inputLength).SetCapitalsConfig(_requireCapitalLetter);
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