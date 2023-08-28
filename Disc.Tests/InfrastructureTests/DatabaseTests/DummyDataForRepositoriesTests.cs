using Disc.Domain.Entities;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disc.Tests.InfrastructureTests.DatabaseTests
{
    public class DummyDataForRepositoriesTests
    {
        public static async Task<DiscAppContext> CreateDummyDataForTest(DbContextOptions<DiscAppContext> options)
        {
            var inMemoryDbContext = new DiscAppContext(options);

            inMemoryDbContext.Database.EnsureCreated();


            if (await inMemoryDbContext.Artist.CountAsync() == 0)
            {

                for (var i = 1; i < 10; i++)
                {
                    //Create some dummy data
                    #region CreateReleaseData
                    var newRelease = new Release
                    {
                        Condition = new Condition { ConditionName = $"ConditionName{i}", Description = $"Description{i}" },
                        Country = new Country { CountryName = $"ReleaseCountryName{i}" },
                        Title = $"Title{i}",
                        ReleaseYear = 1990 + i,
                    };
                    inMemoryDbContext.Add(newRelease);

                    await inMemoryDbContext.SaveChangesAsync();

                    var newGenre = new Genre
                    {
                        GenreName = $"GenreName{i}"
                    };
                    var newReleaseGenre = new ReleaseGenre
                    {
                        Genre = newGenre,
                        Release = newRelease
                    };
                    inMemoryDbContext.Add(newReleaseGenre);

                    var newStyle = new Style
                    {
                        StyleName = $"StyleName{i}"
                    };
                    var newReleaseStyle = new ReleaseStyle
                    {
                        Style = newStyle,
                        Release = newRelease
                    };
                    inMemoryDbContext.Add(newReleaseStyle);

                    await inMemoryDbContext.SaveChangesAsync();

                    #endregion

                    #region CreateArtistData
                    var newArtist = new Artist
                    {
                        ArtistName = $"ArtistName{i}",
                        Country = new Country() { CountryName = $"ArtistCountryName{i}" },
                        RealName = $"RealName{i}",
                        Release = new List<Release>() { newRelease },
                    };
                    inMemoryDbContext.Add(newArtist);
                    await inMemoryDbContext.SaveChangesAsync();

                    var newLik = new Link
                    {
                        SiteUrl = $"www.Link{i}.com",
                    };
                    var newArtistLink = new ArtistLink
                    {
                        Artist = newArtist,
                        Link = newLik
                    };
                    inMemoryDbContext.Add(newArtistLink);

                    var newMusicLabel = new MusicLabel
                    {
                        LabelName = $"ArtistMusicLabel{i}",
                        Links = new List<Link>() { new Link { SiteUrl = $"www.ArtistMusicLabelLink{i}.com" } },
                        Country = new Country { CountryName = $"MusicLabelCountryName{i}" },
                    };
                    var newArtistLabel = new ArtistMusicLabel
                    {
                        Artist = newArtist,
                        MusicLabel = newMusicLabel
                    };
                    inMemoryDbContext.Add(newArtistLabel);
                    await inMemoryDbContext.SaveChangesAsync();
                    #endregion

                }

            }

            return inMemoryDbContext;
        }
    }
}
