using TourGuide.Domain.Data;
using TourGuide.Domain.Data.Models;

namespace TourGuide.Domain.Services
{
    public class UserLocationService
    {
        public bool AddLocationToUser(int locationId, string username)
        {
            using (var db = new TourGuideContext())
            {
                if (db.UserLocations.Any(ub => ub.LocationId == locationId && ub.Username == username))
                {
                    return false;
                }

                db.Add(new UserLocation()
                {
                    Username = username,
                    LocationId = locationId,
                });

                int entries = db.SaveChanges();
                return entries > 0;
            }
        }

        public bool RemoveLocationFromUser(int locationId, string username)
        {
            using (var db = new TourGuideContext())
            {
                if (!db.UserLocations.Any(ub => ub.LocationId == locationId && ub.Username == username))
                {
                    return false;
                }

                db.Remove(new UserLocation()
                {
                    Username = username,
                    LocationId = locationId,
                });

                int entries = db.SaveChanges();
                return entries > 0;
            }
        }

        public List<Place> GetAllUserPlaces(string username)
        {
            List<UserLocation> locations = GetAllUserLocations(username);
            return locations.Select(loc => (Place)loc.BaseLocation).ToList();
        }

        private static List<UserLocation> GetAllUserLocations(string username)
        {
            using (var db = new TourGuideContext())
            {
                return db.UserLocations.Where(ub => ub.Username == username).ToList();
            }
        }
    }
}
