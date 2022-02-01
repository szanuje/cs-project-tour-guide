using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TourGuide.Domain.Data;
using TourGuide.Domain.Data.Models;

namespace TourGuideTests.models
{
    [TestFixture]
    public class TourGuideContextTests
    {
        [Test]
        public void addUser()
        {
            using (var db = new TourGuideContext())
            {
                var user = new User() { Username = "Test" };
                db.Add(user);
                db.SaveChanges();
            }
        }

        [Test]
        public async Task getUser()
        {
            using (var db = new TourGuideContext())
            {
                var count = await db.Users.CountAsync();
                Assert.GreaterOrEqual(count, 1);
            }
        }

        [Test]
        public void addDestination()
        {
            using (var db = new TourGuideContext())
            {
                var destination = new Destination
                {
                    Name = "333333",
                    Description = "Kraj o wybitnych walorach turystycznych",
                    Places = new List<Place> {
                        new Place {
                            Name = "Tatrzański Park Narodowy",
                            Description = "Przepiękny park narodowy o wielkości 200 kilometrów kwadratowych",
                            Address = new Address
                            {
                                City = "Zakopane",
                                Country = "Polska",
                                HouseNumber = "1",
                                PostalCode = "34-500",
                                Street = "Kuźnice",
                            }
                        }
                    }
                };

                db.Add(destination);
                db.SaveChanges();
            }
        }

        [Test]
        public void getDestination()
        {
            using (var db = new TourGuideContext())
            {
                var destinations = db.Destinations
                    .ToList();

                if (destinations == null)
                {

                }
            }
        }

        [Test]
        public void addUserLocation()
        {
            using (var db = new TourGuideContext())
            {
                var admin = db.Users
                    .Where(u => u.Username.Equals("admin"))
                    .FirstOrDefault();

                var place = db.Places
                    .Where(p => p.Name.Equals("Pomnik Odkrywców"))
                    .FirstOrDefault();

                db.UserLocations.Add(
                    new UserLocation
                    {
                        User = admin,
                        BaseLocation = place
                    });
                db.SaveChanges();
            }
        }

        [Test]
        public void getUserLocation()
        {
            using (var db = new TourGuideContext())
            {
                var ul = db.UserLocations.ToList();

                if (ul == null)
                {

                }
            }
        }
    }
}
