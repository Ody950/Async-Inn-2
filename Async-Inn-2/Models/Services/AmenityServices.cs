using Async_Inn_2.Data;
using Async_Inn_2.Models.DTOs;
using Async_Inn_2.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Async_Inn_2.Models.Services
{
    public class AmenityServices : IAmenity
    {

        private readonly AsyncInnDbContext _context;

        public AmenityServices(AsyncInnDbContext context)
        {
            _context = context;
        }

        // CREATE........................................................................

        // <summary> 
        /// Creates a new amenity from a DTO and adds it to the database 
        /// </summary> 
        /// <param name=“newAmenityDTO”>The DTO containing the amenity information</param>
        ///  <returns>The created amenity as a DTO</returns> public async Task<AmenityDTO> 
        

        public async Task<AmenityDTO> CreateAmenity(AmenityDTO newAmenityDTO)
        {
            Amenity newAmenity = new Amenity
            {
                ID = newAmenityDTO.ID,
                Name = newAmenityDTO.Name
            };

            _context.Entry(newAmenity).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return newAmenityDTO;
        }

        // Get Amenities.......................................................................
        /// <summary> 
        /// Returns a list of all amenities as DTOs 
        /// </summary> 
        /// <returns>A list of amenity DTOs</returns> 
        public async Task<List<AmenityDTO>> GetAmenities()
        {
            var amenities = await _context.Amenities.Select(x => new AmenityDTO
            {
                ID = x.ID,
                Name = x.Name
            }).ToListAsync();

            return amenities;
        }

        // Get Amenity by ID........................................................................
        /// <summary> 
        /// Returns a single amenity by its ID as a DTO 
        /// </summary> 
        /// <param name=“id”>The ID of the amenity to retrieve</param> 
        /// <returns>The amenity DTO with the matching ID</returns> 
        public async Task<AmenityDTO> GetAmenity(int id)
        {
            var amenity =  await _context.Amenities.Select(x => new AmenityDTO
            {
                ID = x.ID,
                Name = x.Name
            }).FirstOrDefaultAsync(x => x.ID == id);

            return amenity;
        }

        // Update Amenity by ID.......................................................................
        /// <summary> 
        /// Updates an existing amenity by its ID with a new DTO and saves the changes to the database 
        /// </summary> 
        /// <param name=“id”>The ID of the amenity to update</param> 
        /// <param name=“updateAmenityDTO”>The DTO containing the updated amenity information</param> 
        /// <returns>The updated amenity as a DTO</returns>


        public async Task<AmenityDTO> UpdateAmenity(int id, AmenityDTO updateAmenityDTO)
        {

            Amenity updateAmenity = new Amenity
            {
                ID = updateAmenityDTO.ID,
                Name = updateAmenityDTO.Name
            };
            _context.Entry(updateAmenity).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return updateAmenityDTO;
        }


        // Delete Amenity by ID.......................................................................
        /// <summary> 
        /// Deletes an existing amenity by its ID from the database 
        /// </summary> 
        /// <param name=“id”>The ID of the amenity to delete</param> 
    
        public async Task DeleteAmenity(int id)
        {
            Amenity amenity = await _context.Amenities.FindAsync(id);
            _context.Entry(amenity).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

    }
}
