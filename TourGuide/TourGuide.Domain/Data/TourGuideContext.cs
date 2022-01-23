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
                var newDestination = new Destination() { Name = "Polska", Description = "Kraj o wybitnych walorach turystycznych" };
                var address = new Address() { City = "Zakopane", Country = "Polska", HouseNumber = 1, PostalCode = 34500, Street = "Kuźnice" };
                var place = new Place() { Name = "Tatrzański Park Narodowy", Description = "Przepiękny park narodowy o wielkości 200 kilometrów kwadratowych", Destination = newDestination, DestinationFK = newDestination.Id, Address = address, AddressFK = address.Id };
                newDestination.Places.Add(place);
                this.Add(newDestination);
                this.SaveChanges();
            }

            var destinationSpain = this.Destinations
            .Where(d => d.Name == "Hiszpania")
            .FirstOrDefault();

            if (destinationSpain == null)
            {
                var newDestination = new Destination() { Name = "Hiszpania", Description = "Państwo w zachodniej części Europy, położone na Półwyspie Iberyjskim." };
                var address = new Address() { City = "Barcelona", Country = "Hiszpania", HouseNumber = 1, PostalCode = 08002, Street = "Pla de la Seu" };
                var place = new Place() { Name = "Katedra św. Eulalii ", Description = "Jeden z cenniejszych przykładów architektury gotyckiej w Hiszpanii. ", Destination = newDestination ,Address = address };
                this.Add(address);

                var address2 = new Address() { City = "Barcelona", Country = "Hiszpania", HouseNumber = 12, PostalCode = 08028, Street = "C. d'Arístides Maillol" };
                var place2 = new Place() { Name = "Camp Nou", Description = "Stadion piłkarski w Barcelonie w Hiszpanii, na którym są rozgrywane mecze FC Barcelony.", Destination = newDestination, Address = address };
                this.Add(address2);

                this.Add(place);
                this.SaveChanges();
                newDestination.Places.Add(place);
                newDestination.Places.Add(place2);

                this.Add(newDestination);

                this.SaveChanges();
            }

            var destinationPortugal = this.Destinations
            .Where(d => d.Name == "Portugalia")
            .FirstOrDefault();

            if (destinationPortugal == null)
            {
                var portugalDestination = new Destination() { Name = "Portugalia", Description = "Najdalej wysunięte na zachód państwo Europy." };
                var address = new Address() { City = "Lizbona", Country = "Portugalia", HouseNumber = 1, PostalCode = 140038, Street = "Av. Brasília" };
                var place = new Place() { Name = "Pomnik Odkrywców", Description = "Monumentalny pomnik, znajdujący się w lizbońskiej dzielnicy Belém.", Destination = portugalDestination, Address = address };
                this.Add(address);

                var address2 = new Address() { City = "Lizbona", Country = "Portugalia", HouseNumber = 1, PostalCode = 1990005, Street = "Esplanada Dom Carlos I" };
                var place2 = new Place() { Name = "Oceanarium w Lizbonie", Description = "Największe oceanarium w Europie, w którym żyje przeszło 25 tysięcy morskich stworzeń z całego świata.", Destination = portugalDestination, Address = address };
                this.Add(address2);

                this.Add(place);
                this.SaveChanges();
                portugalDestination.Places.Add(place);
                portugalDestination.Places.Add(place2);

                this.Add(portugalDestination);

                this.SaveChanges();
            }


            var destinationEngland = this.Destinations
            .Where(d => d.Name == "Portugalia")
            .FirstOrDefault();

            if (destinationEngland == null)
            {
                var newDestination = new Destination() { Name = "Anglia", Description = "Kraj stanowiący część Zjednoczonego Królestwa Wielkiej Brytanii i Irlandii Północnej." };
                var address = new Address() { City = "Londyn", Country = "Anglia", HouseNumber = 1, PostalCode = 0, Street = "Great Russell St" };
                var place = new Place() { Name = "Muzeum Brytyjskie", Description = "Muzeum narodowe z siedzibą w Londynie, największe muzeum Wielkiej Brytanii i jedno z największych na świecie", Destination = newDestination, Address = address };
                this.Add(address);

                var address2 = new Address() { City = "Londyn", Country = "Anglia", HouseNumber = 1, PostalCode = 0, Street = "Riverside Building" };
                var place2 = new Place() { Name = "London Eye", Description = "Koło obserwacyjne znajdujące się w dzielnicy Lambeth w Londynie, na południowym brzegu Tamizy, między mostami Westminster i Hungerford.", Destination = newDestination, Address = address };
                this.Add(address2);

                this.Add(place);
                this.SaveChanges();
                newDestination.Places.Add(place);
                newDestination.Places.Add(place2);

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
