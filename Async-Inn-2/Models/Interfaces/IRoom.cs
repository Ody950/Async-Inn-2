using Async_Inn_2.Models.DTOs;

namespace Async_Inn_2.Models.Interfaces
{
    public interface IRoom
    {
        // CREATE
        Task<RoomDTO> CreateRoom(RoomDTO room);

        // GET ALL
        Task<List<RoomDTO>> GetRooms();

        // GET ONE BY ID
        Task<RoomDTO> GetRoom(int id);
        // UPDATE
        Task<RoomDTO> UpdateRoom(int id, RoomDTO room);

        // DELETE
        Task DeleteRoom(int id);

        // Add Amenity To Room
        Task AddAmenityToRoom(int roomId, int amenityId);

        // Remove Amentity From Room
        Task RemoveAmentityFromRoom(int roomId, int amenityId);
    }
}
