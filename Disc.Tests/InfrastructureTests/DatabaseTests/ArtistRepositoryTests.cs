using Disc.Domain.Entities;
using Disc.Infrastructure.Database.Repositories;
using FluentAssertions;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Disc.Tests.InfrastructureTests.DatabaseTests
{

    public class ArtistRepositoryTests
    {
        const int NumOfTestEntries = 10;
        public ArtistRepositoryTests()
        {

        }

        private async Task<DiscAppContext> GetDbContext()
        {

            var options = new DbContextOptionsBuilder<DiscAppContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
            var inMemoryDbContext = await DummyDataForRepositoriesTests.CreateDummyDataForTest(options);

            return inMemoryDbContext;
        }

 

        [Fact]
        public async Task CreateArtistAsync_LastEntry_Should_Equal_WithExpected()
        {
            //  Arrange
            var newArtist = new Artist
            {
                ArtistName = "Unit Test ArtistName",
                Country = new Country() { CountryName = "Unit Test Country" },
                RealName = "Unit Test RealName",
            };
            var dbContext = await GetDbContext();
            var artistRepository = new ArtistRepository(dbContext);

            // Act
            var createArtist = await artistRepository.CreateArtistAsync(newArtist);
            //Assert
            dbContext.Artist.Count().Should().Be(NumOfTestEntries);
            dbContext.Artist.Last().ArtistName.Should().BeEquivalentTo("Unit Test ArtistName");
            dbContext.Artist.Last().RealName.Should().BeEquivalentTo("Unit Test RealName");
            dbContext.Artist.Last().Country?.CountryName.Should().BeEquivalentTo( "Unit Test Country");

        }

        [Fact]
        public async Task GetNameByArtistIdAsync_LastEntry_ShouldBe_Equal_With_Expected()
        {
            //  Arrange
            var dbContext = await GetDbContext();
            var artistRepository = new ArtistRepository(dbContext);
            uint id = 1;
            // Act
            var artistName = await artistRepository.GetNameByArtistIdAsync(id);
            //Assert
            artistName.Should().Be($"ArtistName{id}");

        }
        
        [Fact]
        public async Task GetNameByArtistIdAsync_LastEntry_ShouldBe_Null()
        {
            //  Arrange
            var dbContext = await GetDbContext();
            var artistRepository = new ArtistRepository(dbContext);
            uint id = 100;
            // Act
            var artistName = await artistRepository.GetNameByArtistIdAsync(id);
            //Assert
            artistName.Should().BeNull();
        }       
        
        [Fact]
        public async Task GetArtistByNameAsync_LastEntry_ShouldBe_Equal_With_Expected()
        {
            //  Arrange
            var dbContext = await GetDbContext();
            var artistRepository = new ArtistRepository(dbContext);
            uint id = 1;
            // Act
            var createdArtist = await artistRepository.GetArtistByNameAsync($"ArtistName{1}");
            //Assert
            createdArtist.ArtistName.Should().BeEquivalentTo($"ArtistName{1}");
            createdArtist.ArtistId.Should().Be(id);
            createdArtist.RealName.Should().BeEquivalentTo($"RealName{1}");
            createdArtist.Country?.CountryName.Should().BeEquivalentTo($"ArtistCountryName{1}");
            createdArtist.Links?.First().Link.SiteUrl.Should().BeEquivalentTo($"www.Link{1}.com");
            createdArtist.Release?.First().Title.Should().BeEquivalentTo($"Title{1}");
            createdArtist.Release?.First().ReleaseYear.Should().Be(1991);
            createdArtist.Release?.First()?.ReleaseGenre?.First().Genre.GenreName.Should().BeEquivalentTo($"GenreName{1}");
            createdArtist.Release?.First()?.ReleaseStyle?.First().Style.StyleName.Should().BeEquivalentTo($"StyleName{1}");
            createdArtist.Release?.First()?.Condition?.ConditionName.Should().BeEquivalentTo($"ConditionName{1}");
            createdArtist.Release?.First()?.Condition?.Description.Should().BeEquivalentTo($"Description{1}");
        }


    }
}
