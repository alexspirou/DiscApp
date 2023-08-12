using Disc.Domain.Entities;
using Domain.Repositories;
using Infrastructure.Database;
using System.Collections;

namespace Disc.Infrastructure.Database.Repositories;

public class ReleaseRepository : GenericRepository<Release>, IReleaseRepository
{
    public ReleaseRepository(DiscAppContext context) : base(context)
    {

    }
    public Artist GetArtistById(uint id)
    {
        try
        {
            return Context.Release.Where(disc => disc.DiscogsId == id).Select(artist => artist.Artist).FirstOrDefault();
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


}
