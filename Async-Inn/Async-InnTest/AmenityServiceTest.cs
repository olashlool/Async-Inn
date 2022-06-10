using Async_Inn.Models.DTOs;
using Async_Inn.Models.Interface;
using Async_Inn.Models.Services;
using AsyncInnTest;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace AsyncInnTesting
{
    public class AmenityServiceTest : Mock
    {
        private IAmenity BuildRepository()
        {
            return new AmenityService(_db);
        }
        [Fact]
        public async Task CanSaveAndGetAmenity()
        {
            // arrange
            var amenity = new AmenityDTO
            {
                ID = 4,
                Name = "BreakfastMachine",
            };

            var repository = BuildRepository();

            // act
            var saved = await repository.Create(amenity);

            // assert
            Assert.NotNull(saved);
            Assert.NotEqual(0, amenity.ID);
            Assert.Equal(saved.ID, amenity.ID);
            Assert.Equal(saved.Name, amenity.Name);

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
            List<AmenityDTO> result = await service.GetAmenities();

            // assert
            Assert.Empty(result);
        }

        [Fact]
        public async Task GetSingleAmenity()
        {
            // arrange
            var amenity = new AmenityDTO
            {
                Name = "Breakfast",
            };

            var amenity2 = new AmenityDTO
            {
                Name = "Lunch",
            };
            var service = BuildRepository();

            var saved = await service.Create(amenity);
            var saved2 = await service.Create(amenity2);

            // act
            var result4 = await service.GetAmenity(4);
            var result5 = await service.GetAmenity(5);

            // assert
            Assert.Equal("Breakfast", result4.Name);
            Assert.Equal("Lunch", result5.Name);
        }
        [Fact]
        public async Task GetAllAmenities()
        {
            // arrange
            var amenity = new AmenityDTO
            {
                ID = 4,
                Name = "BreakfastMachine",
            };

            var amenity2 = new AmenityDTO
            {
                ID = 5,
                Name = "LunchMachine",
            };

            var service = BuildRepository();

            var saved = await service.Create(amenity);
            var saved2 = await service.Create(amenity2);


            // act
            List<AmenityDTO> result = await service.GetAmenities();

            // assert
            Assert.Equal(5, result.Count);

        }

        [Fact]
        public async Task UpdateAmenity()
        {
            var updateAmenityInDB = new AmenityDTO
            {
                ID = 1,
                Name = "Mini Fridge",
            };

            var service = BuildRepository();

            // act
            var result = await service.UpdateAmenity(1, updateAmenityInDB);

            // assert
            Assert.Equal("Mini Fridge", result.Name);
            Assert.NotEqual("coffee maker", result.Name);

        }

        [Fact]
        public async Task DeleteAmenity()
        {

            var service = BuildRepository();


            // act & assert
            List<AmenityDTO> result = await service.GetAmenities();
            Assert.Equal(5, result.Count);
            await service.Delete(1);
            List<AmenityDTO> result2 = await service.GetAmenities();
            Assert.Equal(4, result2.Count);

        }
    }
}