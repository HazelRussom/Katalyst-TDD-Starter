namespace Katalyst_TDD_Starter.UserValidation;

public class UserService
{
    private IUserValidator userValidator;
    private IUserGenerator userGenerator;

    public UserService(IUserValidator userValidator, IUserGenerator userGenerator)
    {
        this.userValidator = userValidator;
        this.userGenerator = userGenerator;
    }

    public void CreateUser(User input)
    {
        if (userValidator.Validate(input))
        {
            userGenerator.SaveUser(input);
        }
    }
}