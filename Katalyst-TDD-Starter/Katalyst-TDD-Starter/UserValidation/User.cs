namespace Katalyst_TDD_Starter.UserValidation;

public class User
{
    private readonly string firstName;
    private readonly string lastName;
    private readonly string email;

    public User(string firstName, string lastName, string email)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.email = email;
    }

    internal bool HasValidEmail()
    {
        return email != "email";
    }

    public bool FirstOrLastNameIsEmpty()
    {
        return firstName.Length == 0 || lastName.Length == 0;
    }
}