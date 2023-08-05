using Async_Inn_2.Models.DTOs;

namespace Async_Inn_2.Models.Interfaces
{

    // It uses the HotelRoomDTO class to transfer data between the controller
    // and the service layer, and it asynchronous and return HotelRoomDTO
    // objects or lists of them, and it include creating, getting, updating
    // and deleting amenities by their ID.

    public interface IHotelRoom
    {
        // CREATE
        Task<HotelRoomDTO> CreateHotelRoom(HotelRoomDTO hotelRoom);

        // GET ALL
        Task<List<HotelRoomDTO>> GetHotelRooms();

        // GET ONE BY ID
        Task<HotelRoomDTO> GetHotelRoom(int hotelid, int roomNumberid);
        // UPDATE
        Task<HotelRoomDTO> UpdateHotelRoom(int hotelid, int roomNumberid, HotelRoomDTO hotelRoom);

        // DELETE
        Task DeleteHotelRoom(int hotelid, int roomNumberid);
    }
}
