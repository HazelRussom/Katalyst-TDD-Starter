using TripServiceKata.Exception;
using TripServiceKata.User;

namespace TripServiceKata.Trip
{
    public class TripService
    {
        public List<Trip> GetTripsByUser(User.User user)
        {
            var isFriend = false;

            var loggedUser = GetLoggedInUser();

            if (loggedUser == null)
            {
                throw new UserNotLoggedInException();
            }

            foreach (User.User friend in user.GetFriends())
            {
                if (friend.Equals(loggedUser))
                {
                    isFriend = true;
                    break;
                }
            }

            if (!isFriend)
            {
                return new List<Trip>();
            }
            
            return GetTripList(user);
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
