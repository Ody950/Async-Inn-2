﻿using System;
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
    public class AmenitiesController : ControllerBase
    {
        private readonly IAmenity _amenity;

        public AmenitiesController(IAmenity amenity)
        {
            _amenity = amenity;
        }

        // GET: api/Amenities
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AmenityDTO>>> GetAmenities()
        {
            var ameneties = await _amenity.GetAmenities();
            return Ok(ameneties);
        }

        // GET: api/Amenities/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<AmenityDTO>> GetAmenity(int id)
        {
            AmenityDTO TheAmenity = await _amenity.GetAmenity(id);

            if (TheAmenity == null)
          {
              return NotFound();
          }

            return TheAmenity;
        }

        // PUT: api/Amenities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "District Manager, Property Manager, Agent")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAmenity(int id, AmenityDTO amenity)
        { 

              if (id != amenity.ID)
                {
                return BadRequest();
                }
            var updateAmenity = await _amenity.UpdateAmenity(id, amenity);
            return Ok(updateAmenity);


          }

        // POST: api/Amenities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AmenityDTO>> PostAmenity(AmenityDTO amenity)
        {


          if (amenity == null)
          {
              return Problem("Entity set 'AsyncInnDbContext.Amenities'  is null.");
          }
            AmenityDTO newAmenity = await _amenity.CreateAmenity(amenity);

            return Ok(newAmenity);
        }

        // DELETE: api/Amenities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAmenity(int id)
        {
            await _amenity.DeleteAmenity(id);
            return NoContent();
        }


    }
}
