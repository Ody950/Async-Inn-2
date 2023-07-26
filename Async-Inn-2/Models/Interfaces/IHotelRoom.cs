namespace Async_Inn_2.Models.Interfaces
{
    public interface IHotelRoom
    {
        // CREATE
        Task<HotelRoom> CreateHotelRoom(HotelRoom hotelRoom);

        // GET ALL
        Task<List<HotelRoom>> GetHotelRooms();

        // GET ONE BY ID
        Task<HotelRoom> GetHotelRoom(int hotelid, int roomNumberid);
        // UPDATE
        Task<HotelRoom> UpdateHotelRoom(int hotelid, int roomNumberid, HotelRoom hotelRoom);

        // DELETE
        Task DeleteHotelRoom(int hotelid, int roomNumberid);
    }
}
