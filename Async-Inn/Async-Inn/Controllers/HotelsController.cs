using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Async_Inn.Data;
using Async_Inn.Models;
using Async_Inn.Models.Interface;
using Async_Inn.Models.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace Async_Inn.Controllers
{
    [Authorize(Roles = "District Manager, Property Manager, Agent")]
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly IHotel _hotel;

        public HotelsController(IHotel hotel)
        {
            _hotel = hotel;
        }

        // GET: api/Hotels
        [Authorize(Roles = "District Manager, Property Manager, Agent")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelDTO>>> GetHotels()
        {
            var list = await _hotel.GetHotels();
            return Ok(list);
        }

        // GET: api/Hotels/5
        [Authorize(Roles = "District Manager, Property Manager, Agent")]
        [HttpGet("{id}")]
        public async Task<ActionResult<HotelDTO>> GetHotel(int id)
        {
            var hotel = await _hotel.GetHotel(id);
            if (hotel == null)
            {
                return NotFound();
            }
            return hotel;
        }

        // PUT: api/Hotels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "District Manager, Property Manager, Agent")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotel(int id, HotelDTO hotel)
        {
            if (id != hotel.ID)
            {
                return BadRequest();
            }

            var updateHotel = await _hotel.UpdateHotel(id, hotel);
            return Ok(updateHotel);
        }

        // POST: api/Hotels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "District Manager, Property Manager")]
        [HttpPost]
        public async Task<ActionResult<HotelDTO>> PostHotel(HotelDTO hotel)
        {
            var newHotel = await _hotel.Create(hotel);
            return Ok(newHotel);
        }

        // DELETE: api/Hotels/5
        [Authorize(Roles = "District Manager")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            await _hotel.Delete(id);
            return NoContent();
        }
        [HttpGet("Name/{name}")]
        public async Task<IActionResult> Search(string term)
        {
            var books = await _hotel.SearchByName(term);
            return Ok(books);
        }
    }
}
