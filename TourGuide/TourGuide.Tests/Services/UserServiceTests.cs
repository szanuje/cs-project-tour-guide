using NUnit.Framework;
using System;
using System.Linq;
using TourGuide.Domain.Data;
using TourGuide.Domain.Services;

namespace TourGuide.Tests.Services
{
    [TestFixture]
    public class UserServiceTests
    {
        readonly static string _USERNAME_TEST = "kajsdfSAIUHWDndkvjnSDIFOUHWEQRHqwe";
        readonly static string _PASSWORD_TEST = "123";

        [SetUp]
        public void DerivedSetUp() 
        {
            this.DeleteTestUser();
        }

        [TearDown]
        public void UserServiceTearDown()
        {
            this.DeleteTestUser();
        }

        [Test]
        public void AddNewUser_UserAdded()
        {
            // Arrange
            var service = new UserService();
            String username = _USERNAME_TEST;
            String name = "Name";
            String surname = "Lastname";
            String password = _PASSWORD_TEST;

            // Act
            var result = service.AddNewUser(
                username,
                name,
                surname,
                password);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void LoginUser_UserExists_ReturnsUser()
        {
            // Arrange
            this.AddTestUser();
            var service = new UserService();

            // Act
            var result = service.LoginUser(
                _USERNAME_TEST,
                _PASSWORD_TEST);

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void LoginUser_UserDoesntExists_ReturnsNull()
        {
            // Arrange
            var service = new UserService();

            // Act
            var result = service.LoginUser(
                _USERNAME_TEST,
                _PASSWORD_TEST);

            // Assert
            Assert.IsNull(result);
        }

        private void AddTestUser()
        {
            using (var db = new TourGuideContext())
            {
                var user = db.Users.Where(u => u.Username.Equals(_USERNAME_TEST)).FirstOrDefault();

                if (user == null)
                {
                    db.Users.Add(new Domain.Data.Models.User()
                    {
                        Username = _USERNAME_TEST,
                        Password = "123",
                        Name = "Name",
                        Surname = "Surname"
                    });
                    db.SaveChanges();
                }
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
