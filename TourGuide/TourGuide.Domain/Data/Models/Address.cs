// ***********************************************************************
// Assembly         : TourGuide.Domain
// Author           : szanu
// Created          : 01-22-2022
//
// Last Modified By : szanu
// Last Modified On : 01-28-2022
// ***********************************************************************
// <copyright file="Address.cs" company="TourGuide.Domain">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TourGuide.Domain.Data.Models
{
    /// <summary>
    /// Class Address.
    /// </summary>
    public class Address
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>The country.</value>
        public string Country { get; set; }
        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>The city.</value>
        public string City { get; set; }
        /// <summary>
        /// Gets or sets the street.
        /// </summary>
        /// <value>The street.</value>
        public string Street { get; set; }
        /// <summary>
        /// Gets or sets the postal code.
        /// </summary>
        /// <value>The postal code.</value>
        public string PostalCode { get; set; }
        /// <summary>
        /// Gets or sets the house number.
        /// </summary>
        /// <value>The house number.</value>
        public string HouseNumber { get; set; }
        /// <summary>
        /// Gets or sets the lat.
        /// </summary>
        /// <value>The lat.</value>
        public double lat { get; set; }
        /// <summary>
        /// Gets or sets the LNG.
        /// </summary>
        /// <value>The LNG.</value>
        public double lng { get; set; }
        /// <summary>
        /// Gets or sets the base location fk.
        /// </summary>
        /// <value>The base location fk.</value>
        public int BaseLocationFK { get; set; }
        /// <summary>
        /// Gets or sets the base location.
        /// </summary>
        /// <value>The base location.</value>
        [ForeignKey("BaseLocationFK")]
        public BaseLocation BaseLocation { get; set; }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return String.Format("{0}, {1}, {2}, {3}, {4} ", Country, City, Street, HouseNumber, PostalCode);
        }
    }
}
