using Async_Inn.Data;
using Async_Inn.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace Async_Inn.Models.Services
{
    public class AmenityService : IAmenity
    {
        public AsyncInnDbContext _context;
        public AmenityService(AsyncInnDbContext context)
        {
            _context = context;
        }
        public async Task<Amenity> Create(Amenity amenity)
        {
            _context.Entry(amenity).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return amenity;
        }

        public async Task Delete(int id)
        {
            Amenity amenity = await GetAmenity(id);
            _context.Entry(amenity).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<List<Amenity>> GetAmenities()
        {
            return await _context.Amenities.Include(x => x.RoomAmenity)
                                           .ThenInclude(x => x.Room)
                                           .ToListAsync();
        }

        public async Task<Amenity> GetAmenity(int id)
        {
            // Include all Rooms in Amenity  

            return await _context.Amenities.Include(x => x.RoomAmenity)
                                           .ThenInclude(x => x.Room)
                                           .FirstOrDefaultAsync(x => x.ID == id);
        }

        public async Task<Amenity> UpdateAmenity(int id, Amenity amenity)
        {
            _context.Entry(amenity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return amenity;
        }
    }
}
