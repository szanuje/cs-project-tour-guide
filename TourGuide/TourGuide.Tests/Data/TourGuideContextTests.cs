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
                    Places = new List<Place> { new Place { Name = "Tatrzański Park Narodowy",
                        Description = "Przepiękny park narodowy o wielkości 200 kilometrów kwadratowych", } }
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
                var destinatinon = db.Destinations
                    .ToList();

                if (destinatinon == null)
                {

                }


                /*
                var dest = (from d in db.Destinations
                            select new Destination
                            {
                                Name=d.Name,
                                Description=d.Description,
                                Places = db.Places.Where(p => 
                                    p.DestinationId == d.DestinationId).ToList()
                            }).ToList();

                foreach (var d in dest)
                {
                    if(d == null)
                    {

                    }
                }*/
            }
        }
    }
}
