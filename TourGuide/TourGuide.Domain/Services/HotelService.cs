// ***********************************************************************
// Assembly         : TourGuide.Domain
// Author           : szanu
// Created          : 01-22-2022
//
// Last Modified By : szanu
// Last Modified On : 02-01-2022
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
        /// <param name="destinationId">The destination identifier.</param>
        /// <param name="address">The address.</param>
        /// <returns><c>true</c> if hotel added, <c>false</c> otherwise.</returns>
        public bool AddNewHotel(String name, String rating, String price,
            int destinationId, Address address)
        {
            using (var db = new TourGuideContext())
            {
                var hotel = new Hotel()
                {
                    Name = name,
                    Rating = rating,
                    Price = price,
                    DestinationFK = destinationId,
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
            using (var db = new TourGuideContext())
            {
                if (tripPlaces == null || tripPlaces.Count == 0)
                {
                    return new HashSet<Hotel>();
                }

                HashSet<Hotel> hotels = new HashSet<Hotel>();

                foreach (Place place in tripPlaces)
                {
                    var dest = db.Destinations.Where(d => d.DestinationId == place.DestinationFK).FirstOrDefault();
                    hotels.UnionWith(dest.Hotels);
                }

                return hotels;
            }
        }

        /// <summary>
        /// Gets the hotels for destination.
        /// </summary>
        /// <param name="destinationId">The destination identifier.</param>
        /// <returns>List&lt;Hotel&gt;.</returns>
        public List<Hotel> GetHotelsForDestination(int destinationId)
        {
            using (var db = new TourGuideContext())
            {
                var destination = db.Destinations
                    .Where(d => d.DestinationId == destinationId)
                    .FirstOrDefault();

                if (destination == null) return new List<Hotel>();

                return destination.Hotels;
            }
        }

        /// <summary>
        /// Removes the hotel.
        /// </summary>
        /// <param name="locationId">The location identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool RemoveHotel(int locationId)
        {
            using (var db = new TourGuideContext())
            {
                var hotel = db.Hotels
                    .Where(d => d.LocationId == locationId)
                    .FirstOrDefault();

                if (hotel == null) return false;

                db.Hotels.Remove(hotel);
                int entries = db.SaveChanges();

                return entries > 0;
            }
        }
    }
}
