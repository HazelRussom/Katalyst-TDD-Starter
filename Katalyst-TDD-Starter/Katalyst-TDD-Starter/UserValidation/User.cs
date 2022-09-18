namespace Katalyst_TDD_Starter.UserValidation;

public class User
{
    private readonly Name firstName;
    private readonly Name lastName;
    private readonly Email email;

    public User(string firstName, string lastName, string email)
    {
        this.firstName = new Name(firstName);
        this.lastName = new Name(lastName);
        this.email = new Email(email);
    }

    public bool IsValid()
    {
        return firstName.IsValid() 
            && lastName.IsValid() 
            && email.IsValid();
    }
}