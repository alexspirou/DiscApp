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
        var result = await Context.Artist.AsNoTracking().Where(a => a.ArtistId == id).Select(a => a.ArtistName).FirstOrDefaultAsync();
        return result;
    }
    public async Task<string?> GetRealNameByArtistIdAsync(uint id)
    {
        var result = await Context.Artist.AsNoTracking().Where(a => a.ArtistId == id).Select(a => a.RealName).FirstOrDefaultAsync();
        return result;
    }
    public async Task<IEnumerable> GetLinksByArtistIDAsync(uint id)
    {
        var result = await Context.Artist.AsNoTracking().Include(a => a.Links).Where(a => a.ArtistId == id).Select(a => a.Links).ToListAsync();
        return result;
    }
    public async Task<IEnumerable> GetMusicLabelByArtistIDAsync(uint id)
    {
        var result = await Context.Artist.AsNoTracking().Include(a => a.MusicLabel).Where(a => a.ArtistId == id).Select(a => a.MusicLabel).ToListAsync();
        return result;
    }

    public async Task<IEnumerable> GetReleaseByArtistIDAsync(uint id)
    {
        var result = await Context.Artist.AsNoTracking().Include(a => a.Release).Where(a => a.ArtistId == id).Select(a => a.Release).ToListAsync();
        return result;
    }

    public async Task<Artist?> GetArtistByNameAsync(string name)
    {
        var result = await Context.Artist.AsNoTracking()
            .Include(c => c.Country)
            .Include(l => l.Links ).ThenInclude(l => l.Link)
            .Include(m => m.MusicLabel).ThenInclude(m=>m.MusicLabel)
            .Include(r => r.Release).ThenInclude(c => c.Condition)
            .Include(r=>r.Release).ThenInclude(c=>c.Country)
            .Include(r=>r.Release).ThenInclude(r=>r.ReleaseGenre).ThenInclude(g=>g.Genre)
            .Include(r=>r.Release).ThenInclude(r=>r.ReleaseStyle).ThenInclude(s=>s.Style)
            .Where(a => a.ArtistName == name).FirstOrDefaultAsync();
        return result;
    }

    public async Task<IEnumerable<Artist>> GetAllArtistsAsync()
    {

        var test = Context.Artist
            .Include(a => a.Country)
            .Include(a => a.Release);

        var artists = await test.Select(a => new Artist
        {
            ArtistId = a.ArtistId,
            ArtistName = a.ArtistName,
            RealName = a.RealName,
            Release = a.Release != null ? a.Release.ToList() : null,
            Country = new Country { CountryName = a.Country.CountryName, CountryId = a.Country.CountryId }
        })
        .ToListAsync();

        return artists;

    }


}
