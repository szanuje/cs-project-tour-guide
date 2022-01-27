using TourGuide.Domain.Data;
using TourGuide.Domain.Data.Models;

namespace TourGuide.Domain.Services
{
    public class UserService
    {
        public bool AddNewUser(String username, String password)
        {
            using (var db = new TourGuideContext())
            {
                if (db.Users.Any(u => u.Username == username)) return false;

                var user = new User() { Username = username, Password = password };
                db.Add(user);
                int entries = db.SaveChanges();

                return entries > 0;
            }
        }

        public User LoginUser(String username, String password)
        {
            using (var db = new TourGuideContext())
            {
                return db.Users
                    .Where(u => u.Username == username
                        && u.Password == password)
                    .FirstOrDefault();
            }
        }
    }
}
