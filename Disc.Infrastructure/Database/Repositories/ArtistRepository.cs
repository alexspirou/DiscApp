using Disc.Application.Requests.ArtistOperations.GetAllArtist;
using Disc.Domain.Abstractions.Repositories;
using Disc.Domain.Entities;
using Disc.Domain.Exceptions.ArtistExceptions;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace Disc.Infrastructure.Database.Repositories;
public class ArtistRepository : GenericRepository<Artist>, IArtistRepository
{
    public ArtistRepository(DiscAppContext context) : base(context)
    {

    }


    public async Task<Artist?> CreateArtistAsync(Artist newArtist)
    {
        Context.Artist.Add(newArtist);
        await SaveAsync();
        return newArtist;
    }

    public async Task<string?> GetNameByArtistIdAsync(uint id)
    {
        var result = await Context.Artist
            .Where(a => a.ArtistId == id)
            .Select(a => a.ArtistName)
            .FirstOrDefaultAsync();
        return result;
    }
    public async Task<string?> GetRealNameByArtistIdAsync(uint id)
    {
        var result = await Context.Artist
            .Where(a => a.ArtistId == id)
            .Select(a => a.RealName)
            .FirstOrDefaultAsync();

        return result;
    }
    public async Task<IEnumerable<Link?>> GetLinksByArtistIDAsync(uint id)
    {
        var result = await Context.Artist
            .Include(a => a.Links)
            .Where(a => a.ArtistId == id)
            .SelectMany(a => a.Links)
            .Select(l => l.Link)
            .ToListAsync();

        return result;
    }
    public async Task<IEnumerable<MusicLabel?>> GetMusicLabelByArtistIDAsync(uint id)
    {
        var result = await Context.Artist
            .Include(a => a.MusicLabel)
            .Where(a => a.ArtistId == id)
            .SelectMany(a => a.MusicLabel)
            .Select(m => m.MusicLabel).ToListAsync();
        return result;
    }

    public async Task<IEnumerable<Release?>> GetReleaseByArtistIDAsync(uint id)
    {
        var result = await Context.Artist
            .Include(a => a.Release)
            .Include(r => r.Release).ThenInclude(a => a.Artist)
            .Where(a => a.ArtistId == id).SelectMany(a => a.Release).ToListAsync();
        return result;
    }

    public async Task<Artist> GetArtistByNameAsync(string name)
    {
        var result = await Context.Artist
            .Include(c => c.Country)
            .Include(l => l.Links).ThenInclude(l => l.Link)
            .Include(m => m.MusicLabel).ThenInclude(m => m.MusicLabel)
            .Include(r => r.Release).ThenInclude(c => c.Condition)
            .Include(r => r.Release).ThenInclude(c => c.Country)
            .Include(r => r.Release).ThenInclude(r => r.ReleaseGenre).ThenInclude(g => g.Genre)
            .Include(r => r.Release).ThenInclude(r => r.ReleaseStyle).ThenInclude(s => s.Style)
            .Where(a => a.ArtistName == name).FirstOrDefaultAsync();
        return result;
    }    
    
    public async Task<IEnumerable<Artist>> GetArtistsByNameAsync(IEnumerable<string> names)
    {
        var results = new List<Artist>();
        foreach(var name in names)
        {
            results.Add(await GetArtistByNameAsync(name));
        }
        return results;
    }

    public async Task<IEnumerable> GetAllArtistsAsync(int size, int page, Country country, MusicLabel musicLabel)
    {

        if (country is not null)
        {
            Context.Artist.Where(a => a.Country == country);
        }

        if (musicLabel is not null)
        {
            Context.Artist.Where(a => a.MusicLabel == musicLabel);
        }

        var artists = await Context.Artist
            .Include(a => a.Country)
            .Include(a => a.Release)
            .Skip(size* (page - 1))
            .Take(page)
            .ToListAsync();

        return artists;

    }

    public async Task<uint> GetArtistIdByNameAsync(string name)
    {
        var result = await Context.Artist
            .Where(a => a.ArtistName == name)
            .Select(a => a.ArtistId)
            .SingleOrDefaultAsync();
        return result;

    }

    public async Task<IEnumerable<Artist>> SearchArtistsByNameAsync(string name)
    {
        var results = await Context.Artist
            .AsNoTracking()
            .Where(x => x.ArtistName.ToLower().StartsWith(name.ToLower()))
            .ToListAsync();
        return results;
    }
}

