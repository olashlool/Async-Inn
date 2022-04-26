using Async_Inn.Data;
using Async_Inn.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace Async_Inn.Models.Services
{
    public class HotelRoomService : IHotelRoom
    {
        private readonly AsyncInnDbContext _context;

        public HotelRoomService(AsyncInnDbContext context)
        {
            _context = context;
        }
        public async Task<HotelRoom> Create(HotelRoom hotelRoom)
        {
            _context.Entry(hotelRoom).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return hotelRoom;
        }

        public async Task Delete(int hotelId, int roomNumber)
        {
            HotelRoom hotelRoom = await GetHotelRoom(hotelId, roomNumber);
            _context.Entry(hotelRoom).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<HotelRoom> GetHotelRoom(int hotelId, int roomNumber)
        {
            
            return await _context.HotelRoom.Include(x => x.Room)
                                                    .ThenInclude(x => x.RoomAmenity)
                                                    .ThenInclude(x => x.Amenity)
                                                    .FirstOrDefaultAsync(x => x.HotelID == hotelId && x.RoomNumber == roomNumber);
        }

        public async Task<List<HotelRoom>> GetHotelRooms()
        {
            return await _context.HotelRoom.Include(x => x.Room)
                                                      .ThenInclude(x => x.RoomAmenity)
                                                      .ThenInclude(x => x.Amenity)
                                                      .ToListAsync();
        }

        public async Task<HotelRoom> Update(int hotelId, int roomNumber, HotelRoom hotelRoom)
        {
            _context.Entry(hotelRoom).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return hotelRoom;
        }
    }
}
