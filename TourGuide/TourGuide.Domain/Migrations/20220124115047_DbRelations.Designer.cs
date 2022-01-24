﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TourGuide.Domain.Data;

#nullable disable

namespace TourGuide.Domain.Migrations
{
    [DbContext(typeof(TourGuideContext))]
    [Migration("20220124115047_DbRelations")]
    partial class DbRelations
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.1");

            modelBuilder.Entity("TourGuide.Domain.Data.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BaseLocationFK")
                        .HasColumnType("INTEGER");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("HouseNumber")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("lat")
                        .HasColumnType("REAL");

                    b.Property<double>("lng")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("BaseLocationFK")
                        .IsUnique();

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("TourGuide.Domain.Data.Models.BaseLocation", b =>
                {
                    b.Property<int>("LocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("DestinationFK")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LocationId");

                    b.ToTable("BaseLocation");

                    b.HasDiscriminator<string>("Discriminator").HasValue("BaseLocation");
                });

            modelBuilder.Entity("TourGuide.Domain.Data.Models.Destination", b =>
                {
                    b.Property<int>("DestinationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("DestinationId");

                    b.ToTable("Destinations");
                });

            modelBuilder.Entity("TourGuide.Domain.Data.Models.User", b =>
                {
                    b.Property<string>("Username")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Admin")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Username");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TourGuide.Domain.Data.Models.Hotel", b =>
                {
                    b.HasBaseType("TourGuide.Domain.Data.Models.BaseLocation");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.Property<string>("Rating")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasIndex("DestinationFK");

                    b.HasDiscriminator().HasValue("Hotel");
                });

            modelBuilder.Entity("TourGuide.Domain.Data.Models.Place", b =>
                {
                    b.HasBaseType("TourGuide.Domain.Data.Models.BaseLocation");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasIndex("DestinationFK");

                    b.HasDiscriminator().HasValue("Place");
                });

            modelBuilder.Entity("TourGuide.Domain.Data.Models.Address", b =>
                {
                    b.HasOne("TourGuide.Domain.Data.Models.BaseLocation", "BaseLocation")
                        .WithOne("Address")
                        .HasForeignKey("TourGuide.Domain.Data.Models.Address", "BaseLocationFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BaseLocation");
                });

            modelBuilder.Entity("TourGuide.Domain.Data.Models.Hotel", b =>
                {
                    b.HasOne("TourGuide.Domain.Data.Models.Destination", "Destination")
                        .WithMany("Hotels")
                        .HasForeignKey("DestinationFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Destination");
                });

            modelBuilder.Entity("TourGuide.Domain.Data.Models.Place", b =>
                {
                    b.HasOne("TourGuide.Domain.Data.Models.Destination", "Destination")
                        .WithMany("Places")
                        .HasForeignKey("DestinationFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Destination");
                });

            modelBuilder.Entity("TourGuide.Domain.Data.Models.BaseLocation", b =>
                {
                    b.Navigation("Address")
                        .IsRequired();
                });

            modelBuilder.Entity("TourGuide.Domain.Data.Models.Destination", b =>
                {
                    b.Navigation("Hotels");

                    b.Navigation("Places");
                });
#pragma warning restore 612, 618
        }
    }
}
