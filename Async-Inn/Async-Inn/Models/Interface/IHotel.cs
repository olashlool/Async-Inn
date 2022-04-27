using Async_Inn.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Models.Interface
{
    public interface IHotel
    {
        // CREATE 
        Task<HotelDTO> Create(HotelDTO hotel);
        // GET ALL
        Task<List<HotelDTO>> GetHotels();
        // GET ONE BY ID
        Task<HotelDTO> GetHotel(int id);
        // UPDATE
        Task<HotelDTO> UpdateHotel(int id, HotelDTO hotel);
        // DELETE
        Task Delete(int id);
        Task<List<Hotel>> SearchByName(string item);
    }
}
