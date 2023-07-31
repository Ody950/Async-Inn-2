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

        public async Task DeleteAmenity(int id)
        {
            Amenity amenity = await _context.Amenities.FindAsync(id);
            _context.Entry(amenity).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

    }
}
