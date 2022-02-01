using TourGuide.Domain.Data;
using TourGuide.Domain.Data.Models;

namespace TourGuide.Domain.Services
{
    public class PlaceService
    {
        public List<Place> GetPlacesForDestination(int destinationId)
        {
            using (var db = new TourGuideContext())
            {
                var destination = db.Destinations
                    .Where(d => d.DestinationId == destinationId)
                    .FirstOrDefault();

                if (destination == null) return new List<Place>();

                return destination.Places;
            }
        }

        public bool AddNewPlace(String name, String description,
            int destinationId, Address address)
        {
            using (var db = new TourGuideContext())
            {
                var destination = db.Destinations.FirstOrDefault(d => d.DestinationId == destinationId);

                if (destination == null) return false;

                var place = new Place()
                {
                    Name = name,
                    Description = description,
                    DestinationFK = destinationId,
                    Destination = destination,
                    Address = address
                };

                db.Add(place);
                int entries = db.SaveChanges();

                return entries > 0;
            }
        }
        public bool RemovePlace(int locationId)
        {
            using (var db = new TourGuideContext())
            {
                var place = db.Places
                    .Where(d => d.LocationId == locationId)
                    .FirstOrDefault();

                if (place == null) return false;

                db.Places.Remove(place);
                int entries = db.SaveChanges();

                return entries > 0;
            }
        }
    }
}
