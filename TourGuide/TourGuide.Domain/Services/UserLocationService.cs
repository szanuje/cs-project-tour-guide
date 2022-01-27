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
    }
}
