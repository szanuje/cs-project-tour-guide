﻿using TourGuide.db;
using TourGuide.models;

namespace TourGuide.service
{
    public class UserService
    {
        public bool AddNewUser(String username, String password)
        {
            using (var db = new TourGuideContext())
            {
                var user = new User() { Username = username, Password = password };
                db.Add(user);
                int entries = db.SaveChanges();

                return entries > 0;
            }
        }

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
