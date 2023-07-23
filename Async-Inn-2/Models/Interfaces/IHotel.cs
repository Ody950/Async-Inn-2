namespace Async_Inn_2.Models.Interfaces
{
    public interface IHotel
    {
        // CREATE
        Task<Hotel> CreateHotel(Hotel hotel);

        // GET ALL
        Task<List<Hotel>> GetHotels();

        // GET ONE BY ID
        Task<Hotel> GetHotel(int id);
        // UPDATE
        Task<Hotel> UpdateHotel(int id, Hotel hotel);

        // DELETE
        Task DeleteHotel(int Id);
    }
}
