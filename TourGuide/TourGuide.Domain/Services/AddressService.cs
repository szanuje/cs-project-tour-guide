// ***********************************************************************
// Assembly         : TourGuide.Domain
// Author           : szanu
// Created          : 01-22-2022
//
// Last Modified By : szanu
// Last Modified On : 01-28-2022
// ***********************************************************************
// <copyright file="AddressService.cs" company="TourGuide.Domain">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using TourGuide.Domain.Data;
using TourGuide.Domain.Data.Models;

namespace TourGuide.Domain.Services
{
    /// <summary>
    /// Class AddressService.
    /// </summary>
    public class AddressService
    {
        /// <summary>
        /// Adds the new address.
        /// </summary>
        /// <param name="country">The country.</param>
        /// <param name="city">The city.</param>
        /// <param name="street">The street.</param>
        /// <param name="postalCode">The postal code.</param>
        /// <param name="houseNumber">The house number.</param>
        /// <returns><c>true</c> if address added, <c>false</c> otherwise.</returns>
        public bool AddNewAddress(String country, String city, String street,
            string postalCode, string houseNumber)
        {
            using(var db = new TourGuideContext())
            {
                var address = new Address()
                {
                    Country = country,
                    City = city,
                    Street = street,
                    PostalCode = postalCode,
                    HouseNumber = houseNumber
                };
                db.Add(address);
                int entries = db.SaveChanges();

                return entries > 0;
            }
        }

       /* public Address GetAddress(int key)
        {
            using (var db = new TourGuideContext())
            {
                return db.Addresses
                    .Where(a => a.Id == key)
                    .FirstOrDefault();
            }
        }*/
    }
}
