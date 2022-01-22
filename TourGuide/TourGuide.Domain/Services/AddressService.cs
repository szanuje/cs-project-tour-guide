using TourGuide.Domain.Data;
using TourGuide.Domain.Data.Models;

namespace TourGuide.Domain.Services
{
    public class AddressService
    {
        public bool AddNewAddress(String country, String city, String street,
            int postalCode, int houseNumber)
        {
            using(var db = new TourGuideContext())
            {
                var address = new Address()
                {
                    Country = country,
                    City = city,
                    Street = street,
                    PostalCode = postalCode,
                    HouseNumber = houseNumber
                };
                db.Add(address);
                int entries = db.SaveChanges();

                return entries > 0;
            }
        }

        public Address GetAddress(int key)
        {
            using (var db = new TourGuideContext())
            {
                return db.Addresses
                    .Where(a => a.Id == key)
                    .FirstOrDefault();
            }
        }
    }
}
