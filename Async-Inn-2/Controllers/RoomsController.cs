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

namespace Async_Inn_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IRoom _room;

        public RoomsController(IRoom room)
        {
            _room = room;
        }


        // GET: api/Rooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomDTO>>> GetRooms()
        {
            var rooms = await _room.GetRooms();
            return Ok(rooms);
        }

        // GET: api/Rooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomDTO>> GetRoom(int id)
        {
            RoomDTO TheRoom = await _room.GetRoom(id);

            if (TheRoom == null)
            {
                return NotFound();
            }

            return TheRoom;
        }

        // PUT: api/Rooms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoom(int id, RoomDTO room)
        {
            if (id != room.ID)
            {
                return BadRequest();
            }
            var updateRoom = await _room.UpdateRoom(id, room);
            return Ok(updateRoom);
        }

        // POST: api/Rooms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<RoomDTO>> PostRoom(RoomDTO room)
        {
            if (room == null)
            {
                return Problem("Entity set 'AsyncInnDbContext.Rooms'  is null.");
            }
            var newRoom = await _room.CreateRoom(room);

            return Ok(newRoom);
        }

        // DELETE: api/Rooms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            await _room.DeleteRoom(id);
            return NoContent();
        }

        // Add AMENITY: {roomId}/Amenity/{amenityId}
        [HttpPost]
        [Route("{roomId}/Amenity/{amenityId}")]
        public async Task<IActionResult> AddRoomAmenity(int roomId, int amenityId)
        {
             await _room.AddAmenityToRoom(roomId, amenityId);

            return Ok();
        }


        //Delete Amenity:[Route("{roomId}/Amenity/{amenityId}")]
        [HttpDelete("{id}")]
        [Route("{roomId}/{amenityId}")]
        public async Task<IActionResult> RemoveAmenityFromRoom(int roomId, int amenityId)
        {
            await _room.RemoveAmentityFromRoom(roomId, amenityId);
            return NoContent();
        }
    }
}
