﻿using Microsoft.EntityFrameworkCore;
using TourGuide.Domain.Data.Models;

namespace TourGuide.Domain.Data
{
    public class TourGuideContext : DbContext
    {
        public string DbPath { get; }
        public TourGuideContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "tourguide.db");

            this.Database.Migrate();
            this.EnsureAdminCreated();
            this.AddDestinations();
        }

        private void EnsureAdminCreated()
        {
            var admin = this.Users
                    .Where(u => u.Username == "admin")
                    .FirstOrDefault();

            if (admin == null)
            {
                var user = new User() { Username = "admin", Password = "admin", Admin = true };
                this.Add(user);
                this.SaveChanges();
            }
        }
        private void AddDestinations()
        {
            var destination = this.Destinations
                .Where(d => d.Name == "Polska")
                .FirstOrDefault();

            if (destination == null)
            {
                var newDestination = new Destination() { Name = "Polska", Description = "Jak w lesie" };
                var address = new Address() { City = "Krakow", Country = "Polska", HouseNumber = 5, PostalCode = 30300, Street = "Smoleńska" };
                var place = new Place() { Name = "Mazury", Description = "Jeziorka", Destination = newDestination, DestinationFK = newDestination.Id, Address = address, AddressFK = address.Id };
                newDestination.Places.Add(place);
                this.Add(newDestination);
                this.SaveChanges();
            }

            var destinationTest = this.Destinations
            .Where(d => d.Name == "Austria7")
            .FirstOrDefault();

            if (destinationTest == null)
            {
                var newDestination = new Destination() { Name = "Austria7", Description = "Jak w lesiev5" };
                var address = new Address() { City = "Ebe ebe", Country = "place", HouseNumber = 5, PostalCode = 30300, Street = "OrbanEz" };
                var place = new Place() { Name = "Mazury", Description = "Jeziorka" ,Destination = newDestination ,Address = address };
                this.Add(address);
                this.Add(newDestination);
                this.Add(place);
                this.SaveChanges();
                newDestination.Places.Add(place);

                this.Add(newDestination);

                this.SaveChanges();

          
            }

        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite(connectionString: $"Data Source={DbPath}");

        public DbSet<User> Users { get; set; }
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
