using Disc.Domain.Entities;
using Disc.Domain.Repositories;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace Disc.Infrastructure.Database.Repositories;
public class ArtistRepository : GenericRepository<Artist>, IArtistRepository
{
    public ArtistRepository(DiscAppContext context) : base(context)
    {

    }
    public List<Artist> CreateArtists(List<Artist> newArtist)
    {
        var result = CreateArtistsAsync(newArtist).Result;
        return result;
    }

    public async Task<List<Artist>> CreateArtistsAsync(List<Artist> newArtists)
    {
        var createdArtistsList = new List<Artist>();
        foreach (var artist in newArtists)
        {
            var createdArtist = await CreateArtistAsync(artist);
            createdArtistsList.Add(createdArtist);
        }

        return createdArtistsList;
    }
    public async Task<Artist> CreateArtistAsync(Artist newArtist)
    {
        var foundArtist = await GetArtistByNameAsync(newArtist.ArtistName);

        if (foundArtist is null)
        {
            Context.Artist.Add(newArtist);
            await SaveAsync();
        }
        return newArtist;
    }
    public Artist CreateArtist(Artist newArtist)
    {
        var foundArtist = GetArtistByName(newArtist.ArtistName);

        if (foundArtist is null)
        {
            Context.Artist.Add(newArtist);
            Save();
        }
        return newArtist;
    }

    public string GetNameByArtistID(uint id)
    {
        try
        {
            var name = Context.Artist.Where(a => a.ArtistId == id).Select(a => a.ArtistName).FirstOrDefault();
            return name;
        }
        catch (Exception ex)
        {
            throw new Exception("Artist exception", ex);
        }
    }
    public string GetRealNameByArtistId(uint id)
    {
        try
        {
            var links = Context.Artist.Include(a => a.RealName).Where(a => a.ArtistId == id).Select(a => a.RealName).FirstOrDefault();
            return links;
        }
        catch (Exception ex)
        {
            throw new Exception("Artist RealName exception", ex);
        }
    }
    public IEnumerable GetLinksByArtistID(uint id)
    {
        try
        {
            var links = Context.Artist.Include(a => a.Links).Where(a => a.ArtistId == id).Select(a => a.Links);
            return links;
        }
        catch (Exception ex)
        {
            throw new Exception("Artist Links exception", ex);
        }
    }
    public IEnumerable GetMusicLabelByArtistID(uint id)
    {
        try
        {
            var musicLabels = Context.Artist.Include(a => a.MusicLabel).Where(a => a.ArtistId == id).Select(a => a.MusicLabel);
            return musicLabels;
        }
        catch (Exception ex)
        {
            throw new Exception("Artist Label exception", ex);
        }
    }

    public IEnumerable GetReleaseByArtistID(uint id)
    {
        try
        {
            var releases = Context.Artist.Include(a => a.Release).Where(a => a.ArtistId == id).Select(a => a.Release);
            return releases;
        }
        catch (Exception ex)
        {
            throw new Exception("Artist Label exception", ex);
        }
    }

    public Artist GetArtistByName(string name)
    {
        var result = GetArtistByNameAsync(name).Result;
        return result;
    }
    public async Task<Artist> GetArtistByNameAsync(string name)
    {
        try
        {
            var releases = await Context.Artist.Where(a => a.ArtistName == name).Select(a => a).FirstOrDefaultAsync();
            return releases;
        }
        catch (Exception ex)
        {
            throw new Exception("Artist Label exception", ex);
        }
    }


}
