using Async_Inn.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Models
{
    public class Hotel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        // Navigation Properties
        public List<HotelRoom> HotelRoom { get; set; }

        public static implicit operator Hotel(HotelDTO v)
        {
            throw new NotImplementedException();
        }
    }
}
