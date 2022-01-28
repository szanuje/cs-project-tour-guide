using TourGuide.Domain.Data;
using TourGuide.Domain.Data.Models;

namespace TourGuide.Domain.Services
{
    public class HotelService
    {
        public bool AddNewHotel(String name, String rating, Double price,
            Destination destination, Address address)
        {
            using (var db = new TourGuideContext())
            {
                var hotel = new Hotel()
                {
                    Name = name,
                    Rating = rating,
                    Price = price,
                    //Destination = destination,
                    Address = address
                };
                db.Add(hotel);
                int entries = db.SaveChanges();

                return entries > 0;
            }

        }

        public ICollection<Hotel> GetAllHotelsForTrip(IList<Place> tripPlaces)
        {
            return tripPlaces.SelectMany(p => p.Destination.Hotels).ToHashSet();
        }
    }
}
