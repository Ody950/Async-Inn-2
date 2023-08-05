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
        /// <summary> 
        /// Creates a new hotel room from a DTO and adds it to the database 
        /// </summary> 
        /// <param name=“hotelRoomDTO”>The DTO containing the hotel room information</param> 
        /// <returns>The created hotel room as a DTO</returns> 
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
        /// <summary> 
        /// Returns a list of all hotel rooms as DTOs with their associated room and amenity details 
        /// </summary> 
        /// <returns>A list of hotel room DTOs</returns>
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
        // <summary> 
        /// Returns a single hotel room by its hotel ID and room number as a DTO with its associated room and amenity details 
        /// </summary> 
        
        /// <param name="hotelid"> The ID of the hotel to retrieve.</param> 
        /// <param name="roomNumberid"> The number of the room to retrieve.</param> 
        /// <returns>The hotel room DTO with the matching hotel ID and room number</returns> 
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
        /// <summary>
        /// Updates an existing hotel room in the database by the given hotel ID, room number, and new HotelRoom object.
        /// Returns the HotelRoomDTO representing the hotel room before the update.
        /// </summary>
        /// <param name="hotelid">The ID of the hotel to which the room belongs.</param>
        /// <param name="roomNumberid">The room number of the hotel room to update.</param>
        /// <param name="hotelRoomDTO">The updated HotelRoom object.</param>
        /// <returns>The HotelRoomDTO representing the hotel room before the update.</returns>

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
        /// <summary>
        /// Deletes a hotel room from the database based on the given hotel id and room number.
        /// </summary>
        /// <param name="hotelid">The id of the hotel associated with the hotel room to be deleted.</param>
        /// <param name="roomNumberid">The room number of the hotel room to be deleted.</param>
       

        public async Task DeleteHotelRoom(int hotelid, int roomNumberid)
        {
            HotelRoom hotelRoom = await _context.HotelRoom.FindAsync(hotelid, roomNumberid);
            _context.Entry(hotelRoom).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

    }
}
