using Async_Inn_2.Data;
using Async_Inn_2.Models;
using Async_Inn_2.Models.DTOs;
using Async_Inn_2.Models.Interfaces;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Diagnostics.Metrics;

namespace AsyncInnUnitTist
{
    public abstract class Mock : IDisposable
    {

        private readonly SqliteConnection _connection;
        protected readonly AsyncInnDbContext _db;

        public Mock()
        {
            _connection = new SqliteConnection("Filename=:memory:");
            _connection.Open();

            _db = new AsyncInnDbContext(
                new DbContextOptionsBuilder<AsyncInnDbContext>()
                .UseSqlite(_connection).Options);

            _db.Database.EnsureCreated();


        }

        protected async Task<Amenity> CreateAndSaveAmenity()
        {
            var amenity = new Amenity() { ID = 7, Name = "cv" };
            _db.Amenities.Add(amenity);
            await _db.SaveChangesAsync();
            //Assert.NotEqual(0, amenity.ID);
            return amenity;
        }

        protected async Task<Room> CreateAndSaveTestRoom()
        {
            var room = new Room() { ID = 7, Name = "studio", Layout = 48 };
            _db.Rooms.Add(room);
            await _db.SaveChangesAsync();
           // Assert.NotEqual(0, room.ID);
            return room;
        }

        protected async Task<Hotel> CreateAndSaveTestHotel()
        {
            var hotel = new Hotel() { Name = "Amman Hotel", StreetAddress = "Amman", City = "Amman", State = "Amman", Country = "Amman", Phone = "078955546" };
            _db.Hotels.Add(hotel);
            await _db.SaveChangesAsync();
            // Assert.NotEqual(0, room.ID);
            return hotel;
        }

        protected async Task<Room> TestRoom()
        {
            var room = new Room() {Name = "studio", Layout = 48 };
            _db.Rooms.Add(room);
            await _db.SaveChangesAsync();
            // Assert.NotEqual(0, room.ID);
            return room;
        }

        public void Dispose()
        {

            _db?.Dispose();

            _connection?.Dispose();
        }
    }
}


/*var amenity = new AmenityDTO() { ID = 1, Name = "cv" };
var X = JsonConvert.SerializeObject(amenity);
var jasOu = new StringContent(X);

*/