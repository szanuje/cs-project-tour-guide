using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
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
    }
}
