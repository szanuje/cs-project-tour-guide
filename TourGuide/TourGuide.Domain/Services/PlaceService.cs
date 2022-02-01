// ***********************************************************************
// Assembly         : TourGuide.Domain
// Author           : Konrad Ulman
// Created          : 02-01-2022
//
// Last Modified By : Konrad Ulman
// Last Modified On : 02-01-2022
// ***********************************************************************
// <copyright file="PlaceService.cs" company="TourGuide.Domain">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using TourGuide.Domain.Data;
using TourGuide.Domain.Data.Models;

namespace TourGuide.Domain.Services
{
    /// <summary>
    /// Class PlaceService.
    /// </summary>
    public class PlaceService
    {
        /// <summary>
        /// Gets the places for destination.
        /// </summary>
        /// <param name="destinationId">The destination identifier.</param>
        /// <returns>List&lt;Place&gt;.</returns>
        public List<Place> GetPlacesForDestination(int destinationId)
        {
            using (var db = new TourGuideContext())
            {
                var destination = db.Destinations
                    .Where(d => d.DestinationId == destinationId)
                    .FirstOrDefault();

                if (destination == null) return new List<Place>();

                return destination.Places;
            }
        }

        /// <summary>
        /// Adds the new place.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="description">The description.</param>
        /// <param name="destinationId">The destination identifier.</param>
        /// <param name="address">The address.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool AddNewPlace(String name, String description,
            int destinationId, Address address)
        {
            using (var db = new TourGuideContext())
            {
                var destination = db.Destinations.FirstOrDefault(d => d.DestinationId == destinationId);

                if (destination == null) return false;

                var place = new Place()
                {
                    Name = name,
                    Description = description,
                    DestinationFK = destinationId,
                    Destination = destination,
                    Address = address
                };

                db.Add(place);
                int entries = db.SaveChanges();

                return entries > 0;
            }
        }
        /// <summary>
        /// Removes the place.
        /// </summary>
        /// <param name="locationId">The location identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool RemovePlace(int locationId)
        {
            using (var db = new TourGuideContext())
            {
                var place = db.Places
                    .Where(d => d.LocationId == locationId)
                    .FirstOrDefault();

                if (place == null) return false;

                db.Places.Remove(place);
                int entries = db.SaveChanges();

                return entries > 0;
            }
        }
    }
}
