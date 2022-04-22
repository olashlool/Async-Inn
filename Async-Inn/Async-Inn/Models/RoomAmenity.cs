using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Models
{
    public class RoomAmenity
    {
        public int AmenitiesID { get; set; }
        public int RoomID { get; set; }

        // Navigation Properties
        public Amenity Amenity { get; set; }
        public Room Room { get; set; }
    }
}
