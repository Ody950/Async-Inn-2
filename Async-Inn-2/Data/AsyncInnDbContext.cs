using Async_Inn_2.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Async_Inn_2.Data
{
    public class AsyncInnDbContext : IdentityDbContext<ApplicationUser>
    {
        public AsyncInnDbContext(DbContextOptions Options) : base(Options) 
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            base.OnModelCreating(modelBuilder);



            modelBuilder.Entity<Hotel>().HasData(

                new Hotel() { ID = 1, Name = "Hotel-1", StreetAddress = "Amman Street 1", City = "Amman-1", State = "Amman-1", Country = "Jordan", Phone = "+962 798998989" },
                new Hotel() { ID = 2, Name = "Hotel-2", StreetAddress = "Amman Street 2", City = "Amman-2", State = "Amman-2", Country = "Jordan", Phone = "+962 778989884" },
                new Hotel() { ID = 3, Name = "Hotel-3", StreetAddress = "Amman Street 3", City = "Amman-3", State = "Amman-3", Country = "Jordan", Phone = "+962 789895441" }

                );
            modelBuilder.Entity<Room>().HasData(

                new Room() { ID = 1, Name = "Rome-1", Layout = 1 },
                new Room() { ID = 2, Name = "Rome-2", Layout = 2 },
                 new Room() { ID = 3, Name = "Rome-3", Layout = 3 }


                );

            modelBuilder.Entity<Amenity>().HasData(

                new Amenity() { ID = 1, Name = "Amenity-1" },
                new Amenity() { ID = 2, Name = "Amenity-2" },
                 new Amenity() { ID = 3, Name = "Amenity-3" }


                );


            modelBuilder.Entity<RoomAmenity>().HasKey(RoomAmenity => new { RoomAmenity.RoomID, RoomAmenity.AmenityID });

            modelBuilder.Entity<HotelRoom>().HasKey(HotelRoomNumber => new { HotelRoomNumber.HotelID, HotelRoomNumber.RoomNumber });

        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Amenity> Amenities { get; set; }
        public DbSet<RoomAmenity> RoomAmenity { get; set; }
        public DbSet<HotelRoom> HotelRoom { get; set; }




    }
}
