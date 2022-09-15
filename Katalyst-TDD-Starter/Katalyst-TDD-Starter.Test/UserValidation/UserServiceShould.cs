using Katalyst_TDD_Starter.UserValidation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Katalyst_TDD_Starter.Test.UserValidation
{
    [TestClass]
    public class UserServiceShould
    {
        [TestMethod]
        public void Not_create_user_when_validation_fails()
        {
            var userValidator = new Mock<IUserValidator>();
            var userGenerator = new Mock<IUserGenerator>();
            var input = new User(string.Empty, string.Empty, string.Empty);
            userValidator.Setup(x => x.Validate(input)).Returns(false);
            var underTest = new UserService(userValidator.Object, userGenerator.Object);

            underTest.CreateUser(input);

            userValidator.Verify(x => x.Validate(input), Times.Once());
            userGenerator.Verify(x => x.SaveUser(It.IsAny<User>()), Times.Never());
        }

        [TestMethod]
        public void Create_user_when_validation_passes()
        {
            var userValidator = new Mock<IUserValidator>();
            var userGenerator = new Mock<IUserGenerator>();
            var input = new User(string.Empty, string.Empty, string.Empty);
            userValidator.Setup(x => x.Validate(input)).Returns(true);
            var underTest = new UserService(userValidator.Object, userGenerator.Object);

            underTest.CreateUser(input);

            userValidator.Verify(x => x.Validate(input), Times.Once());
            userGenerator.Verify(x => x.SaveUser(input), Times.Once());
        }
    }
}
