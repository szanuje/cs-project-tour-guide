// ***********************************************************************
// Assembly         : TourGuide.Domain
// Author           : szanu
// Created          : 01-22-2022
//
// Last Modified By : szanu
// Last Modified On : 01-28-2022
// ***********************************************************************
// <copyright file="UserService.cs" company="TourGuide.Domain">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using TourGuide.Domain.Data;
using TourGuide.Domain.Data.Models;

namespace TourGuide.Domain.Services
{
    /// <summary>
    /// Class UserService.
    /// </summary>
    public class UserService
    {
        /// <summary>
        /// Adds the new user.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns><c>true</c> if user added, <c>false</c> otherwise.</returns>
        public bool AddNewUser(String username, String name, String surname, String password)
        {
            using (var db = new TourGuideContext())
            {
                if (db.Users.Any(u => u.Username == username)) return false;
                if (string.IsNullOrEmpty(username)
                    || string.IsNullOrEmpty(name)
                    || string.IsNullOrEmpty(surname)
                    || string.IsNullOrEmpty(password))
                {
                    return false;
                }

                var user = new User() { Username = username, Name = name, Surname = surname, Password = password };
                db.Add(user);
                int entries = db.SaveChanges();

                return entries > 0;
            }
        }

        /// <summary>
        /// Logins the user.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns>User.</returns>
        public User LoginUser(String username, String password)
        {
            using (var db = new TourGuideContext())
            {
                return db.Users
                    .Where(u => u.Username == username
                        && u.Password == password)
                    .FirstOrDefault();
            }
        }
    }
}
