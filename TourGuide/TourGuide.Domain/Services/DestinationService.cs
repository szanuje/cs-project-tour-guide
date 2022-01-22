using TourGuide.Domain.Data;
using TourGuide.Domain.Data.Models;

namespace TourGuide.Domain.Services
{
    public class DestinationService
    {
        public bool AddNewDestination(String Name, String Description)
        {
            using (var db = new TourGuideContext())
            {
                var destination = new Destination() { Name = Name, Description = Description };
                db.Add(destination);
                int entries = db.SaveChanges();

                return entries > 0;
            }
        }

        public Destination GetDestination(String name)
        {
            using (var db = new TourGuideContext())
            {
                return db.Destinations
                    .Where(d => d.Name == name)
                    .FirstOrDefault();
            }
        }

        public List<Destination> GetAllDestinations()
        {
            using (var db = new TourGuideContext())
            {
                return db.Destinations.ToList();
            }
        }
    }
}
