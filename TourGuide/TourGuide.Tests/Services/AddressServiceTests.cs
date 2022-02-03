using NUnit.Framework;
using System;
using System.Linq;
using TourGuide.Domain.Data;
using TourGuide.Domain.Services;

namespace TourGuide.Tests.Services
{
    [TestFixture]
    public class AddressServiceTests
    {
        readonly static string _USERNAME_TEST = "kajsdfSAIUHWDndkvjnSDIFOUHWEQRHqwe";
        readonly static string _PASSWORD_TEST = "123";

        [Test]
        public void AddNewAddressTest()
        {
            var service = new AddressService();
            String country = "DummyCountry";
            String city = "DummyCity";
            String street = "DummyStreet";
            String postal_code = "DummyPostalCode";
            String house_number = "DummyHouseNumber";

            // Act
            var result = service.AddNewAddress(
                country,
                city,
                street,
                postal_code, 
                house_number);

            // Assert
            Assert.IsTrue(result);
        }

    }
}
