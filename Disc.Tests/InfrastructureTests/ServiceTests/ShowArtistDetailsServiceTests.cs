using Disc.Infrastructure.Database.Repositories;
using Disc.Infrastructure.Services;
using Disc.Tests.InfrastructureTests.DatabaseTests;
using FluentAssertions;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Disc.Tests.InfrastructureTests.ServiceTests
{
    public class ShowArtistDetailsServiceTests
    {
        public ShowArtistDetailsServiceTests()
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
        public async Task GetArtistDetails_Should_Be_Equal_As_Expected()
        {

            var artistRepo = new ArtistRepository(await GetDbContext());
            var showArtistDetailsService = new ShowArtistDetailsService(artistRepo);
            uint id = 1;
            var artistDetails =  await showArtistDetailsService.GetArtistDetailsAsync($"ArtistName{id}");

            artistDetails.ArtistDetails.ArtistName.Should().BeEquivalentTo($"ArtistName{id}");
            artistDetails.ArtistDetails.RealName.Should().BeEquivalentTo($"RealName{id}");
            artistDetails.ArtistDetails.Country.Should().BeEquivalentTo($"ArtistCountryName{id}");
            artistDetails.ArtistDetails.Links?.First()?.Should().BeEquivalentTo($"www.Link{id}.com");
            artistDetails.ArtistDetails.Releases?.First()?.Title.Should().BeEquivalentTo($"Title{id}");
            artistDetails.ArtistDetails.Releases?.First()?.ReleaseYear.Should().Be(1991);
            artistDetails.ArtistDetails.Releases?.First()?.Genre.Should().BeEquivalentTo($"GenreName{id}");
            artistDetails.ArtistDetails.Releases?.First()?.Style.Should().BeEquivalentTo($"StyleName{id}");
            artistDetails.ArtistDetails.Releases?.First()?.Condition?.ConditionName.Should().BeEquivalentTo($"ConditionName{id}");
            artistDetails.ArtistDetails.Releases?.First()?.Condition?.Description.Should().BeEquivalentTo($"Description{id}");

        }

        [Fact]
        public async Task GetArtistDetails_Should_NotBe_Equal_As_Expected()
        {
            var artistRepo = new ArtistRepository(await GetDbContext());
            var showArtistDetailsService = new ShowArtistDetailsService(artistRepo);
            uint id = 2;
            var artistDetails = await showArtistDetailsService.GetArtistDetailsAsync($"ArtistName{id}");

            artistDetails.ArtistDetails.ArtistName.Should().NotBe("ArtistName1");
            artistDetails.ArtistDetails.RealName.Should().NotBe("RealName1");
            artistDetails.ArtistDetails.Country.Should().NotBe("ArtistCountryName1");
            artistDetails.ArtistDetails.Links?.First().Should().NotBe("www.Link1.com");
            artistDetails.ArtistDetails.Releases?.First()?.Title.Should().NotBe("Title1");
            artistDetails.ArtistDetails.Releases?.First()?.ReleaseYear.Should().NotBe(1991);
            artistDetails.ArtistDetails.Releases?.First()?.Genre.Should().NotBeEquivalentTo("GenreName1");
            artistDetails.ArtistDetails.Releases?.First()?.Style.Should().NotBeEquivalentTo("StyleName1");
            artistDetails.ArtistDetails.Releases?.First()?.Condition?.ConditionName.Should().NotBeEquivalentTo("ConditionName1");
            artistDetails.ArtistDetails.Releases?.First()?.Condition?.Description.Should().NotBeEquivalentTo("Description1");
        }
    }
}



