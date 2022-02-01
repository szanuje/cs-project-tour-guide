// ***********************************************************************
// Assembly         : TourGuide.Domain
// Author           : szanu
// Created          : 01-28-2022
//
// Last Modified By : szanu
// Last Modified On : 02-01-2022
// ***********************************************************************
// <copyright file="DataInit.cs" company="TourGuide.Domain">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using TourGuide.Domain.Data.Models;

namespace TourGuide.Domain.Data
{
    /// <summary>
    /// Class DataInit.
    /// </summary>
    public class DataInit
    {
        /// <summary>
        /// Adds the destinations.
        /// </summary>
        /// <param name="db">The database.</param>
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
                                HouseNumber = "1",
                                PostalCode = "34-500",
                                Street = "Kuźnice",
                                lat = 49.27141297798237,
                                lng = 19.98262598104344
                            }
                        }
                    },
                    Hotels = new List<Hotel>()
                    {
                        new Hotel()
                        {
                            Name = "Hotel Marriott",
                            Rating = "5/5",
                            Price = 1199.9m,
                            Address = new Address
                            {
                                City = "Warszawa",
                                Country = "Polska",
                                HouseNumber = "79",
                                PostalCode = "00-697",
                                Street = "al. Jerozolimskie 65",
                                lat = 52.228245070997936,
                                lng = 21.004389484656446
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
                                HouseNumber = "1",
                                PostalCode = "08002",
                                Street = "Pla de la Seu",
                                lat = 41.38399417837509, 
                                lng = 2.1762098268703975
                            }
                        },
                        new Place()
                        {
                            Name = "Camp Nou",
                            Description = "Stadion piłkarski na którym są rozgrywane mecze FC Barcelona. ",
                            Address = new Address
                            {
                                City = "Barcelona",
                                Country = "Hiszpania",
                                HouseNumber = "12",
                                PostalCode = "08028",
                                Street = "C. d'Arístides Maillol",
                                lat = 41.38097458889179, 
                                lng = 2.122872658540742
                            }
                        }
                    },
                    Hotels = new List<Hotel>()
                    {
                        new Hotel()
                        {
                            Name = "Wilson Boutique Hotel",
                            Rating = "5/5",
                            Price = 1199.9m,
                            Address = new Address
                            {
                                City = "Barcelona",
                                Country = "Hiszpania",
                                HouseNumber = "568",
                                PostalCode = "08-021",
                                Street = "Avinguda Diagonal",
                                lat = 41.3949276085681, 
                                lng = 2.1499965692942924
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
                                HouseNumber = "1",
                                PostalCode = "140038",
                                Street = "Av. Brasília",
                                lat = 38.693664270348975, 
                                lng = -9.20569004435341
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
                                HouseNumber = "1",
                                PostalCode = "1990005",
                                Street = "Esplanada Dom Carlos I",
                                lat = 38.7635853078075, 
                                lng = -9.093752230857477
                            }
                        }
                    },
                    Hotels = new List<Hotel>()
                    {
                        new Hotel()
                        {
                            Name = "Wilson Boutique Hotel",
                            Rating = "5/5",
                            Price = 1199.9m,
                            Address = new Address
                            {
                                City = "Lizbona",
                                Country = "Portugalia",
                                HouseNumber = "88",
                                PostalCode = "1150-266",
                                Street = "R. das Portas de Santo Antao",
                                lat = 38.71667931664545,
                                lng = -9.140503730687097
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
                            Description = "Muzeum narodowe z siedzibą w Londynie, największe muzeum Wielkiej Brytanii i jedno z największych na świecie",
                            Address = new Address
                            {
                                City = "Londyn",
                                Country = "Anglia",
                                HouseNumber = "1",
                                PostalCode = "0",
                                Street = "Great Russell St",
                                lat = 51.51944665958745, 
                                lng = -0.1270317035546863
                            }
                        },
                        new Place()
                        {
                            Name = "London Eye",
                            Description = "Koło obserwacyjne znajdujące się w dzielnicy Lambeth w Londynie, na południowym brzegu Tamizy.",
                            Address = new Address
                            {
                                City = "Londyn",
                                Country = "Anglia",
                                HouseNumber = "1",
                                PostalCode = "0",
                                Street = "Riverside Building",
                                lat = 51.50331063628315, 
                                lng = -0.11957515937929862
                            }
                        }
                    },
                    Hotels = new List<Hotel>()
                    {
                        new Hotel()
                        {
                            Name = "Kimpton Fitzroy London Hotel",
                            Rating = "5/5",
                            Price = 1440.0m,
                            Address = new Address
                            {
                                City = "Londyn",
                                Country = "Wielka Brytania",
                                HouseNumber = "1",
                                PostalCode = "WC1B 5BE",
                                Street = "Russell Square",
                                lat = 51.52312233625544,
                                lng = -0.12524934603064714
                            }
                        }
                    }
                });
                db.SaveChanges();
            }
        }
    }
}
