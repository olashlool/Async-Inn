using Async_Inn.Models.DTOs;
using Async_Inn.Models.Interface;
using Async_Inn.Models.Services;
using AsyncInnTest;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;


namespace Async_InnTest
{
    public class HotelServiceTest :Mock
    {
        private IHotel BuildRepository()
        { 
            return new HotelService(_db);
        }
        [Fact]
        public async Task CanSaveAndGetHotel()
        {
            // arrange
            var hotel = new HotelDTO
            {
                ID = 4,
                Name = "Test01",
            };

            var repository = BuildRepository();

            // act
            var saved = await repository.Create(hotel);

            // assert
            Assert.NotNull(saved);
            Assert.NotEqual(0, hotel.ID);
            Assert.Equal(saved.ID, hotel.ID);
            Assert.Equal(saved.Name, hotel.Name);
        }

        [Fact]
        public async Task EmptyTest() // Can Check If There Are No Amenities
        {
            // arrange
            var service = BuildRepository();

            await service.Delete(1);
            await service.Delete(2);
            await service.Delete(3);

            // act
            List<HotelDTO> result = await service.GetHotels();

            // assert
            Assert.Empty(result);
        }

        [Fact]
        public async Task GetSingleHotel()
        {
            // arrange
            var hotel = new HotelDTO
            {
                Name = "Test01",
            };

            var hotel2 = new HotelDTO
            {
                Name = "Test02",
            };
            var service = BuildRepository();

            var saved = await service.Create(hotel);
            var saved2 = await service.Create(hotel2);

            // act
            var result = await service.GetHotel(4);
            var result2 = await service.GetHotel(5);

            // assert
            Assert.Equal("Test01", result.Name);
            Assert.Equal("Test02", result2.Name);
        }
        [Fact]
        public async Task GetAllHotels()
        {
            // arrange
            var hotel = new HotelDTO
            {
                ID = 4,
                Name = "BreakfastMachine",
            };

            var hotel2 = new HotelDTO
            {
                ID = 5,
                Name = "LunchMachine",
            };

            var service = BuildRepository();

            var saved = await service.Create(hotel);
            var saved2 = await service.Create(hotel2);


            // act
            List<HotelDTO> result = await service.GetHotels();

            // assert
            Assert.Equal(5, result.Count);

        }

        [Fact]
        public async Task UpdateAmenity()
        {
            var updateHotelInDB = new HotelDTO
            {
                ID = 1,
                Name = "Test",
            };

            var service = BuildRepository();

            // act
            var result = await service.UpdateHotel(1, updateHotelInDB);

            // assert
            Assert.Equal("Test", result.Name);
            Assert.NotEqual("Mövenpick Hotel Amman", result.Name);

        }

        [Fact]
        public async Task DeleteAmenity()
        {
            var service = BuildRepository();

            // act & assert
            List<HotelDTO> result = await service.GetHotels();
            Assert.Equal(3, result.Count);
            await service.Delete(1);
            List<HotelDTO> result2 = await service.GetHotels();
            Assert.Equal(2, result2.Count);

        }
    }
}
