using Async_Inn.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Data
{
    public class AsyncInnDbContext : DbContext
    {
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Amenity> Amenities { get; set; }

        public AsyncInnDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hotel>().HasData(
                new Hotel
                {
                    ID = 1,
                    Name = "Mövenpick Hotel Amman",
                    StreetAddress = "Madina Monawarah Street, Al-Jathimiya St.",
                    City = "Amman",
                    Country="Jordan",
                    State = "Madina Monawarah",
                    Phone = "(06) 552 8822"
                },
                new Hotel
                {
                    ID = 2,
                    Name = "Opal Hotel",
                    StreetAddress = "Airport Rd., Amman 11123",
                    City = "Amman",
                    Country = "Jordan",
                    State = "Airport Rd",
                    Phone = "(06) 412 0021"
                },
                new Hotel
                {
                    ID = 3,
                    Name = "Movenpick Resort",
                    StreetAddress = "Dead Sea Road, Sweimah 11180 Jordan",
                    City = "Dead Sea",
                    Country = "Jordan",
                    State = "Dead Sea Road",
                    Phone = "(05) 356 1111"
                }
                );
            modelBuilder.Entity<Room>().HasData(
                new Room
                {
                    ID = 1,
                    Name = "Studio",
                    Layout = 0
                },
                new Room
                {
                    ID = 2,
                    Name = "One Bedroom",
                    Layout = 1
                },
                new Room
                {
                    ID = 3,
                    Name = "Two Bedroom",
                    Layout = 2
                }
                );
            modelBuilder.Entity<Amenity>().HasData(
                new Amenity
                {
                    ID = 1,
                    Name = "coffee maker"
                },
                new Amenity
                {
                    ID = 2,
                    Name = "ocean view"
                },
                new Amenity
                {
                    ID = 3,
                    Name = "Mini bar"
                }
                );
        }
    }
}
