using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Threading.Tasks;
using TourGuide.models;

namespace TourGuideTests.models
{
    [TestFixture]
    public class SampleDbContextTests
    {
        [Test]
        public async Task TestMethod_UsingInMemoryProvider()
        {    
            // The database name allows the scope of the in-memory database
             // to be controlled independently of the context. The in-memory database is shared
             // anywhere the same name is used.
            var options = new DbContextOptionsBuilder<SampleDbContext>()
                .UseInMemoryDatabase(databaseName: "Test1")
                .Options;

            using (var context = new SampleDbContext(options))
            {
                var user = new User() { Email = "test@sample.com" };
                context.Users.Add(user);
                await context.SaveChangesAsync();
            }

            // New context with the data as the database name is the same
            using (var context = new SampleDbContext(options))
            {
                var count = await context.Users.CountAsync();
                Assert.AreEqual(1, count);

                var u = await context.Users.FirstOrDefaultAsync(user => user.Email == "test@sample.com");
                Assert.IsNotNull(u);
            }

        }
    }
}
