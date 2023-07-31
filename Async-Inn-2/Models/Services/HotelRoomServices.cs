using Async_Inn_2.Data;
using Async_Inn_2.Models.DTOs;
using Async_Inn_2.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Async_Inn_2.Models.Services
{
    public class HotelRoomServices : IHotelRoom
    {
        private readonly AsyncInnDbContext _context;

        public HotelRoomServices(AsyncInnDbContext context)
        {
            _context = context;
        }

        // CREATE........................................................................

        public async Task<HotelRoomDTO> CreateHotelRoom(HotelRoomDTO hotelRoomDTO)
        {
            HotelRoom hotelRoom = new HotelRoom
            {
                RoomID = hotelRoomDTO.RoomID,
                RoomNumber = hotelRoomDTO.RoomNumber,
                HotelID = hotelRoomDTO.HotelID,
                Rate = hotelRoomDTO.Rate,
                PetFriendly = hotelRoomDTO.PetFriendly,
            };

            _context.Entry(hotelRoom).State = EntityState.Added;
            await _context.SaveChangesAsync();

            return hotelRoomDTO;
        }

        // Get HotelRooms........................................................................

        public async Task<List<HotelRoomDTO>> GetHotelRooms()
        {
            var hotelRooms = await _context.HotelRoom.Select(x => new HotelRoomDTO()
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
            }).ToListAsync();
            return hotelRooms;
        }

        // Get HotelRoom by ID........................................................................

        public async Task<HotelRoomDTO> GetHotelRoom(int hotelid, int roomNumberid)
        {
            var hotelRoom = await _context.HotelRoom.Select(x => new HotelRoomDTO()
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
            }).FirstOrDefaultAsync(r => r.HotelID == hotelid && r.RoomNumber == roomNumberid);

            return hotelRoom;
        }
    



        // Update HotelRoom by ID........................................................................


        public async Task<HotelRoomDTO> UpdateHotelRoom(int hotelid, int roomNumberid, HotelRoomDTO hotelRoomDTO)
        {

        HotelRoom hotelRoom = new HotelRoom
        {
            RoomID = hotelRoomDTO.RoomID,
            RoomNumber = hotelRoomDTO.RoomNumber,
            HotelID = hotelRoomDTO.HotelID,
            Rate = hotelRoomDTO.Rate,
            PetFriendly = hotelRoomDTO.PetFriendly
        };

           _context.Entry(hotelRoom).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return hotelRoomDTO;
        }



        // Delete HotelRoom by ID........................................................................

        public async Task DeleteHotelRoom(int hotelid, int roomNumberid)
        {
            HotelRoom hotelRoom = await _context.HotelRoom.FindAsync(hotelid, roomNumberid);
            _context.Entry(hotelRoom).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

    }
}
