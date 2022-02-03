using NUnit.Framework;
using System;
using System.Linq;
using TourGuide.Domain.Data;
using TourGuide.Domain.Services;
using TourGuide.Domain.Data.Models;

namespace TourGuide.Tests.Services
{
    [TestFixture]
    public class DestinationServiceTests
    {
        readonly static string _COUNTRY_TEST = "DummyCountry";

        [SetUp]
        public void DerivedSetUp() 
        {
            this.DeleteTestDestination();
        }

        [TearDown]
        public void DestinationServiceTearDown()
        {
            this.DeleteTestDestination();
        }

        [Test]
        public void AddNewDestinationTest()
        {
            var service = new DestinationService();

            // Act
            var result = service.AddNewDestination(_COUNTRY_TEST, "dummyDescription");

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void GetDestination_Destination_Exists()
        {
            var description = "DummyDescription";
            addDestinationToDatabase(_COUNTRY_TEST, description);
            var service = new DestinationService();

            // Act
            var result = service.GetDestination(_COUNTRY_TEST);

            // Assert
            var expected = getExpectedDestination();
            Assert.AreEqual(expected.Name, result.Name);
            Assert.AreEqual(expected.Description, result.Description);
            Assert.NotNull(result.DestinationId);
            Assert.IsEmpty(result.Hotels);
            Assert.IsEmpty(result.Places);
        }

        [Test]
        public void GetDestination_Destination_Not_Exists()
        {
            var dummyName = "dummyPlaceHolderForDestinationName";
            var service = new DestinationService();

            // Act
            var result = service.GetDestination(dummyName);

            // Assert
            Assert.Null(result);
        }

        private Destination getExpectedDestination() {
            return new Destination()
            {
                Name = _COUNTRY_TEST,
                Description = "DummyDescription"
            };
        }

        private void addDestinationToDatabase(string name, string description) {
            using (var db = new TourGuideContext())
            {
                var destination = db.Destinations.Where(u => u.Name.Equals(name)).FirstOrDefault();

                if (destination == null)
                {
                    db.Destinations.Add(new Destination() { 
                        Name = name,
                        Description = description
                    });
                    db.SaveChanges();
                }
            }
        }

        private void DeleteTestDestination()
        {
            using (var db = new TourGuideContext())
            {
                var destination = db.Destinations.Where(u => u.Name.Equals(_COUNTRY_TEST)).FirstOrDefault();

                if (destination != null)
                {
                    db.Destinations.Remove(destination);
                    db.SaveChanges();
                }
            }
        }

    }
}
