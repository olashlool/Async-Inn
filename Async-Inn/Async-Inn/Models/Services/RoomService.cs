using Async_Inn.Data;
using Async_Inn.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Async_Inn.Models.DTOs;

namespace Async_Inn.Models.Services
{
    public class RoomService : IRoom
    {
        public AsyncInnDbContext _context { get; set; }
        public RoomService(AsyncInnDbContext context)
        {
            _context = context;
        }
        public async Task<RoomDTO> Create(RoomDTO newRoomDTO)
        {
            Room newRoom = new Room
            {
                ID = newRoomDTO.ID,
                Name = newRoomDTO.Name,
                Layout = newRoomDTO.Layout
            };
            _context.Entry(newRoom).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return newRoomDTO;
        }

        public async Task Delete(int id)
        {
            Room room = await _context.Rooms.FindAsync(id);
            _context.Entry(room).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<RoomDTO> GetRoom(int id)
        {
            // Include all amenities in room  
            return await _context.Rooms.Select(x=> new RoomDTO { 
                                        ID = x.ID,
                                        Name= x.Name,
                                        Layout = x.Layout,
                                        Amenities = x.RoomAmenity
                                                        .Select(x => new AmenityDTO { 
                                                        ID = x.Amenity.ID,
                                                        Name=x.Amenity.Name
                                                        }).ToList()
                                        }).FirstOrDefaultAsync(x=> x.ID==id);
        }

        public async Task<List<RoomDTO>> GetRooms()
        {
            return await _context.Rooms.Select(x=> new RoomDTO { 
                                        ID = x.ID,
                                        Name= x.Name,
                                        Layout = x.Layout,
                                        Amenities = x.RoomAmenity
                                                        .Select(x => new AmenityDTO { 
                                                        ID = x.Amenity.ID,
                                                        Name=x.Amenity.Name
                                                        }).ToList()
                                        }).ToListAsync();
        }

        public async Task<RoomDTO> UpdateRoom(int id, RoomDTO updateRoomDTO)
        {
            Room updateRoom = new Room
            {
                ID = updateRoomDTO.ID,
                Name = updateRoomDTO.Name,
                Layout = updateRoomDTO.Layout
            };
            
            _context.Entry(updateRoom).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return updateRoomDTO;
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
