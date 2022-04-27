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
    public class HotelService : IHotel
    {
        public AsyncInnDbContext _context;
        public HotelService(AsyncInnDbContext context)
        {
            _context = context;
        }
        public async Task<HotelDTO> Create(HotelDTO newHotelDTO)
        {
            Hotel newHotel = new Hotel 
            {
                ID=newHotelDTO.ID,
                Name = newHotelDTO.Name,
                StreetAddress = newHotelDTO.StreetAddress,
                City = newHotelDTO.City,
                State = newHotelDTO.State,
                Phone = newHotelDTO.Phone
            };
            _context.Entry(newHotel).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return newHotelDTO;
        }

        public async Task Delete(int id)
        {
            Hotel hotel = await _context.Hotels.FindAsync(id);
            _context.Entry(hotel).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<HotelDTO> GetHotel(int id)
        { 
            return await _context.Hotels.Select(x=> new HotelDTO { 
                    ID = x.ID,
                    Name= x.Name,
                    StreetAddress = x.StreetAddress,
                    City = x.City,
                    State = x.State,
                    Phone = x.Phone,
                    Rooms = x.HotelRoom.Select(x=> new HotelRoomDTO{ 
                            HotelID = x.HotelID,
                            RoomNumber = x.RoomNumber,
                            Rate = x.Rate,
                            PetFriendly = x.PetFriendly,
                            RoomID=x.RoomID,
                            Room= x.Room.HotelRoom.Select(x=> new RoomDTO { 
                                ID= x.Room.ID,
                                Name=x.Room.Name,
                                Layout = x.Room.Layout,
                                Amenities = x.Room.RoomAmenity.Select(x=> new AmenityDTO { 
                                    ID = x.Amenity.ID,
                                    Name= x.Amenity.Name
                                }).ToList()
                            }).FirstOrDefault()
                    }).ToList()
            }).FirstOrDefaultAsync(x => x.ID == id);
        }

        public async Task<List<HotelDTO>> GetHotels()
        {
            return await _context.Hotels.Select(x => new HotelDTO
            {
                ID = x.ID,
                Name = x.Name,
                StreetAddress = x.StreetAddress,
                City = x.City,
                State = x.State,
                Phone = x.Phone,
                Rooms = x.HotelRoom.Select(x => new HotelRoomDTO
                {
                    HotelID = x.HotelID,
                    RoomNumber = x.RoomNumber,
                    Rate = x.Rate,
                    PetFriendly = x.PetFriendly,
                    RoomID = x.RoomID,
                    Room = x.Room.HotelRoom.Select(x => new RoomDTO
                    {
                        ID = x.Room.ID,
                        Name = x.Room.Name,
                        Layout = x.Room.Layout,
                        Amenities = x.Room.RoomAmenity.Select(x => new AmenityDTO
                        {
                            ID = x.Amenity.ID,
                            Name = x.Amenity.Name
                        }).ToList()
                    }).FirstOrDefault()
                }).ToList()
            }).ToListAsync();
        }
        public Task<List<Hotel>> SearchByName(string term)
        {
            var result = _context.Hotels.Include(x => x.HotelRoom)
                                        .Where(x => x.Name.Contains(term))
                                        .ToListAsync();
            return result;
        }

        public async Task<HotelDTO> UpdateHotel(int id, HotelDTO newHotelDTO)
        {
            Hotel updateHotel = new Hotel
            {
                ID = newHotelDTO.ID,
                Name = newHotelDTO.Name,
                StreetAddress = newHotelDTO.StreetAddress,
                City = newHotelDTO.City,
                State = newHotelDTO.State,
                Phone = newHotelDTO.Phone
            };
            _context.Entry(updateHotel).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return newHotelDTO;
        }
    }
}
