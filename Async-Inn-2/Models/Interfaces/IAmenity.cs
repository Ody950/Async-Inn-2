namespace Async_Inn_2.Models.Interfaces
{
    public interface IAmenity
    {
        // CREATE
        Task<Amenity> CreateAmenity(Amenity amenity);

        // GET ALL
        Task<List<Amenity>> GetAmenities();

        // GET ONE BY ID
        Task<Amenity> GetAmenity(int id);

        // UPDATE
        Task<Amenity> UpdateAmenity(int id, Amenity amenity);

        // DELETE
        Task DeleteAmenity(int id);
    }
}
