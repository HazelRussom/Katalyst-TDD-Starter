using Microsoft.VisualStudio.TestTools.UnitTesting;
using TripServiceKata.Exception;
using TripServiceKata.Trip;
using TripServiceKata.User;

namespace Katalyst_TDD_Starter.Test.TripServiceExercise
{

    [TestClass]
    public class TripServiceShould
    {
        private class TestableTripService : TripService
        {
            private User loggedInUser;

            internal TestableTripService(User loggedInUser)
            {
                this.loggedInUser = loggedInUser;
            }

            protected override User GetLoggedInUser()
            {
                return loggedInUser;
            }
        }

        [TestMethod]
        public void Error_when_user_is_not_logged_in()
        {
            var UnderTest = new TestableTripService(null);
            User input = null;

            Assert.ThrowsException<UserNotLoggedInException>(() => UnderTest.GetTripsByUser(input));
        }

        [TestMethod]
        public void Return_empty_trip_list_for_non_friend_users()
        {
            var UnderTest = new TestableTripService(new User());
            var input = new User();

            var result = UnderTest.GetTripsByUser(input);

            Assert.AreEqual(0, result.Count);
        }
    }
}
