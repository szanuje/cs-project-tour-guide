// ***********************************************************************
// Assembly         : TourGuide.Domain
// Author           : szanu
// Created          : 01-28-2022
//
// Last Modified By : szanu
// Last Modified On : 01-28-2022
// ***********************************************************************
// <copyright file="UserLocation.cs" company="TourGuide.Domain">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace TourGuide.Domain.Data.Models
{
    /// <summary>
    /// Class UserLocation.
    /// </summary>
    public class UserLocation
    {
        /// <summary>
        /// The username
        /// </summary>
        public string Username;
        /// <summary>
        /// The user
        /// </summary>
        public User User;
        /// <summary>
        /// Gets or sets the location identifier.
        /// </summary>
        /// <value>The location identifier.</value>
        public int LocationId { get; set; }
        /// <summary>
        /// Gets or sets the base location.
        /// </summary>
        /// <value>The base location.</value>
        public BaseLocation BaseLocation { get; set; }
    }
}
