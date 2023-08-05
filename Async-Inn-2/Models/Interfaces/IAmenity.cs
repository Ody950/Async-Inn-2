using Async_Inn_2.Models.DTOs;

namespace Async_Inn_2.Models.Interfaces
{


    // It uses the AmenityDTO class to transfer data between the controller
    // and the service layer, and it asynchronous and return AmenityDTO
    // objects or lists of them, and it include creating, getting, updating
    // and deleting amenities by their ID.

    public interface IAmenity
    {
        // CREATE
        Task<AmenityDTO> CreateAmenity(AmenityDTO amenity);

        // GET ALL
        Task<List<AmenityDTO>> GetAmenities();

        // GET ONE BY ID
        Task<AmenityDTO> GetAmenity(int id);

        // UPDATE
        Task<AmenityDTO> UpdateAmenity(int id, AmenityDTO amenity);

        // DELETE
        Task DeleteAmenity(int id);
    }
}
