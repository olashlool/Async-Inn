using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Models
{
    public class HotelRoom
    {
        public int HotelID { get; set; }
        public int RoomNumber { get; set; }
        public int RoomID { get; set; }
        public decimal Rate { get; set; }
        public bool PetFriendly  { get; set; }
        // Navigation Properties
        public Hotel Hotel { get; set; }
        public Room Room { get; set; }
    }
}
