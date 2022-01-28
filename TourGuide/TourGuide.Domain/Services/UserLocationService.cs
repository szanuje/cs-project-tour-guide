// ***********************************************************************
// Assembly         : TourGuide.Domain
// Author           : szanu
// Created          : 01-28-2022
//
// Last Modified By : szanu
// Last Modified On : 01-28-2022
// ***********************************************************************
// <copyright file="UserLocationService.cs" company="TourGuide.Domain">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using TourGuide.Domain.Data;
using TourGuide.Domain.Data.Models;

namespace TourGuide.Domain.Services
{
    /// <summary>
    /// Class UserLocationService.
    /// </summary>
    public class UserLocationService
    {
        /// <summary>
        /// Adds the location to user.
        /// </summary>
        /// <param name="locationId">The location identifier.</param>
        /// <param name="username">The username.</param>
        /// <returns><c>true</c> if location added, <c>false</c> otherwise.</returns>
        public bool AddLocationToUser(int locationId, string username)
        {
            using (var db = new TourGuideContext())
            {
                if (db.UserLocations.Any(ub => ub.LocationId == locationId && ub.Username == username))
                {
                    return false;
                }

                db.Add(new UserLocation()
                {
                    Username = username,
                    LocationId = locationId,
                });

                int entries = db.SaveChanges();
                return entries > 0;
            }
        }

        /// <summary>
        /// Removes the location from user.
        /// </summary>
        /// <param name="locationId">The location identifier.</param>
        /// <param name="username">The username.</param>
        /// <returns><c>true</c> if location removed, <c>false</c> otherwise.</returns>
        public bool RemoveLocationFromUser(int locationId, string username)
        {
            using (var db = new TourGuideContext())
            {
                if (!db.UserLocations.Any(ub => ub.LocationId == locationId && ub.Username == username))
                {
                    return false;
                }

                db.Remove(new UserLocation()
                {
                    Username = username,
                    LocationId = locationId,
                });

                int entries = db.SaveChanges();
                return entries > 0;
            }
        }

        /// <summary>
        /// Gets all user places.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns>List&lt;Place&gt;.</returns>
        public List<Place> GetAllUserPlaces(string username)
        {
            List<UserLocation> locations = GetAllUserLocations(username);
            return locations.Select(loc => (Place)loc.BaseLocation).ToList();
        }

        /// <summary>
        /// Gets all user locations.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns>List&lt;UserLocation&gt;.</returns>
        private static List<UserLocation> GetAllUserLocations(string username)
        {
            using (var db = new TourGuideContext())
            {
                return db.UserLocations.Where(ub => ub.Username == username).ToList();
            }
        }
    }
}
