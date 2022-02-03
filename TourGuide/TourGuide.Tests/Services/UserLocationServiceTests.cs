using NUnit.Framework;
using System.Linq;
using TourGuide.Domain.Data;
using TourGuide.Domain.Services;
using TourGuide.Domain.Data.Models;
using System.Collections.Generic;

namespace TourGuide.Tests.Services
{
    [TestFixture]
    public class UserLocationServiceTests
    {
        readonly static string _USERNAME_TEST = "kajsdfSAIUHWDndkvjnSDIFOUHWEQRHqwe";
        readonly static string _USERNAME_WITH_LOCATION_TEST = "kajsdfSAIUHWDndkvjnSDIFOUsdasdsaHWEQRHqwe";
        readonly static string _PASSWORD_TEST = "123";
        readonly static string _EXISTING_DESTINATION_WITH_PLACE_NAME = "DummyDestinationTest";
        readonly static string _PLACE_NAME_TEST = "DummyPlace";
        readonly static string _DESCRIPTION_TEST = "DummyDescription";

        [SetUp]
        public void DerivedSetUp() 
        {
            this.AddTestUser(_USERNAME_TEST);
            this.AddTestUser(_USERNAME_WITH_LOCATION_TEST);
            this.addTestDestinationWithPlace();
        }

        [TearDown]
        public void UserServiceTearDown()
        {
            this.DeleteTestUser();
        }

        [Test]
        public void AddLocationToUserTest()
        {
            var testPlace = getPlace(_PLACE_NAME_TEST);
            var service = new UserLocationService();

            // Act
            var result = service.AddLocationToUser(testPlace.LocationId, _USERNAME_TEST);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void RemoveLocationFromUserTest()
        {
            var testPlace = getPlace(_PLACE_NAME_TEST);
            addLocationToUser(_USERNAME_WITH_LOCATION_TEST, testPlace.LocationId);
            var service = new UserLocationService();

            // Act
            var result = service.RemoveLocationFromUser(testPlace.LocationId, _USERNAME_WITH_LOCATION_TEST);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void GetAllUserPlacesTest()
        {
            addLocationToUser(_USERNAME_WITH_LOCATION_TEST, getPlace(_PLACE_NAME_TEST).LocationId);
            var service = new UserLocationService();

            // Act
            var result = service.GetAllUserPlaces(_USERNAME_WITH_LOCATION_TEST);

            // Assert
            var expected = new List<Place> { getPlace(_PLACE_NAME_TEST) };
            Assert.AreEqual(result.Count, 1);
            Assert.AreEqual(expected.Count, 1);

            var expectedPlace = expected.First();
            var resultPlace = result.First();
            Assert.AreEqual(resultPlace.Name, expectedPlace.Name);
            Assert.AreEqual(resultPlace.Description, expectedPlace.Description);
            Assert.AreEqual(resultPlace.LocationId, expectedPlace.LocationId);
        }

        private void AddTestUser(string name)
        {
            using (var db = new TourGuideContext())
            {
                var user = db.Users.Where(u => u.Username.Equals(name)).FirstOrDefault();

                if (user == null)
                {
                    db.Users.Add(new Domain.Data.Models.User()
                    {
                        Username = name,
                        Password = _PASSWORD_TEST,
                        Name = "Name",
                        Surname = "Surname"
                    });
                    db.SaveChanges();
                }
            }
        }

        private void addLocationToUser(string name, int locationId)
        {
            using (var db = new TourGuideContext())
            {
                if (!db.UserLocations.Any(ub => ub.LocationId == locationId && ub.Username == name))
                {
                    db.Add(new UserLocation()
                    {
                        Username = name,
                        LocationId = locationId,
                    });

                    db.SaveChanges();
                }
            }
        }


        private void addTestDestinationWithPlace()
        {
            using (var db = new TourGuideContext())
            {
                var destination = db.Destinations.Where(u => u.Name.Equals(_EXISTING_DESTINATION_WITH_PLACE_NAME)).FirstOrDefault();

                if (destination == null)
                {
                    db.Destinations.Add(new Destination()
                    {
                        Name = _EXISTING_DESTINATION_WITH_PLACE_NAME,
                        Description = _DESCRIPTION_TEST,
                        Places = new List<Place>() { new Place()
                        {
                                Name = _PLACE_NAME_TEST,
                                Description = "DummyDescription",
                                Address = new Address()
                                    {
                                        Country = "DummyCountry",
                                        City = "DummyCity",
                                        Street = "DummyStreet",
                                        PostalCode = "DummyPostalCode",
                                        HouseNumber = "DummyHouseNumber"
                                    },
                                Locations = new List<UserLocation>() { }
                            }
                        }
                    });
                    db.SaveChanges();
                }
            }
        }

        private Place getPlace(string name)
        {
            using (var db = new TourGuideContext())
            {
                var place = db.Places.Where(u => u.Name.Equals(name)).FirstOrDefault();

                if (place == null)
                {
                    return null;
                }
                return place;
            }
        }

        private void DeleteTestUser()
        {
            using (var db = new TourGuideContext())
            {
                var user = db.Users.Where(u => u.Username.Equals(_USERNAME_TEST)).FirstOrDefault();

                if (user != null)
                {
                    db.Users.Remove(user);
                    db.SaveChanges();
                }
            }
        }
    }
}
