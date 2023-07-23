using Async_Inn_2.Data;
using Async_Inn_2.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace Async_Inn_2.Models.Services
{
    public class HotelServices : IHotel
    {

        private readonly AsyncInnDbContext _context;

        public HotelServices(AsyncInnDbContext context)
        {
            _context = context;
        }

        // CREATE........................................................................
        public async Task<Hotel> CreateHotel(Hotel newHotel)
        {
            _context.Hotels.Add(newHotel);
            await _context.SaveChangesAsync();

            return newHotel;
        }

        // Get Amenities........................................................................

        public async Task<List<Hotel>> GetHotels()
        {

            var hotels = await _context.Hotels.ToListAsync();
            return hotels;
        }

        // Get Amenity by ID........................................................................
        public async Task<Hotel> GetHotel(int id)
        {
            var hotel = await _context.Hotels.FindAsync(id);
            return hotel;
        }


        // Update Amenity by ID........................................................................


        public async Task<Hotel> UpdateHotel(int id, Hotel updateHotel)
        {
            _context.Entry(updateHotel).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return updateHotel;
        }


        // Delete Amenity by ID........................................................................

        public async Task DeleteHotel(int id)
        {
            Hotel hotel = await GetHotel(id);
            if (hotel != null)
            {
                _context.Hotels.Remove(hotel);
                await _context.SaveChangesAsync();
            }
        }
    }
}
