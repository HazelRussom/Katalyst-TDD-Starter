namespace Katalyst_TDD_Starter.UserValidation
{
    public class UserValidator : IUserValidator
    {
        public ValidationResult Validate(User userToValidate)
        {
            if (userToValidate.FirstNameIsEmpty())
            {
                return ValidationResult.Invalid;
            }

            return ValidationResult.Valid;
        }
    }
}