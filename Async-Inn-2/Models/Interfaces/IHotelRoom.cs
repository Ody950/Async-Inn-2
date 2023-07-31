using Async_Inn_2.Models.DTOs;

namespace Async_Inn_2.Models.Interfaces
{
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
