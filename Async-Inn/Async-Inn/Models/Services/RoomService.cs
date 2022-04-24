using Async_Inn.Data;
using Async_Inn.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace Async_Inn.Models.Services
{
    public class RoomService : IRoom
    {
        public AsyncInnDbContext _context { get; set; }
        public RoomService(AsyncInnDbContext context)
        {
            _context = context;
        }
        public async Task<Room> Create(Room room)
        {
            _context.Entry(room).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return room;
        }

        public async Task Delete(int id)
        {
            Room room = await GetRoom(id);
            _context.Entry(room).State = EntityState.Deleted;
            await _context.SaveChangesAsync();

        }

        public async Task<Room> GetRoom(int id)
        {
            // Include all amenities in room  
            return await _context.Rooms.Include(x => x.RoomAmenity)
                                       .ThenInclude(e => e.Amenity)
                                       .FirstOrDefaultAsync(x=> x.ID==id);
        }

        public async Task<List<Room>> GetRooms()
        {
            return await _context.Rooms.Include(x => x.RoomAmenity)
                                       .ThenInclude(e => e.Amenity)
                                       .ToListAsync();
        }

        public async Task<Room> UpdateRoom(int id, Room room)
        {
            _context.Entry(room).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return room;
        }

        public async Task AddAmenityToRoom(int roomId, int amenityId)
        {
            RoomAmenity roomAmenity = new RoomAmenity()
            {
                RoomID = roomId,
                AmenityID = amenityId
            };
            _context.Entry(roomAmenity).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAmentityFromRoom(int roomId, int amenityId)
        {
            var removeAmentity = _context.RoomAmenity.FirstOrDefaultAsync(x => x.RoomID == roomId && x.AmenityID == amenityId);
            _context.Entry(removeAmentity).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
