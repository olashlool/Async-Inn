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
    public class HotelRoomService : IHotelRoom
    {
        private readonly AsyncInnDbContext _context;

        public HotelRoomService(AsyncInnDbContext context)
        {
            _context = context;
        }
        public async Task<HotelRoomDTO> Create(HotelRoomDTO NewHotelRoomDTO)
        {
            HotelRoom newHotelRoom = new HotelRoom
            {
                HotelID = NewHotelRoomDTO.HotelID,
                RoomNumber = NewHotelRoomDTO.RoomNumber,
                Rate = NewHotelRoomDTO.Rate,
                PetFriendly = NewHotelRoomDTO.PetFriendly,
                RoomID = NewHotelRoomDTO.RoomID
            };
            _context.Entry(newHotelRoom).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return NewHotelRoomDTO;
        }

        public async Task Delete(int hotelId, int roomNumber)
        {
            HotelRoom hotelRoom = await _context.HotelRoom.FindAsync(hotelId, roomNumber);
            _context.Entry(hotelRoom).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<HotelRoomDTO> GetHotelRoom(int hotelId, int roomNumber)
        {
            return await _context.HotelRoom.Select(hr => new HotelRoomDTO()
                                    {
                                        HotelID = hr.HotelID,
                                        RoomNumber = hr.RoomNumber,
                                        Rate = hr.Rate,
                                        PetFriendly = hr.PetFriendly,
                                        RoomID = hr.RoomID,
                                        Room = new RoomDTO()
                                        {
                                            ID = hr.Room.ID,
                                            Name = hr.Room.Name,
                                            Layout = hr.Room.Layout,
                                            Amenities = hr.Room.RoomAmenity
                                                           .Select(ra => new AmenityDTO()
                                                           {
                                                               ID = ra.Amenity.ID,
                                                               Name = ra.Amenity.Name
                                                           })
                                                           .ToList()
                                        }
                                    }).FirstOrDefaultAsync(x => x.HotelID == hotelId && x.RoomNumber == roomNumber);

            /*return await _context.HotelRoom.Include(x => x.Room)
                                                    .ThenInclude(x => x.RoomAmenity)
                                                    .ThenInclude(x => x.Amenity)
                                                    .FirstOrDefaultAsync(x => x.HotelID == hotelId && x.RoomNumber == roomNumber);*/
        }

        public async Task<List<HotelRoomDTO>> GetHotelRooms()
        {
             return await _context.HotelRoom.Select(hr => new HotelRoomDTO()
                                    {
                                        HotelID = hr.HotelID,
                                        RoomNumber = hr.RoomNumber,
                                        Rate = hr.Rate,
                                        PetFriendly = hr.PetFriendly,
                                        RoomID = hr.RoomID,
                                        Room = new RoomDTO()
                                        {
                                            ID = hr.Room.ID,
                                            Name = hr.Room.Name,
                                            Layout = hr.Room.Layout,
                                            Amenities = hr.Room.RoomAmenity
                                                           .Select(ra => new AmenityDTO()
                                                           {
                                                               ID = ra.Amenity.ID,
                                                               Name = ra.Amenity.Name
                                                           })
                                                           .ToList()
                                        }
                                    }).ToListAsync();
        }

        public async Task<HotelRoomDTO> Update(int hotelId, int roomNumber, HotelRoomDTO updateHotelRoomDTO)
        {
            HotelRoom updateHotelRoom = new HotelRoom
            {
                HotelID = updateHotelRoomDTO.HotelID,
                RoomNumber = updateHotelRoomDTO.RoomNumber,
                Rate = updateHotelRoomDTO.Rate,
                PetFriendly = updateHotelRoomDTO.PetFriendly,
                RoomID = updateHotelRoomDTO.RoomID
            };
            _context.Entry(updateHotelRoom).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return updateHotelRoomDTO;
        }
    }
}
