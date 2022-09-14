using Katalyst_TDD_Starter.UserValidation;

namespace Katalyst_TDD_Starter.UserValidation
{
    public class UserGenerator
    {
        private IUserDataAccess dataAccess;

        public UserGenerator(IUserDataAccess dataAccess)
        {
            this.dataAccess = dataAccess;
        }
    }
}