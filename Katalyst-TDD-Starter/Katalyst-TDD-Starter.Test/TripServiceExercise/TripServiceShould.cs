using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
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
            private List<Trip> tripList;

            internal TestableTripService(User loggedInUser, List<Trip> tripList)
            {
                this.loggedInUser = loggedInUser;
                this.tripList = tripList;
            }

            protected override User GetLoggedInUser()
            {
                return loggedInUser;
            }

            protected override List<Trip> TripsBy(User user)
            {
                return tripList;
            }
        }

        [TestMethod]
        public void Error_when_user_is_not_logged_in()
        {
            var UnderTest = new TestableTripService(null, null);
            User input = null;

            Assert.ThrowsException<UserNotLoggedInException>(() => UnderTest.GetTripsByUser(input));
        }

        [TestMethod]
        public void Return_empty_trip_list_for_non_friend_users()
        {
            var UnderTest = new TestableTripService(new User(), null);
            var input = new User();

            var result = UnderTest.GetTripsByUser(input);

            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void Return_empty_list_of_trips_for_friend_users()
        {
            var loggedInUser = new User();
            var input = new User();
            input.AddFriend(loggedInUser);
            var UnderTest = new TestableTripService(loggedInUser, new List<Trip>());

            var result = UnderTest.GetTripsByUser(input);

            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void Return_populated_list_of_trips_for_friend_users()
        {
            var expectedTrips = new List<Trip> { new Trip() };
            var loggedInUser = new User();
            var input = new User();
            input.AddFriend(loggedInUser);
            var UnderTest = new TestableTripService(loggedInUser, expectedTrips);

            var result = UnderTest.GetTripsByUser(input);

            Assert.AreEqual(1, result.Count);
        }
    }
}
