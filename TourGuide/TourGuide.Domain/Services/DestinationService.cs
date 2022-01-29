// ***********************************************************************
// Assembly         : TourGuide.Domain
// Author           : szanu
// Created          : 01-22-2022
//
// Last Modified By : szanu
// Last Modified On : 01-22-2022
// ***********************************************************************
// <copyright file="DestinationService.cs" company="TourGuide.Domain">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using TourGuide.Domain.Data;
using TourGuide.Domain.Data.Models;

namespace TourGuide.Domain.Services
{
    /// <summary>
    /// Class DestinationService.
    /// </summary>
    public class DestinationService
    {
        /// <summary>
        /// Adds the new destination.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="description">The description.</param>
        /// <returns><c>true</c> if destination added, <c>false</c> otherwise.</returns>
        public bool AddNewDestination(String name, String description)
        {
            using (var db = new TourGuideContext())
            {
                if (db.Destinations.Any(d => d.Name.ToLower().Equals(name.ToLower())))
                {
                    return false;
                }

                var destination = new Destination() { Name = name, Description = description };
                db.Add(destination);
                int entries = db.SaveChanges();

                return entries > 0;
            }
        }

        /// <summary>
        /// Gets the destination.
        /// </summary>
        /// <param name="name">The name of destination.</param>
        /// <returns>Destination.</returns>
        public Destination GetDestination(String name)
        {
            using (var db = new TourGuideContext())
            {
                return db.Destinations
                    .Where(d => d.Name == name)
                    .FirstOrDefault();
            }
        }

        /// <summary>
        /// Gets all destinations.
        /// </summary>
        /// <returns>List&lt;Destination&gt;.</returns>
        public List<Destination> GetAllDestinations()
        {
            using (var db = new TourGuideContext())
            {
                return db.Destinations.ToList();
            }
        }
    }
}
