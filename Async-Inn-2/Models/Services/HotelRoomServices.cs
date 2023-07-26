using Async_Inn_2.Data;
using Async_Inn_2.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Async_Inn_2.Models.Services
{
    public class HotelRoomServices : IHotelRoom
    {
        private readonly AsyncInnDbContext _context;

        public HotelRoomServices(AsyncInnDbContext context)
        {
            _context = context;
        }

        // CREATE........................................................................

        public async Task<HotelRoom> CreateHotelRoom(HotelRoom hotelRoom)
        {
            _context.HotelRoom.Add(hotelRoom);
            await _context.SaveChangesAsync();

            return hotelRoom;
        }

        // Get HotelRooms........................................................................

        public async Task<List<HotelRoom>> GetHotelRooms()
        {
            var hotelRooms =  await _context.HotelRoom.Include(x => x.Room)
                                            .ThenInclude(a => a.RoomAmenity)
                                            .Include(x => x.Hotel)
                                            .ThenInclude(r => r.HotelRoom)
                                            .ToListAsync();
            return hotelRooms;
        }

        // Get HotelRoom by ID........................................................................

        public async Task<HotelRoom> GetHotelRoom(int hotelid, int roomNumberid)
        {
            var hotelRoom =  await _context.HotelRoom.Include(x => x.Room)
                                            .ThenInclude(c => c.RoomAmenity)
                                            .Include(x => x.Hotel)
                                            .ThenInclude(e => e.HotelRoom)
                                            .FirstOrDefaultAsync(x => x.HotelID == hotelid && x.RoomNumber == roomNumberid);
            return hotelRoom;
        }


        // Update HotelRoom by ID........................................................................


        public async Task<HotelRoom> UpdateHotelRoom(int hotelid, int roomNumberid, HotelRoom hotelRoom)
        {
            _context.Entry(hotelRoom).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return hotelRoom;
        }

        // Delete HotelRoom by ID........................................................................

        public async Task DeleteHotelRoom(int hotelid, int roomNumberid)
        {
            HotelRoom hotelRoom = await GetHotelRoom(hotelid, roomNumberid);
            if (hotelRoom != null)
            {
                _context.HotelRoom.Remove(hotelRoom);
                await _context.SaveChangesAsync();
            }
        }

    }
}
