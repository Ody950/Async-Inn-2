﻿// <auto-generated />
using Async_Inn_2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Async_Inn_2.Migrations
{
    [DbContext(typeof(AsyncInnDbContext))]
    [Migration("20230731090203_final2")]
    partial class final2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Async_Inn_2.Models.Amenity", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Amenities");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "Amenity-1"
                        },
                        new
                        {
                            ID = 2,
                            Name = "Amenity-2"
                        },
                        new
                        {
                            ID = 3,
                            Name = "Amenity-3"
                        });
                });

            modelBuilder.Entity("Async_Inn_2.Models.Hotel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Hotels");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            City = "Amman-1",
                            Country = "Jordan",
                            Name = "Hotel-1",
                            Phone = "+962 798998989",
                            State = "Amman-1",
                            StreetAddress = "Amman Street 1"
                        },
                        new
                        {
                            ID = 2,
                            City = "Amman-2",
                            Country = "Jordan",
                            Name = "Hotel-2",
                            Phone = "+962 778989884",
                            State = "Amman-2",
                            StreetAddress = "Amman Street 2"
                        },
                        new
                        {
                            ID = 3,
                            City = "Amman-3",
                            Country = "Jordan",
                            Name = "Hotel-3",
                            Phone = "+962 789895441",
                            State = "Amman-3",
                            StreetAddress = "Amman Street 3"
                        });
                });

            modelBuilder.Entity("Async_Inn_2.Models.HotelRoom", b =>
                {
                    b.Property<int>("HotelID")
                        .HasColumnType("int");

                    b.Property<int>("RoomNumber")
                        .HasColumnType("int");

                    b.Property<bool>("PetFriendly")
                        .HasColumnType("bit");

                    b.Property<decimal>("Rate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("RoomID")
                        .HasColumnType("int");

                    b.HasKey("HotelID", "RoomNumber");

                    b.HasIndex("RoomID");

                    b.ToTable("HotelRoom");
                });

            modelBuilder.Entity("Async_Inn_2.Models.Room", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("Layout")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Rooms");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Layout = 1,
                            Name = "Rome-1"
                        },
                        new
                        {
                            ID = 2,
                            Layout = 2,
                            Name = "Rome-2"
                        },
                        new
                        {
                            ID = 3,
                            Layout = 3,
                            Name = "Rome-3"
                        });
                });

            modelBuilder.Entity("Async_Inn_2.Models.RoomAmenity", b =>
                {
                    b.Property<int>("RoomID")
                        .HasColumnType("int");

                    b.Property<int>("AmenityID")
                        .HasColumnType("int");

                    b.HasKey("RoomID", "AmenityID");

                    b.HasIndex("AmenityID");

                    b.ToTable("RoomAmenity");
                });

            modelBuilder.Entity("Async_Inn_2.Models.HotelRoom", b =>
                {
                    b.HasOne("Async_Inn_2.Models.Hotel", "Hotel")
                        .WithMany("HotelRoom")
                        .HasForeignKey("HotelID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Async_Inn_2.Models.Room", "Room")
                        .WithMany("HotelRoom")
                        .HasForeignKey("RoomID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("Async_Inn_2.Models.RoomAmenity", b =>
                {
                    b.HasOne("Async_Inn_2.Models.Amenity", "Amenity")
                        .WithMany("RoomAmenity")
                        .HasForeignKey("AmenityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Async_Inn_2.Models.Room", "Room")
                        .WithMany("RoomAmenity")
                        .HasForeignKey("RoomID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Amenity");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("Async_Inn_2.Models.Amenity", b =>
                {
                    b.Navigation("RoomAmenity");
                });

            modelBuilder.Entity("Async_Inn_2.Models.Hotel", b =>
                {
                    b.Navigation("HotelRoom");
                });

            modelBuilder.Entity("Async_Inn_2.Models.Room", b =>
                {
                    b.Navigation("HotelRoom");

                    b.Navigation("RoomAmenity");
                });
#pragma warning restore 612, 618
        }
    }
}
