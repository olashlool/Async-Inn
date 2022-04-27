using Async_Inn.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Models.Interface
{
    public interface IHotelRoom
    {
        // CREATE 
        Task<HotelRoomDTO> Create(HotelRoomDTO hotelRoomoom);
        // GET ALL
        Task<List<HotelRoomDTO>> GetHotelRooms();
        // GET ONE BY ID
        Task<HotelRoomDTO> GetHotelRoom(int hotelId, int roomNumber);
        // UPDATE
        Task<HotelRoomDTO> Update(int hotelId, int roomNumber, HotelRoomDTO HotelRoomDTO);
        // DELETE
        Task Delete(int hotelId , int roomNumber);
    }
}
