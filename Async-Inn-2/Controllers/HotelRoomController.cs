using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Async_Inn_2.Data;
using Async_Inn_2.Models;
using Async_Inn_2.Models.Interfaces;

namespace Async_Inn_2.Controllers
{
    [Route("api/Hotels/{hotelId}/Rooms")]
    [ApiController]
    public class HotelRoomController : ControllerBase
    {
        private readonly IHotelRoom _hotelroom;
        private object _hotelRoom;

        public HotelRoomController(IHotelRoom hotelroom)
        {
            _hotelroom = hotelroom;
        }

        // GET: api/Hotels/{hotelId}/Rooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelRoom>>> GetHotelRooms()
        {
            var rooms = await _hotelroom.GetHotelRooms();

            if (rooms == null)
          {
              return NotFound();
          }
            return Ok(rooms);
        }

        // GET: api/Hotels/{hotelId}/Rooms/{roomNumber}
        [HttpGet("{roomNumber}")]
        public async Task<ActionResult<HotelRoom>> GetHotelRoom(int hotelid, int roomNumberid)
        {
            var hotelRoom = await _hotelroom.GetHotelRoom(hotelid, roomNumberid);
            if (hotelRoom == null)
            {
                return NotFound();
            }
            return Ok(hotelRoom);
        }

        // PUT: api/Hotels/{hotelId}/Rooms/{roomNumber}
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{roomNumber}")]
        public async Task<IActionResult> PutHotelRoom(int hotelid, int roomNumberid, HotelRoom hotelRoom)
        {
            if (hotelid != hotelRoom.HotelID && roomNumberid != hotelRoom.RoomNumber)
            {
                return BadRequest();
            }

            var updateHotelRoom = await _hotelroom.UpdateHotelRoom(hotelid, roomNumberid, hotelRoom);
            return Ok(updateHotelRoom);
        }


        // POST: api/Hotels/{hotelId}/Rooms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HotelRoom>> PostHotelRoom(HotelRoom hotelRoom)
        {
            if (hotelRoom == null)
            {
                return Problem("Entity set 'AsyncInnDbContext.HotelRoom' is null.");
            }
            var newHotel = await _hotelroom.CreateHotelRoom(hotelRoom);

            return Ok(newHotel);
        }

        // DELETE: api/Hotels/{hotelId}/Rooms/{roomNumber}
        [HttpDelete("{roomNumber}")]
        public async Task<IActionResult> DeleteHotelRoom(int hotelid, int roomNumberid)
        {
            await _hotelroom.DeleteHotelRoom(hotelid, roomNumberid);
            return NoContent();
        }

        
    }
}
