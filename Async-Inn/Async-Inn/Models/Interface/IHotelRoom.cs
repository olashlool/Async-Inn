using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Models.Interface
{
    public interface IHotelRoom
    {
        // CREATE 
        Task<HotelRoom> Create(HotelRoom hotelRoomoom);
        // GET ALL
        Task<List<HotelRoom>> GetHotelRooms();
        // GET ONE BY ID
        Task<HotelRoom> GetHotelRoom(int hotelId, int roomNumber);
        // UPDATE
        Task<HotelRoom> Update(int hotelId, int roomNumber, HotelRoom hotelRoom);
        // DELETE
        Task Delete(int hotelId , int roomNumber);
    }
}
