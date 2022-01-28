// ***********************************************************************
// Assembly         : TourGuide.Domain
// Author           : szanu
// Created          : 01-22-2022
//
// Last Modified By : szanu
// Last Modified On : 01-28-2022
// ***********************************************************************
// <copyright file="Place.cs" company="TourGuide.Domain">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace TourGuide.Domain.Data.Models
{
    /// <summary>
    /// Class Place.
    /// Implements the <see cref="TourGuide.Domain.Data.Models.BaseLocation" />
    /// </summary>
    /// <seealso cref="TourGuide.Domain.Data.Models.BaseLocation" />
    public class Place : BaseLocation
    {
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }
    }
}
