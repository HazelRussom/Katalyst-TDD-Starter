using Katalyst_TDD_Starter.UserValidation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Katalyst_TDD_Starter.Test.UserValidation
{
    [TestClass]
    public class UserCreationFeatureShould
    {
        [TestMethod]
        [Ignore]
        public void Not_create_user_missing_first_name()
        {
            var userValidator = new UserValidator();
            var userGenerator = new Mock<IUserGenerator>();
            // Given a user without a first name
            var input = new User("", "LastName", "email@address.com");

            // When User Service is called to create the user
            var userService = new UserService(userValidator, userGenerator.Object);
            userService.CreateUser(input);

            // Then Validation should fail
            // And the user should not be created
            userGenerator.Verify(x => x.SaveUser(It.IsAny<User>()), Times.Never());

        }
    }
}
