namespace Katalyst_TDD_Starter.UserValidation;

public class UserService
{
    private UserValidator userValidator;
    private UserGenerator userGenerator;

    public UserService(UserValidator userValidator, UserGenerator userGenerator)
    {
        this.userValidator = userValidator;
        this.userGenerator = userGenerator;
    }

    public void CreateUser(User input)
    {
        throw new NotImplementedException();
    }
}