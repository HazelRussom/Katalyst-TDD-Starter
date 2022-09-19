using Microsoft.VisualStudio.TestTools.UnitTesting;
using TripServiceKata.Exception;
using TripServiceKata.Trip;

namespace Katalyst_TDD_Starter.Test.TripServiceExercise
{
    [TestClass]
    public class TripServiceShould
    {
        [TestMethod]
        [Ignore]
        public void Error_when_user_is_not_logged_in()
        {
            var UnderTest = new TripService();
            TripServiceKata.User.User input = null;

            Assert.ThrowsException<UserNotLoggedInException>(() => UnderTest.GetTripsByUser(input));
        }
    }
}
