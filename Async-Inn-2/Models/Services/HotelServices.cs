using Async_Inn_2.Data;
using Async_Inn_2.Models.DTOs;
using Async_Inn_2.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Async_Inn_2.Models.Services
{
    public class HotelServices : IHotel
    {

        private readonly AsyncInnDbContext _context;

        public HotelServices(AsyncInnDbContext context)
        {
            _context = context;
        }

        // CREATE........................................................................

        /// <summary>
        /// Creates a new hotel and adds it to the database.
        /// </summary>
        /// <param name="newHotelDTO">The hotel object to be created.</param>
        /// <returns>A HotelDTO representing the created hotel.</returns>


        public async Task<HotelDTO> CreateHotel(HotelDTO newHotelDTO)
        {
            Hotel hotel = new Hotel
            {
                ID =  newHotelDTO.ID,
                Name = newHotelDTO.Name,
                StreetAddress = newHotelDTO.StreetAddress,
                City = newHotelDTO.City,
                State = newHotelDTO.State,
                Country = newHotelDTO.Country,
                Phone = newHotelDTO.Phone
            };

            _context.Entry(hotel).State = EntityState.Added;
            await _context.SaveChangesAsync();

            return newHotelDTO;
        }

        // Get Hotels........................................................................
        /// <summary>
        /// Retrieves a list of all hotels from the database along with their associated rooms and amenities.
        /// Returns a list of HotelDTO objects representing all hotels and their rooms.
        /// </summary>
        /// <returns>A list of HotelDTO objects representing all hotels and their rooms.</returns>
        
        public async Task<List<HotelDTO>> GetHotels()
        {
            var hotel = await _context.Hotels.Select(x => new HotelDTO()
            {
                ID = x.ID,
                Name = x.Name,
                StreetAddress = x.StreetAddress,
                City = x.City,
                State = x.State,
                Country = x.Country,
                Phone = x.Phone,
                HotelRoom = x.HotelRoom.Select(x => new HotelRoomDTO()
                {
                    RoomID = x.RoomID,
                    RoomNumber = x.RoomNumber,
                    HotelID = x.HotelID,
                    Rate = x.Rate,
                    PetFriendly = x.PetFriendly,
                    Room = new RoomDTO()
                    {
                        ID = x.Room.ID,
                        Name = x.Room.Name,
                        Layout = x.Room.Layout,
                        Amenities = x.Room.RoomAmenity.Select(y => new AmenityDTO()
                        {
                            ID = y.Amenity.ID,
                            Name = y.Amenity.Name
                        }).ToList()
                    }
                }).ToList()
            }).ToListAsync();

            return hotel;
        }

        // Get Hotel by ID........................................................................
        /// <summary>
        /// Retrieves a list of all hotels from the database.
        /// </summary>
        /// <returns>A list of HotelDTO, each representing a hotel and its rooms with amenities.</returns>

        public async Task<HotelDTO> GetHotel(int id)
        {
            var hotel = await _context.Hotels.Select(x => new HotelDTO()
            {
                ID = x.ID,
                Name = x.Name,
                StreetAddress = x.StreetAddress,
                City = x.City,
                State = x.State,
                Country = x.Country,
                Phone = x.Phone,
                HotelRoom = x.HotelRoom.Select(x => new HotelRoomDTO()
                {
                    RoomID = x.RoomID,
                    RoomNumber = x.RoomNumber,
                    HotelID = x.HotelID,
                    Rate = x.Rate,
                    PetFriendly = x.PetFriendly,
                    Room = new RoomDTO()
                    {
                        ID = x.Room.ID,
                        Name = x.Room.Name,
                        Layout = x.Room.Layout,
                        Amenities = x.Room.RoomAmenity.Select(x => new AmenityDTO()
                        {
                            ID = x.Amenity.ID,
                            Name = x.Amenity.Name
                        }).ToList()
                    }
                }).ToList()
            }).FirstOrDefaultAsync(x => x.ID == id);

            return hotel;
        }


        // Update Hotel by ID........................................................................
        /// <summary>
        /// Updates an existing hotel in the database by the given hotel ID and new Hotel object.
        /// Returns the HotelDTO representing the hotel before the update.
        /// </summary>
        /// <param name="id">The ID of the hotel to update.</param>
        /// <param name="updateHotelDTO">The updated Hotel object.</param>
        /// <returns>The HotelDTO representing the hotel before the update.</returns>

        public async Task<HotelDTO> UpdateHotel(int id, HotelDTO updateHotelDTO)
        {
            Hotel hotel = new Hotel
            {
                ID = updateHotelDTO.ID,
                Name = updateHotelDTO.Name,
                StreetAddress = updateHotelDTO.StreetAddress,
                City = updateHotelDTO.City,
                State = updateHotelDTO.State,
                Country = updateHotelDTO.Country,
                Phone = updateHotelDTO.Phone
            };
            _context.Entry(hotel).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return updateHotelDTO;
        }


        // Delete Hotel by ID........................................................................
        /// <summary>
        /// Deletes a hotel from the database based on the given id.
        /// </summary>
        /// <param name="id">The id of the hotel to be deleted.</param>
       
        
        public async Task DeleteHotel(int id)
        {
            Hotel hotel = await _context.Hotels.FindAsync(id);
            _context.Entry(hotel).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
