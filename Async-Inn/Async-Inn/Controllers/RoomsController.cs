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
    [Route("api/rooms")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IRoom _room;

        public RoomsController(IRoom room)
        {
            _room = room;
        }

        // GET: api/Rooms
        [Authorize(Roles = "District Manager, Property Manager, Agent")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomDTO>>> GetRooms()
        {
            var list = await _room.GetRooms();
            return Ok(list);

        }


        // GET: api/Rooms/5
        [Authorize(Roles = "District Manager, Property Manager, Agent")]
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomDTO>> GetRoom(int id)
        {
            var room = await _room.GetRoom(id);
            if (room == null)
            {
                return NotFound();
            }
            return room;
        }


        // PUT: api/Rooms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "District Manager, Property Manager, Agent")]
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
        [Authorize(Roles = "District Manager, Property Manager")]
        [HttpPost]
        public async Task<ActionResult<Room>> PostRoom(RoomDTO room)
        {
            var newRoom = await _room.Create(room);
            return Ok(newRoom);
        }


        [Authorize(Roles = "District Manager")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            await _room.Delete(id);
            return NoContent();
        }


        //POST AMENITY:
        [Authorize(Roles = "District Manager, Property Manager")]
        [HttpPost]
        [Route("{amenityId}/{roomId}")]
        public async Task<IActionResult> AddAmenityToRoom(int roomId, int amenityId)
        {
            await _room.AddAmenityToRoom(roomId, amenityId);
            return NoContent();
        }


        //Delete Amenity:
        [Authorize(Roles = "District Manager")]
        [HttpDelete]
        [Route("{amenityId}/{roomId}")]
        public async Task<IActionResult> RemoveAmenityFromRoom(int roomId, int amenityId)
        {
            await _room.RemoveAmentityFromRoom(roomId, amenityId);
            return NoContent();
        }

    }
}
