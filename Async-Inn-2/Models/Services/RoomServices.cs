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

        /// <summary>
        /// Creates a new room in the database and returns the corresponding RoomDTO.
        /// </summary>
        /// <param name="newRoomDTO">The Room object to be created.</param>
        /// <returns>The RoomDTO representing the created room.</returns>

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

        // Get Rooms........................................................................
        // Update Room by ID........................................................................
        /// <summary>
        /// Retrieves a list of all rooms from the database along with their associated amenities, and returns a list of RoomDTOs.
        /// </summary>
        /// <returns>A list of RoomDTO objects representing all rooms.</returns>

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

        // Get Room by ID........................................................................
        /// <summary>
        /// Retrieves a specific Room from the database based on the given id.
        /// </summary>
        /// <param name="id">The id of the Room to be retrieved.</param>
        /// <returns>A RoomDTO representing the retrieved room</returns>

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


        /// <summary>
        /// Updates the details of a specific Room in the database based on the given id.
        /// </summary>
        /// <param name="id">The id of the Room to be updated.</param>
        /// <param name="updateRoomDTO">The updated Room object.</param>
        /// <returns>A RoomDTO representing the updated room</returns>

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


        // Delete Room by ID........................................................................
        /// <summary>
        /// Deletes a Room from the database based on the given id.
        /// </summary>
        /// <param name="id">The id of the Room to be deleted.</param>
        /// <returns>A RoomDTO representing the deleted room</returns>
        
        public async Task DeleteRoom(int id)
        {
            Room room = await _context.Rooms.FindAsync(id);
            _context.Entry(room).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }



        // Add Amenity To Room........................................................................

        /// <summary>
        /// Adds an amenity to a room in the database and returns the corresponding RoomAmenity object.
        /// </summary>
        /// <param name="roomId">The ID of the room to which the amenity will be added.</param>
        /// <param name="amenityId">The ID of the amenity to add to the room.</param>
        /// <returns>The RoomAmenity object representing the added association between the room and amenity.</returns>


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

        // Remove Amenity From Room........................................................................
        /// <summary>
        /// Removes an Amenity from a specific Room in the database.
        /// </summary>
        /// <param name="roomId">The id of the Room from which the Amenity is to be removed.</param>
        /// <param name="amenityId">The id of the Amenity to be removed.</param>
        /// <returns>A RoomAmeneties object representing the relationship between the room and the removed amenity.</returns>
        public async Task RemoveAmentityFromRoom(int roomId, int amenityId)
        {
            RoomAmenity removeAmentity = await _context.RoomAmenity.Where(x => x.RoomID == roomId && x.AmenityID == amenityId).FirstAsync();

            _context.Entry(removeAmentity).State = EntityState.Deleted;

            await _context.SaveChangesAsync();
        }



    }
}
