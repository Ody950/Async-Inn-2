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
using Async_Inn_2.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Async_Inn_2.Controllers
{
    [Authorize(Roles = "District Manager")]
    [Route("api/[controller]")]
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
        [Authorize(Roles = "Property Manager")]
        [Authorize(Roles = "Agent")]
        [AllowAnonymous]
        [HttpGet("{hotelId}/Rooms")]
        public async Task<ActionResult<IEnumerable<HotelRoomDTO>>> GetHotelRooms()
        {
            var rooms = await _hotelroom.GetHotelRooms();

            if (rooms == null)
          {
              return NotFound();
          }
            return Ok(rooms);
        }

        // GET: api/Hotels/{hotelId}/Rooms/{roomNumber}
        [Authorize(Roles = "Property Manager")]
        [Authorize(Roles = "Agent")]
        [AllowAnonymous]
        [HttpGet("{hotelId}/Rooms/{roomNumber}")]
        public async Task<ActionResult<HotelRoomDTO>> GetHotelRoom(int hotelid, int roomNumberid)
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
        [Authorize(Roles = "Property Manager")]
        [Authorize(Roles = "Agent")]
        [HttpPut("{hotelId}/Rooms/{roomNumber}")]
        public async Task<IActionResult> PutHotelRoom(int hotelid, int roomNumberid, HotelRoomDTO hotelRoom)
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
        [Authorize(Roles = "Property Manager")]
        [HttpPost("{hotelId}/Rooms")]
        public async Task<ActionResult<HotelRoomDTO>> PostHotelRoom(HotelRoomDTO hotelRoom)
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
