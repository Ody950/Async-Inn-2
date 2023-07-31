using Async_Inn_2.Models.DTOs;

namespace Async_Inn_2.Models.Interfaces
{
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
