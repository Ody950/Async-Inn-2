using Async_Inn_2.Data;
using Async_Inn_2.Models.DTOs;
using Async_Inn_2.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Async_Inn_2.Models.Services
{
    public class RoomServices : IRoom
    {

        private readonly AsyncInnDbContext _context;

        public RoomServices(AsyncInnDbContext context)
        {
            _context = context;
        }

        // CREATE........................................................................
        public async Task<RoomDTO> CreateRoom(RoomDTO newRoomDTO)
        {
            Room room = new Room
            {
                ID = newRoomDTO.ID,
                Name = newRoomDTO.Name,
                Layout = newRoomDTO.Layout,
            };
            _context.Rooms.Entry(room).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return newRoomDTO;
        }

        // Get Amenities........................................................................

        public async Task<List<RoomDTO>> GetRooms()
        {

            var Rooms =  await _context.Rooms.Select(x => new RoomDTO
            {
                ID = x.ID,
                Name = x.Name,
                Layout = x.Layout,
                Amenities = x.RoomAmenity
                 .Select(x => new AmenityDTO
                   {
                      ID = x.Amenity.ID,
                      Name = x.Amenity.Name
                   }).ToList()

            }).ToListAsync();
    
            return Rooms;
        }

        // Get Amenity by ID........................................................................
        public async Task<RoomDTO> GetRoom(int id)
        {
            var Rooms = await _context.Rooms.Select(x => new RoomDTO
            {
                ID = x.ID,
                Name = x.Name,
                Layout = x.Layout,
                Amenities = x.RoomAmenity
                  .Select(x => new AmenityDTO
                  {
                      ID = x.Amenity.ID,
                      Name = x.Amenity.Name
                  }).ToList()

            }).FirstOrDefaultAsync(x => x.ID == id);

            return Rooms;
        }


        // Update Amenity by ID........................................................................


        public async Task<RoomDTO> UpdateRoom(int id, RoomDTO updateRoomDTO)
        {
            Room room = new Room
            {
                ID = updateRoomDTO.ID,
                Name = updateRoomDTO.Name,
                Layout = updateRoomDTO.Layout,
            };
            _context.Entry(room).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return updateRoomDTO;
        }


        // Delete Amenity by ID........................................................................

        public async Task DeleteRoom(int id)
        {
            Room room = await _context.Rooms.FindAsync(id);
            _context.Entry(room).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }



        // Add Amenity To Room........................................................................
        public async Task AddAmenityToRoom(int roomId, int amenityId)
        {
            RoomAmenity newRoomAmenity = new RoomAmenity()
            {
                RoomID = roomId,
                AmenityID = amenityId
            };
            _context.Entry(newRoomAmenity).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }

        // Remove Amentity From Room........................................................................
        public async Task RemoveAmentityFromRoom(int roomId, int amenityId)
        {
            var removeAmentity = _context.RoomAmenity.FirstOrDefaultAsync(x => x.RoomID == roomId && x.AmenityID == amenityId);
            _context.Entry(removeAmentity).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }



    }
}
