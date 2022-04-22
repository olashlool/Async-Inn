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

namespace Async_Inn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelRoomsController : ControllerBase
    {
        private readonly IHotelRoom _hotelRoom;

        public HotelRoomsController(IHotelRoom hotelRoom)
        {
            _hotelRoom = hotelRoom;
        }

        // GET: api/HotelRooms
        [HttpGet("{hotelId}/Rooms")]
        public async Task<ActionResult<IEnumerable<HotelRoom>>> GetHotelRoom()
        {
            return Ok(await _hotelRoom.GetHotelRooms());
        }

        // GET: api/HotelRooms/5
        [HttpGet("{hotelId}/Rooms/{roomNumber}")]
        public async Task<ActionResult<HotelRoom>> GetHotelRoom(int hotelID , int roomNumber)
        {
            var hotelRoom = await _hotelRoom.GetHotelRoom(hotelID, roomNumber);
            if (hotelRoom == null)
            {
                return NotFound();
            }
            return Ok(hotelRoom);
        }

        // PUT: api/HotelRooms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{hotelId}/Rooms/{roomNumber}")]
        public async Task<IActionResult> PutHotelRoom(int hotelID, int roomNumber, HotelRoom hotelRoom)
        {
            if (hotelID != hotelRoom.HotelID && roomNumber != hotelRoom.RoomNumber)
            {
                return BadRequest();
            }

            var updateHotelRoom = await _hotelRoom.Update(hotelID, roomNumber, hotelRoom);
            return Ok(updateHotelRoom);
        }

        // POST: api/HotelRooms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{hotelId}/Rooms")]
        public async Task<ActionResult<HotelRoom>> PostHotelRoom(HotelRoom hotelRoom)
        {
            HotelRoom newHotelRoom = await _hotelRoom.Create(hotelRoom);

            return Ok(newHotelRoom);
        }

        // DELETE: api/HotelRooms/5
        [HttpDelete("{hotelId}/Rooms/{roomNumber}")]
        public async Task<IActionResult> DeleteHotelRoom(int hotelID, int roomNumber)
        {
            await _hotelRoom.Delete(hotelID, roomNumber);
            return NoContent();
        }
    }
}
