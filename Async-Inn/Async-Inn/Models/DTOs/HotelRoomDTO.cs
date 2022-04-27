using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Models.DTOs
{
    public class HotelRoomDTO
    {
        public int HotelID { get; set; }
        public int RoomNumber { get; set; }
        public decimal Rate { get; set; }
        public bool PetFriendly { get; set; }
        public int RoomID { get; set; }
        public RoomDTO Room { get; set; }
    }
}
