using Async_Inn_2.Models.DTOs;

namespace Async_Inn_2.Models.Interfaces
{

    // It uses the RoomDTO class to transfer data between the controller
    // and the service layer, and it asynchronous and return RoomDTO
    // objects or lists of them, and it include creating, getting, updating
    // and deleting amenities by their ID.


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
