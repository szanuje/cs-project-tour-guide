// ***********************************************************************
// Assembly         : TourGuide.Domain
// Author           : szanu
// Created          : 01-22-2022
//
// Last Modified By : szanu
// Last Modified On : 01-28-2022
// ***********************************************************************
// <copyright file="TourGuideContext.cs" company="TourGuide.Domain">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.EntityFrameworkCore;
using TourGuide.Domain.Data.Models;

namespace TourGuide.Domain.Data
{
    /// <summary>
    /// Class TourGuideContext.
    /// Implements the <see cref="Microsoft.EntityFrameworkCore.DbContext" />
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
    public class TourGuideContext : DbContext
    {

        /// <summary>
        /// Gets the database path.
        /// </summary>
        /// <value>The database path.</value>
        public string DbPath { get; }
        /// <summary>
        /// Initializes a new instance of the <see cref="TourGuideContext"/> class.
        /// </summary>
        /// <remarks>See <see href="https://aka.ms/efcore-docs-dbcontext">DbContext lifetime, configuration, and initialization</see>
        /// for more information.</remarks>
        public TourGuideContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "tourguide.db");

            this.Database.Migrate();
            this.EnsureAdminCreated();

            var data = new DataInit();
            data.AddDestinations(this);
        }

        /// <summary>
        /// Ensures the admin created.
        /// </summary>
        private void EnsureAdminCreated()
        {
            var admin = this.Users
                    .Where(u => u.Username == "admin")
                    .FirstOrDefault();

            if (admin == null)
            {
                var user = new User() { Username = "admin", Password = "admin", Admin = true };
                this.Add(user);
                this.SaveChanges();
            }
        }

        /// <summary>
        /// Called when [configuring].
        /// </summary>
        /// <param name="options">The options.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite(connectionString: $"Data Source={DbPath}");

        /// <summary>
        /// Override this method to further configure the model that was discovered by convention from the entity types
        /// exposed in <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> properties on your derived context. The resulting model may be cached
        /// and re-used for subsequent instances of your derived context.
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for this context. Databases (and other extensions) typically
        /// define extension methods on this object that allow you to configure aspects of the model that are specific
        /// to a given database.</param>
        /// <remarks><para>
        /// If a model is explicitly set on the options for this context (via <see cref="M:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.UseModel(Microsoft.EntityFrameworkCore.Metadata.IModel)" />)
        /// then this method will not be run.
        /// </para>
        /// <para>
        /// See <see href="https://aka.ms/efcore-docs-modeling">Modeling entity types and relationships</see> for more information.
        /// </para></remarks>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BaseLocation>()
                .HasOne(b => b.Address)
                .WithOne(a => a.BaseLocation)
                .HasForeignKey<Address>(a => a.BaseLocationFK);

            modelBuilder.Entity<Place>()
                .HasOne(p => p.Destination)
                .WithMany(d => d.Places)
                .HasForeignKey(p => p.DestinationFK);

            modelBuilder.Entity<Hotel>()
                .HasOne(h => h.Destination)
                .WithMany(d => d.Hotels)
                .HasForeignKey(h => h.DestinationFK);

            modelBuilder.Entity<Destination>()
                .HasMany(d => d.Places)
                .WithOne(p => p.Destination)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Destination>()
                .HasMany(d => d.Hotels)
                .WithOne(p => p.Destination)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Destination>()
                .Navigation(d => d.Places)
                .AutoInclude();

            modelBuilder.Entity<Destination>()
                .Navigation(d => d.Hotels)
                .AutoInclude();

            modelBuilder.Entity<BaseLocation>()
                .Navigation(b => b.Address)
                .AutoInclude();

            modelBuilder.Entity<UserLocation>()
                .HasKey(ub => new { ub.Username, ub.LocationId });

            modelBuilder.Entity<UserLocation>()
                .HasOne(ub => ub.User)
                .WithMany(u => u.Locations)
                .HasForeignKey(u => u.Username);

            modelBuilder.Entity<UserLocation>()
                .HasOne(ub => ub.BaseLocation)
                .WithMany(b => b.Locations)
                .HasForeignKey(b => b.LocationId);
        }

        /// <summary>
        /// Gets or sets the users.
        /// </summary>
        /// <value>The users.</value>
        public DbSet<User> Users { get; set; }
        /// <summary>
        /// Gets or sets the destinations.
        /// </summary>
        /// <value>The destinations.</value>
        public DbSet<Destination> Destinations { get; set; }
        /// <summary>
        /// Gets or sets the places.
        /// </summary>
        /// <value>The places.</value>
        public DbSet<Place> Places { get; set; }
        /// <summary>
        /// Gets or sets the hotels.
        /// </summary>
        /// <value>The hotels.</value>
        public DbSet<Hotel> Hotels { get; set; }
        /// <summary>
        /// Gets or sets the addresses.
        /// </summary>
        /// <value>The addresses.</value>
        public DbSet<Address> Addresses { get; set; }
        /// <summary>
        /// Gets or sets the user locations.
        /// </summary>
        /// <value>The user locations.</value>
        public DbSet<UserLocation> UserLocations { get; set; }
    }
}
