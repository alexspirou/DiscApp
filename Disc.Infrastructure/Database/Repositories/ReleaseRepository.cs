using Azure;
using Azure.Core;
using Disc.Domain.Abstractions.Repositories;
using Disc.Domain.Entities;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace Disc.Infrastructure.Database.Repositories;

public class ReleaseRepository : GenericRepository<Release>, IReleaseRepository
{
    public ReleaseRepository(DiscAppContext context) : base(context)
    {

    }

    public async Task<Release> CreateReleaseAsync(Release newRelease)
    {
        var release = await GetReleaseByDiscogIdAsync(newRelease.DiscogsId);

        if (release is null)
        {
            release = new Release()
            {
                Artist = newRelease.Artist,
                Condition = newRelease.Condition,
                Country = newRelease.Country,
                DiscogsId = newRelease.DiscogsId,
                Title = newRelease.Title,
                ReleaseYear = newRelease.ReleaseYear,
                ReleaseGenre = newRelease.ReleaseGenre,
                ReleaseStyle = newRelease.ReleaseStyle
            };
            await InsertAsync(release);
        }
        return release;
    }

    public async Task<IEnumerable<ReleaseGenre>> CreateReleaseGenreAsync(Release release, Genre[] genres)
    {
        var releaseGenre = new List<ReleaseGenre>();
        foreach(var genre in genres)
        {
            releaseGenre.Add(new ReleaseGenre
            {
                Genre = genre,
                Release = release
            });
        }
        release.ReleaseGenre = releaseGenre;

        await UpdateAsync(release);
        return releaseGenre;
    }

    public async Task<IEnumerable<ReleaseStyle>> CreateReleaseStyleAsync(Release release, Style[] styles)
    {
        var releaseStyle = new List<ReleaseStyle>();
        foreach (var reqStyle in styles)
        {
            releaseStyle.Add(new ReleaseStyle()
            {
                Style = reqStyle,
                Release = release
            }); 
        }
        release.ReleaseStyle = releaseStyle;

        await UpdateAsync(release);

        return releaseStyle;

    }

    public async Task<Release> GetReleaseByDiscogIdAsync(uint discogdId)
    {
        try
        {
            var result = await Context.Release.Where(release => release.DiscogsId == discogdId).Select(release => release).FirstOrDefaultAsync();
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception("Disc excpeption", ex);
        }
    }
    public Artist GetArtistById(uint id)
    {
        try
        {
            var result = Context.Release.Include(a => a.Artist).Where(disc => disc.DiscogsId == id).Select(artist => artist.Artist).FirstOrDefault();
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception("Disc excpeption", ex);
        }
    }
    public Condition GetConditionById(uint id)
    {
        try
        {
            var condition = Context.Release.Where(disc => disc.DiscogsId == id).Select(artist => artist.Condition).FirstOrDefault();
            return condition;
        }
        catch (Exception ex)
        {
            throw new Exception("Release Country excpeption", ex);
        }
    }
    public Country GetCountryById(uint id)
    {
        try
        {
            var country = Context.Release.Where(disc => disc.DiscogsId == id).Select(artist => artist.Country).FirstOrDefault();
            return country;
        }
        catch (Exception ex)
        {
            throw new Exception("Release Country excpeption", ex);
        }
    }

    public IEnumerable GetGenreById(uint id)
    {
        try
        {
            return Context.Release.Where(disc => disc.DiscogsId == id).Select(artist => artist.ReleaseGenre);
        }
        catch (Exception ex)
        {
            throw new Exception("Disc excpeption", ex);
        }
    }

    public IEnumerable GetStyleByID(uint id)
    {
        try
        {
            return Context.Release.Where(disc => disc.DiscogsId == id).Select(artist => artist.ReleaseStyle).SingleOrDefault();
        }
        catch (Exception ex)
        {
            throw new Exception("Disc excpeption", ex);
        }
    }

    public int GetReleaseYearById(uint id)
    {

        try
        {
            return Context.Release.Where(disc => disc.DiscogsId == id).Select(artist => artist.ReleaseYear).FirstOrDefault();
        }
        catch (Exception ex)
        {
            throw new Exception("Disc excpeption", ex);
        }
    }

    public string GetTitleById(uint id)
    {
        try
        {
            return Context.Release.Where(disc => disc.DiscogsId == id).Select(artist => artist.Title).ToString();
        }
        catch (Exception ex)
        {
            throw new Exception("Disc excpeption", ex);
        }
    }

    public async Task<Release> GetReleaseByTitleAsync(string name)
    {
        try
        {
            var result = await Context.Release.Where(release => release.Title == name).Select(release => release).FirstOrDefaultAsync();
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception("Disc excpeption", ex);
        }
    }


}
