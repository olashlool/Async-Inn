using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Models.Interface
{
    public interface IRoom
    {
        // CREATE 
        Task<Room> Create(Room room);
        // GET ALL
        Task<List<Room>> GetRooms();
        // GET ONE BY ID
        Task<Room> GetRoom(int id);
        // UPDATE
        Task<Room> UpdateRoom(int id, Room room);
        // DELETE 
        Task Delete(int id);

        Task AddAmenityToRoom(int roomId, int amenityId);
        Task RemoveAmentityFromRoom(int roomId, int amenityId);
    }
}
