using Microsoft.EntityFrameworkCore;
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

            //var data = new DataInit();
            //this.AddDestinations();
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
                this.Add(new Destination
                {
                    Name = "Polska",
                    Description = "Kraj o wybitnych walorach turystycznych",
                    Places = new List<Place>() 
                    {
                        new Place()
                        {
                            Name = "Tatrzański Park Narodowy",
                            Description = "Przepiękny park narodowy o wielkości 200 kilometrów kwadratowych",
                        }
                    }
                });

                this.SaveChanges();
            }
        }
        

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite(connectionString: $"Data Source={DbPath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Place>()
                .HasOne(p => p.Destination)
                .WithMany(d => d.Places)
                .HasForeignKey(p => p.DestinationFK);

            modelBuilder.Entity<Destination>()
                .HasMany(d => d.Places)
                .WithOne(p => p.Destination);

            modelBuilder.Entity<Destination>()
                .Navigation(d => d.Places)
                .AutoInclude();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
