using NUnit.Framework;
using System.Linq;
using TourGuide.Domain.Data;
using TourGuide.Domain.Services;
using TourGuide.Domain.Data.Models;
using System.Collections;
using System.Collections.Generic;

namespace TourGuide.Tests.Services
{
    [TestFixture]
    public class PlaceServiceTests
    {
        readonly static string _EXISTING_DESTINATION_NAME = "DestinationName";
        readonly static string _EXISTING_DESTINATION_WITH_PLACE_NAME = "DestinationWithPlaceName";
        readonly static string _EXISTING_DESTINATION_DESCRIPTION = "DestinationDescription";


        [SetUp]
        public void DerivedSetUp() 
        {
            addTestDestination();
            addTestDestinationWithPlace();
        }

        [TearDown]
        public void PlaceServiceTearDown()
        {
            deleteTestDestination(_EXISTING_DESTINATION_NAME);
            deleteTestDestination(_EXISTING_DESTINATION_WITH_PLACE_NAME);
        }


        [Test]
        public void AddNewPlaceTest()
        {
            var destination = getDestination(_EXISTING_DESTINATION_NAME);
            var service = new PlaceService();

            // Act
            var result = service.AddNewPlace(
                 "DummyName", "DummyDescription", destination.DestinationId, getDummyAddress());

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void getPlacesForDestination_WhenEmptyList()
        {
            var destination = getDestination(_EXISTING_DESTINATION_NAME);
            var service = new PlaceService();

            // Act
            var result = service.GetPlacesForDestination(destination.DestinationId);

            // Assert
            Assert.IsEmpty(result);
        }

        [Test]
        public void getPlacesForDestination_WhenNotEmptyList()
        {
            var destination = getDestination(_EXISTING_DESTINATION_WITH_PLACE_NAME);
            var service = new PlaceService();

            // Act
            var result = service.GetPlacesForDestination(destination.DestinationId);

            // Assert
            Assert.IsNotEmpty(result);
        }

        [Test]
        public void removePlaceTest()
        {
            var placeId = getPlaceIdForDestination(_EXISTING_DESTINATION_WITH_PLACE_NAME);
            var service = new PlaceService();

            // Act
            var result = service.RemovePlace(placeId);

            // Assert
            Assert.IsTrue(result);
        }


        private void addTestDestination() {
            using (var db = new TourGuideContext())
            {
                var destination = db.Destinations.Where(u => u.Name.Equals(_EXISTING_DESTINATION_NAME)).FirstOrDefault();

                if (destination == null)
                {
                    db.Destinations.Add(new Destination() { 
                        Name = _EXISTING_DESTINATION_NAME,
                        Description = _EXISTING_DESTINATION_DESCRIPTION
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
                        Description = _EXISTING_DESTINATION_DESCRIPTION,
                        Places = new List<Place>() { new Place()
                        {
                                Name = "DummyHotel",
                                Description = "DummyDescription",
                                Address = new Address()
                                    {
                                        Country = "DummyCountry",
                                        City = "DummyCity",
                                        Street = "DummyStreet",
                                        PostalCode = "DummyPostalCode",
                                        HouseNumber = "DummyHouseNumber"
                                    },
                                Locations = new List<UserLocation>()
                            }
                        }
                    });
                    db.SaveChanges();
                }
            }
        }

        private int getPlaceIdForDestination(string name)
        {
            using (var db = new TourGuideContext())
            {
                var destination = db.Destinations.Where(u => u.Name.Equals(name)).FirstOrDefault();

                if (destination != null)
                {
                    return destination.Places.FirstOrDefault().LocationId;
                }
            }
            return -1;
        }

        private Destination getDestination(string name)
        {
            using (var db = new TourGuideContext())
            {
                var destination = db.Destinations.Where(u => u.Name.Equals(name)).FirstOrDefault();

                if (destination != null)
                {
                    return destination;
                }
            }
            return null;
        }

        private void deleteTestDestination(string name)
        {
            using (var db = new TourGuideContext())
            {
                var destination = db.Destinations.Where(u => u.Name.Equals(name)).FirstOrDefault();

                if (destination != null)
                {
                    db.Destinations.Remove(destination);
                    db.SaveChanges();
                }
            }
        }

        private Address getDummyAddress()
        {
            return new Address()
            {
                Country = "DummyCountry",
                City = "DummyCity",
                Street = "DummyStreet",
                PostalCode = "DummyPostalCode",
                HouseNumber = "DummyHouseNumber"
            };
        }

    }
}
