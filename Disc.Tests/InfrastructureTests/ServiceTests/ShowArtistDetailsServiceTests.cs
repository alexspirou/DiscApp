using Disc.Application.DTOs.Artist;
using Disc.Infrastructure.Database.Repositories;
using Disc.Infrastructure.Services.ArtistDetailsImpl;
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
            var artistDetails =  await showArtistDetailsService.GetArtistDetailsAsync(id);

            artistDetails.ArtistName.Should().BeEquivalentTo($"ArtistName{id}");
            artistDetails.RealName.Should().BeEquivalentTo($"RealName{id}");
            artistDetails.Country.Should().BeEquivalentTo($"ArtistCountryName{id}");
            artistDetails.Links?.First()?.SiteUrl.Should().BeEquivalentTo($"www.Link{id}.com");
            artistDetails.Releases?.First()?.Title.Should().BeEquivalentTo($"Title{id}");
            artistDetails.Releases?.First()?.ReleaseYear.Should().Be(1991);
            artistDetails.Releases?.First()?.Genre.Should().BeEquivalentTo($"GenreName{id}");
            artistDetails.Releases?.First()?.Style.Should().BeEquivalentTo($"StyleName{id}");
            artistDetails.Releases?.First()?.Condition?.ConditionName.Should().BeEquivalentTo($"ConditionName{id}");
            artistDetails.Releases?.First()?.Condition?.Description.Should().BeEquivalentTo($"Description{id}");

        }

        [Fact]
        public async Task GetArtistDetails_Should_NotBe_Equal_As_Expected()
        {
            var artistRepo = new ArtistRepository(await GetDbContext());
            var showArtistDetailsService = new ShowArtistDetailsService(artistRepo);
            uint id = 2;
            var artistDetails = await showArtistDetailsService.GetArtistDetailsAsync(id);

            artistDetails.ArtistName.Should().NotBe("ArtistName1");
            artistDetails.RealName.Should().NotBe("RealName1");
            artistDetails.Country.Should().NotBe("ArtistCountryName1");
            artistDetails.Links?.First()?.SiteUrl.Should().NotBe("www.Link1.com");
            artistDetails.Releases?.First()?.Title.Should().NotBe("Title1");
            artistDetails.Releases?.First()?.ReleaseYear.Should().NotBe(1991);
            artistDetails.Releases?.First()?.Genre.Should().NotBeEquivalentTo("GenreName1");
            artistDetails.Releases?.First()?.Style.Should().NotBeEquivalentTo("StyleName1");
            artistDetails.Releases?.First()?.Condition?.ConditionName.Should().NotBeEquivalentTo("ConditionName1");
            artistDetails.Releases?.First()?.Condition?.Description.Should().NotBeEquivalentTo("Description1");
        }
    }
}



