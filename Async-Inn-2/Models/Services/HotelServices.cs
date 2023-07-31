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
        public async Task<HotelDTO> CreateHotel(HotelDTO newHotelDTO)
        {
            Hotel hotel = new Hotel
            {
                ID = newHotelDTO.ID,
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

        // Get Amenities........................................................................

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

        // Get Amenity by ID........................................................................
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


        // Update Amenity by ID........................................................................


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


        // Delete Amenity by ID........................................................................

        public async Task DeleteHotel(int id)
        {
            Hotel hotel = await _context.Hotels.FindAsync(id);
            _context.Entry(hotel).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
