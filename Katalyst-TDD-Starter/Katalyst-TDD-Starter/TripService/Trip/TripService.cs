using TripServiceKata.Exception;
using TripServiceKata.User;

namespace TripServiceKata.Trip
{
    public class TripService
    {
        public List<Trip> GetTripsByUser(User.User user)
        {
            var loggedUser = GetLoggedInUser();

            if (loggedUser == null)
            {
                throw new UserNotLoggedInException();
            }

            if (!UsersAreFriends(user, loggedUser))
            {
                return new List<Trip>();
            }

            return GetTripList(user);
        }

        private static bool UsersAreFriends(User.User user, User.User loggedUser)
        {
            foreach (User.User friend in user.GetFriends())
            {
                if (friend.Equals(loggedUser))
                {
                    return true;
                }
            }

            return false;
        }

        protected virtual List<Trip> GetTripList(User.User user)
        {
            return TripDAO.FindTripsByUser(user);
        }

        protected virtual User.User GetLoggedInUser()
        {
            return UserSession.GetInstance().GetLoggedUser();
        }
    }
}
