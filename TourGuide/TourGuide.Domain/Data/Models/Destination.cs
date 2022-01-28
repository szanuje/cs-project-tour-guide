// ***********************************************************************
// Assembly         : TourGuide.Domain
// Author           : szanu
// Created          : 01-22-2022
//
// Last Modified By : szanu
// Last Modified On : 01-28-2022
// ***********************************************************************
// <copyright file="Destination.cs" company="TourGuide.Domain">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.ComponentModel.DataAnnotations;

namespace TourGuide.Domain.Data.Models
{
    /// <summary>
    /// Class Destination.
    /// </summary>
    public class Destination
    {
        /// <summary>
        /// Gets or sets the destination identifier.
        /// </summary>
        /// <value>The destination identifier.</value>
        [Key]
        public int DestinationId { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }
        /// <summary>
        /// The places
        /// </summary>
        public List<Place> Places;
        /// <summary>
        /// The hotels
        /// </summary>
        public List<Hotel> Hotels;
    }
}
