using Async_Inn_2.Data;
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
        public async Task<Amenity> CreateAmenity(Amenity newAmenity)
        {
            _context.Amenities.Add(newAmenity);
            await _context.SaveChangesAsync();
            return newAmenity;
        }

        // Get Amenities........................................................................

        public async Task<List<Amenity>> GetAmenities()
        {

            var amenities = await _context.Amenities.ToListAsync();
            return amenities;
        }

        // Get Amenity by ID........................................................................
        public async Task<Amenity> GetAmenity(int id)
        {
            var amenity = await _context.Amenities.FindAsync(id);
            return amenity;
        }

        // Update Amenity by ID.......................................................................


        public async Task<Amenity> UpdateAmenity(int id, Amenity updateAmenity)
        {
            _context.Entry(updateAmenity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return updateAmenity;
        }


        // Delete Amenity by ID.......................................................................

        public async Task DeleteAmenity(int id)
        {
            Amenity amenity = await GetAmenity(id);
            if (amenity != null)
            {
                _context.Amenities.Remove(amenity);
                await _context.SaveChangesAsync();
            }
        }

    }
}
