using Async_Inn.Data;
using Async_Inn.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace Async_Inn.Models.Services
{
    public class HotelService : IHotel
    {
        public AsyncInnDbContext _context;
        public HotelService(AsyncInnDbContext context)
        {
            _context = context;
        }
        public async Task<Hotel> Create(Hotel hotel)
        {
            _context.Entry(hotel).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return hotel;
        }

        public async Task Delete(int id)
        {
            Hotel hotel = await GetHotel(id);
            _context.Entry(hotel).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<Hotel> GetHotel(int id)
        { 
            return await _context.Hotels.Include(x => x.HotelRoom)
                                             .ThenInclude(x => x.Room)
                                             .ThenInclude(x => x.RoomAmenity)
                                             .ThenInclude(x => x.Amenity)
                                             .FirstOrDefaultAsync(x => x.ID == id);
        }

        public async Task<List<Hotel>> GetHotels()
        {
            return await _context.Hotels.Include(x => x.HotelRoom)
                                             .ThenInclude(x => x.Room)
                                             .ThenInclude(x => x.RoomAmenity)
                                             .ThenInclude(x => x.Amenity)
                                             .ToListAsync();
        }

        public Task<List<Hotel>> SearchByName(string term)
        {
            var result = _context.Hotels.Include(x => x.HotelRoom)
                                        .Where(x => x.Name.Contains(term))
                                        .ToListAsync();
            return result;
        }

        public async Task<Hotel> UpdateHotel(int id, Hotel hotel)
        {
            _context.Entry(hotel).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return hotel;
        }
    }
}
