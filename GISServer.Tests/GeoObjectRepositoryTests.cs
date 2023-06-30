using GISServer.Domain.Model;
using GISServer.Infrastructure.Data;
using GISServer.Infrastructure.Service;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace GISServer.Tests
{
    public class GeoObjectRepositoryTests
    {
        private Context GetDatabase()
        {
            var options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            return new Context(options);
        }

        [Fact]
        public async void CanCreateGeoObject()
        {
            // Arrange
            using var context = GetDatabase();
            var repository = new GeoObjectRepository(context);

            GeoObject geoObject = new GeoObject
            {
                Name = "Test"
            };

            // Act
            repository.AddGeoObject(geoObject);
            context.SaveChanges();

            // Assert
            Assert.Equal(1, context.GeoObjects.Count());
            Assert.Equal("Test", context.GeoObjects.Single().Name);
        }
        
        [Fact]
        public async void CanRetrieveGeoObject()
        {
            // Arrange
            using var context = GetDatabase();
            var repository = new GeoObjectRepository(context);

            GeoObject geoObject = new GeoObject
            {
                Name = "Test"
            };
            repository.AddGeoObject(geoObject);
            context.SaveChanges();

            // Act
            var result = await repository.GetGeoObject(geoObject.Id);

            // Assert
            Assert.Equal(geoObject.Name, result.Name);
        }

        [Fact]
        public async void CanUpdateGeoObject()
        {
            // Arrange
            using var context = GetDatabase();
            var repository = new GeoObjectRepository(context);
            GeoObject geoObject = new GeoObject
            {
                Name = "Test"
            };
            repository.AddGeoObject(geoObject);
            context.SaveChanges();

            // Act
            geoObject.Name = "Test updated";
            repository.UpdateGeoObject(geoObject);
            context.SaveChanges();

            // Assert
            var result = await repository.GetGeoObject(geoObject.Id);
            Assert.Equal("Test updated", result.Name);
        }

        [Fact]
        public async void CanDeleteGeoObject()
        {
            // Arrange
            using var context = GetDatabase();
            var repository = new GeoObjectRepository(context);
            GeoObject geoObject = new GeoObject
            {
                Name = "Test"
            };
            repository.AddGeoObject(geoObject);
            context.SaveChanges();

            // Act
            repository.DeleteGeoObject(geoObject.Id);
            context.SaveChanges();

            // Assert
            Assert.Equal(0, context.GeoObjects.Count());
        }
    }
}
