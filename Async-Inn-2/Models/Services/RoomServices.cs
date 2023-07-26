using Async_Inn_2.Data;
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
        public async Task<Room> CreateRoom(Room newRoom)
        {
            _context.Rooms.Add(newRoom);
            await _context.SaveChangesAsync();
            return newRoom;
        }

        // Get Amenities........................................................................

        public async Task<List<Room>> GetRooms()
        {

            var Rooms =  await _context.Rooms.Include(x => x.RoomAmenity)
                                          .ThenInclude(y => y.Amenity)
                                          .ToListAsync();
            return Rooms;
        }

        // Get Amenity by ID........................................................................
        public async Task<Room> GetRoom(int id)
        {
            var Room =  await _context.Rooms.Include(x => x.RoomAmenity)
                                       .ThenInclude(y => y.Amenity)
                                       .FirstOrDefaultAsync(x => x.ID == id);
            return Room;
        }


        // Update Amenity by ID........................................................................


        public async Task<Room> UpdateRoom(int id, Room updateRoom)
        {
            
            _context.Entry(updateRoom).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return updateRoom;
        }


        // Delete Amenity by ID........................................................................

        public async Task DeleteRoom(int id)
        {
            Room room = await GetRoom(id);
            if (room != null)
            {
                _context.Rooms.Remove(room);
                await _context.SaveChangesAsync();
            }
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
