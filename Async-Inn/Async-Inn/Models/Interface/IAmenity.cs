using Async_Inn.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Models.Interface
{
    public interface IAmenity
    {
        // CREATE
        Task<AmenityDTO> Create(AmenityDTO amenity);
        // GET ALL
        Task<List<AmenityDTO>> GetAmenities();
        // GET ONE BY ID
        Task<AmenityDTO> GetAmenity(int id);
        // UPDATE
        Task<AmenityDTO> UpdateAmenity(int id, AmenityDTO amenity);
        // DELETE
        Task Delete(int id);
    }
}
