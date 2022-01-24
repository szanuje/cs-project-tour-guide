using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourGuide.Domain.Data.Models;

namespace TourGuide.Domain.Data
{
    public class DataInit
    {

        public void AddDestinations(TourGuideContext db)
        {

            var destination = db.Destinations
                .Where(d => d.Name == "Polska")
                .FirstOrDefault();

            if (destination == null)
            {
                db.Add(new Destination
                {
                    Name = "Polska",
                    Description = "Kraj o wybitnych walorach turystycznych",
                    Places = new List<Place>()
                    {
                        new Place()
                        {
                            Name = "Tatrzański Park Narodowy",
                            Description = "Przepiękny park narodowy o wielkości 200 kilometrów kwadratowych",
                            Address = new Address
                            {
                                City = "Zakopane",
                                Country = "Polska",
                                HouseNumber = 1,
                                PostalCode = "34-500",
                                Street = "Kuźnice"
                            }
                        }
                    }
                });

                db.SaveChanges();
            }

            var destinationSpain = db.Destinations
            .Where(d => d.Name == "Hiszpania")
            .FirstOrDefault();

            if (destinationSpain == null)
            {
                db.Add(new Destination
                {
                    Name = "Hiszpania",
                    Description = "Państwo w zachodniej części Europy, położone na Półwyspie Iberyjskim.",
                    Places = new List<Place>()
                    {
                        new Place()
                        {
                            Name = "Katedra św. Eulalii",
                            Description = "Jeden z cenniejszych przykładów architektury gotyckiej w Hiszpanii. ",
                            Address = new Address
                            {
                                City = "Barcelona",
                                Country = "Hiszpania",
                                HouseNumber = 1,
                                PostalCode = "08002",
                                Street = "Pla de la Seu"
                            }
                        },
                        new Place()
                        {
                            Name = "Camp Nou",
                            Description = "Jeden z cenniejszych przykładów architektury gotyckiej w Hiszpanii. ",
                            Address = new Address
                            {
                                City = "Barcelona",
                                Country = "Hiszpania",
                                HouseNumber = 12,
                                PostalCode = "08028",
                                Street = "C. d'Arístides Maillol"
                            }
                        }
                    }
                });

                db.SaveChanges();
            }
            
            var destinationPortugal = db.Destinations
            .Where(d => d.Name == "Portugalia")
            .FirstOrDefault();

            if (destinationPortugal == null)
            {
                db.Add(new Destination
                {
                    Name = "Portugalia",
                    Description = "Najdalej wysunięte na zachód państwo Europy.",
                    Places = new List<Place>()
                    {
                        new Place()
                        {
                            Name = "Pomnik Odkrywców",
                            Description = "Monumentalny pomnik, znajdujący się w lizbońskiej dzielnicy Belém.",
                            Address = new Address
                            {
                                City = "Lizbona",
                                Country = "Portugalia",
                                HouseNumber = 1,
                                PostalCode = "140038",
                                Street = "Av. Brasília"
                            }
                        },
                        new Place()
                        {
                            Name = "Oceanarium w Lizbonie",
                            Description = "Największe oceanarium w Europie, w którym żyje przeszło 25 tysięcy morskich stworzeń z całego świata.",
                            Address = new Address
                            {
                                City = "Lizbona",
                                Country = "Portugalia",
                                HouseNumber = 1,
                                PostalCode = "1990005",
                                Street = "Esplanada Dom Carlos I"
                            }
                        }
                    }
                });

                db.SaveChanges();
            }

            var destinationEngland = db.Destinations
            .Where(d => d.Name == "Anglia")
            .FirstOrDefault();

            if (destinationEngland == null)
            {
                db.Add(new Destination
                {
                    Name = "Anglia",
                    Description = "Kraj stanowiący część Zjednoczonego Królestwa Wielkiej Brytanii i Irlandii Północnej.",
                    Places = new List<Place>()
                    {
                        new Place()
                        {
                            Name = "Muzeum Brytyjskie",
                            Description = "Monumentalny pomnik, znajdujący się w lizbońskiej dzielnicy Belém.",
                            Address = new Address
                            {
                                City = "Londyn",
                                Country = "Anglia",
                                HouseNumber = 1,
                                PostalCode = "0",
                                Street = "Great Russell St"
                            }
                        },
                        new Place()
                        {
                            Name = "London Eye",
                            Description = "Największe oceanarium w Europie, w którym żyje przeszło 25 tysięcy morskich stworzeń z całego świata.",
                            Address = new Address
                            {
                                City = "Londyn",
                                Country = "Anglia",
                                HouseNumber = 1,
                                PostalCode = "0",
                                Street = "Riverside Building"
                            }
                        }
                    }
                });
                db.SaveChanges();
            }
        }
    }
}
