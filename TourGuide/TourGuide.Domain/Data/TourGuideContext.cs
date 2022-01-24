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

            var data = new DataInit();
            data.AddDestinations(this);
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

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite(connectionString: $"Data Source={DbPath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BaseLocation>()
                .HasOne(b => b.Address)
                .WithOne(a => a.BaseLocation)
                .HasForeignKey<Address>(a => a.BaseLocationFK);

            modelBuilder.Entity<Place>()
                .HasOne(p => p.Destination)
                .WithMany(d => d.Places)
                .HasForeignKey(p => p.DestinationFK);

            modelBuilder.Entity<Hotel>()
                .HasOne(h => h.Destination)
                .WithMany(d => d.Hotels)
                .HasForeignKey(h => h.DestinationFK);

            modelBuilder.Entity<Destination>()
                .HasMany(d => d.Places)
                .WithOne(p => p.Destination)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Destination>()
                .Navigation(d => d.Places)
                .AutoInclude();

            modelBuilder.Entity<Place>()
                .Navigation(p => p.Address)
                .AutoInclude();

            modelBuilder.Entity<Hotel>()
                .Navigation(h => h.Address)
                .AutoInclude();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
