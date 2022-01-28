// ***********************************************************************
// Assembly         : TourGuide.Domain
// Author           : szanu
// Created          : 01-22-2022
//
// Last Modified By : szanu
// Last Modified On : 01-28-2022
// ***********************************************************************
// <copyright file="HotelService.cs" company="TourGuide.Domain">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using TourGuide.Domain.Data;
using TourGuide.Domain.Data.Models;

namespace TourGuide.Domain.Services
{
    /// <summary>
    /// Class HotelService.
    /// </summary>
    public class HotelService
    {
        /// <summary>
        /// Adds the new hotel.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="rating">The rating.</param>
        /// <param name="price">The price.</param>
        /// <param name="destination">The destination.</param>
        /// <param name="address">The address.</param>
        /// <returns><c>true</c> if hotel added, <c>false</c> otherwise.</returns>
        public bool AddNewHotel(String name, String rating, Double price,
            Destination destination, Address address)
        {
            using (var db = new TourGuideContext())
            {
                var hotel = new Hotel()
                {
                    Name = name,
                    Rating = rating,
                    Price = price,
                    //Destination = destination,
                    Address = address
                };
                db.Add(hotel);
                int entries = db.SaveChanges();

                return entries > 0;
            }

        }

        /// <summary>
        /// Gets all hotels for trip.
        /// </summary>
        /// <param name="tripPlaces">The trip places.</param>
        /// <returns>ICollection&lt;Hotel&gt;.</returns>
        public ICollection<Hotel> GetAllHotelsForTrip(IList<Place> tripPlaces)
        {
            return tripPlaces.SelectMany(p => p.Destination.Hotels).ToHashSet();
        }
    }
}
