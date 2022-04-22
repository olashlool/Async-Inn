using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Models
{
    public class Amenity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        // Navigation Properties
        public List<RoomAmenity> RoomAmenity { get; set; }

    }
}
