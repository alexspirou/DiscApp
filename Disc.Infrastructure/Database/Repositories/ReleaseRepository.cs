using Azure;
using Disc.Domain.Entities;
using Disc.Domain.Repositories;
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

    public async Task<IEnumerable<ReleaseGenre>> CreateReleaseGenreAsync(Release release, Genre genre)
    {
        var ReleaseGenre =  release.ReleaseGenre = new List<ReleaseGenre>
        { 
            new ReleaseGenre
            {
                Genre = genre,
                Release = release
            }
        };

        await InsertAsync(release);

        return ReleaseGenre;
    }

    public async Task<IEnumerable<ReleaseStyle>> CreateReleaseStyleAsync(Release release, Style style)
    {
        var ReleaseStyle = release.ReleaseStyle = new List<ReleaseStyle>
        {
            new ReleaseStyle
            {
                Style = style,
            }
        };

        await InsertAsync(release);

        return ReleaseGenre;
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
            return Context.Release.Where(disc => disc.DiscogsId == id).Select(artist => artist.ReleaseStyle);
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
