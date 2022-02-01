// ***********************************************************************
// Assembly         : TourGuide.Domain
// Author           : szanu
// Created          : 01-22-2022
//
// Last Modified By : szanu
// Last Modified On : 02-01-2022
// ***********************************************************************
// <copyright file="Hotel.cs" company="TourGuide.Domain">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace TourGuide.Domain.Data.Models
{
    /// <summary>
    /// Class Hotel.
    /// Implements the <see cref="TourGuide.Domain.Data.Models.BaseLocation" />
    /// </summary>
    /// <seealso cref="TourGuide.Domain.Data.Models.BaseLocation" />
    public class Hotel : BaseLocation
    {
        /// <summary>
        /// Gets or sets the rating.
        /// </summary>
        /// <value>The rating.</value>
        public string Rating { get; set; }
        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>The price.</value>
        public string Price { get; set; }
    }
}
