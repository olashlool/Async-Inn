using Async_Inn.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Models.Interface
{
    public interface IRoom
    {
        // CREATE 
        Task<RoomDTO> Create(RoomDTO room);
        // GET ALL
        Task<List<RoomDTO>> GetRooms();
        // GET ONE BY ID
        Task<RoomDTO> GetRoom(int id);
        // UPDATE
        Task<RoomDTO> UpdateRoom(int id, RoomDTO room);
        // DELETE 
        Task Delete(int id);

        Task AddAmenityToRoom(int roomId, int amenityId);
        Task RemoveAmentityFromRoom(int roomId, int amenityId);
    }
}
