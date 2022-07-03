namespace Katalyst_TDD_Starter.PasswordValidation
{
    public class PasswordValidatorBuilder
    {
        private int _inputLength = 9;

        public PasswordValidatorBuilder()
        {
        }

        public PasswordValidator Build()
        {
            return new PasswordValidator().SetInputLength(_inputLength);
        }

        public PasswordValidatorBuilder WithInputLength(int inputLength)
        {
            _inputLength = inputLength;
            return this;
        }
    }
}