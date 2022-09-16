namespace Katalyst_TDD_Starter.UserValidation;

public interface IUserValidator
{
    ValidationResult Validate(User userToValidate);
}