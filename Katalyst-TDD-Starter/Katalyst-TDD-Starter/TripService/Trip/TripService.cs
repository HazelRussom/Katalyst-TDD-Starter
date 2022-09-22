using TripServiceKata.Exception;
using TripServiceKata.User;

namespace TripServiceKata.Trip
{
    public class TripService
    {
        public List<Trip> GetTripsByUser(User.User user)
        {
            var loggedInUser = GetLoggedInUser();

            if (UserIsNotLoggedIn(loggedInUser))
            {
                throw new UserNotLoggedInException();
            }

            if (user.IsFriendsWith(loggedInUser))
            {
                return TripsBy(user);
            }

            return new List<Trip>();
        }

        protected virtual User.User GetLoggedInUser()
        {
            return UserSession.GetInstance().GetLoggedUser();
        }

        private static bool UserIsNotLoggedIn(User.User loggedUser)
        {
            return loggedUser == null;
        }

        protected virtual List<Trip> TripsBy(User.User user)
        {
            return TripDAO.FindTripsByUser(user);
        }
    }
}
