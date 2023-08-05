using Async_Inn_2.Models.DTOs;

namespace Async_Inn_2.Models.Interfaces
{
    // It uses the HotelDTO class to transfer data between the controller
    // and the service layer, and it asynchronous and return HotelDTO
    // objects or lists of them, and it include creating, getting, updating
    // and deleting amenities by their ID.

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
