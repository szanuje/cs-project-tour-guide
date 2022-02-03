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
    public class HotelServiceTests
    {
        readonly static string _EXISTING_DESTINATION_NAME = "DestinationName";
        readonly static string _EXISTING_DESTINATION_NAME_WITH_HOTEL = "DestinationNameWithHotel";
        readonly static string _EXISTING_HOTEL_NAME = "HotelName";
        readonly static string _EXISTING_DESTINATION_DESCRIPTION = "DestinationDescription";

        [SetUp]
        public void DerivedSetUp() 
        {
            addTestDestination();
            addTestDestinationWithHotel();
        }

        [TearDown]
        public void HotelServiceTearDown()
        {
            deleteTestDestination(_EXISTING_DESTINATION_NAME);
            deleteTestDestination(_EXISTING_DESTINATION_NAME_WITH_HOTEL);
            DeleteHotel(_EXISTING_HOTEL_NAME);
        }

        [Test]
        public void AddNewHotelTest()
        {
            var destination = getDestination(_EXISTING_DESTINATION_NAME);
            var service = new HotelService();

            // Act
            var result = service.AddNewHotel(
                 "DummyName","1", 1234, destination.DestinationId, getDummyAddress());

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void getHotelsForDestination_WhenEmptyList()
        {
            var destination = getDestination(_EXISTING_DESTINATION_NAME);
            var service = new HotelService();

            // Act
            var result = service.GetHotelsForDestination(destination.DestinationId);

            // Assert
            Assert.IsEmpty(result);
        }

        [Test]
        public void getHotelsForDestination_WhenNotEmptyList()
        {
            var destination = getDestination(_EXISTING_DESTINATION_NAME_WITH_HOTEL);
            var service = new HotelService();

            // Act
            var result = service.GetHotelsForDestination(destination.DestinationId);

            // Assert
            Assert.IsNotEmpty(result);
        }

        [Test]
        public void removeHotelTest()
        {
            var hotelId = getHotelIdForDestination(_EXISTING_DESTINATION_NAME_WITH_HOTEL);
            var service = new HotelService();

            // Act
            var result = service.RemoveHotel(hotelId);

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

        private void addTestDestinationWithHotel()
        {
            using (var db = new TourGuideContext())
            {
                var destination = db.Destinations.Where(u => u.Name.Equals(_EXISTING_DESTINATION_NAME_WITH_HOTEL)).FirstOrDefault();

                if (destination == null)
                {
                    db.Destinations.Add(new Destination()
                    {
                        Name = _EXISTING_DESTINATION_NAME_WITH_HOTEL,
                        Description = _EXISTING_DESTINATION_DESCRIPTION,
                        Hotels = new List<Hotel>() { new Hotel()
                        {
                                Name = _EXISTING_HOTEL_NAME,
                                Rating = "1",
                                Price = 1234,
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

        private Address getDummyAddress() {
            return new Address()
            {
                Country = "DummyCountry",
                City = "DummyCity",
                Street = "DummyStreet",
                PostalCode = "DummyPostalCode",
                HouseNumber = "DummyHouseNumber"
            };
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

        private int getHotelIdForDestination(string name)
        {
            using (var db = new TourGuideContext())
            {
                var destination = db.Destinations.Where(u => u.Name.Equals(name)).FirstOrDefault();

                if (destination != null)
                { 
                    return destination.Hotels.FirstOrDefault().LocationId;
                }
            }
            return -1;
        }

        private void DeleteHotel(string name)
        {
            using (var db = new TourGuideContext())
            {
                var hotel = db.Hotels.Where(u => u.Name.Equals(name)).FirstOrDefault();

                if (hotel != null)
                {
                    db.Hotels.Remove(hotel);
                    db.SaveChanges();
                }
            }
        }
    }
}
