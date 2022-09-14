using Katalyst_TDD_Starter.UserValidation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Katalyst_TDD_Starter.Test.UserValidation
{
    [TestClass]
    internal class UserCreationFeatureShould
    {
        [TestMethod]
        [Ignore]
        public void Not_create_user_missing_first_name()
        {
            var userDataAccess = new Mock<IUserDataAccess>();
            // Given a user without a first name
            var input = new User("", "LastName", "email@address.com");

            // When User Service is called to create the user
            var userService = new UserService(userDataAccess.Object);
            userService.CreateUser(input);

            // Then Validation should fail

            // And the user should not be created
            userDataAccess.Verify(x => x.SaveUser(It.IsAny<User>()), Times.Never());

        }
    }
}
