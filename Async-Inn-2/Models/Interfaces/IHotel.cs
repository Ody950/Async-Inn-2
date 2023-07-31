using Async_Inn_2.Models.DTOs;

namespace Async_Inn_2.Models.Interfaces
{
    public interface IHotel
    {
        // CREATE
        Task<HotelDTO> CreateHotel(HotelDTO hotel);

        // GET ALL
        Task<List<HotelDTO>> GetHotels();

        // GET ONE BY ID
        Task<HotelDTO> GetHotel(int id);
        // UPDATE
        Task<HotelDTO> UpdateHotel(int id, HotelDTO hotel);

        // DELETE
        Task DeleteHotel(int Id);

    }
}
