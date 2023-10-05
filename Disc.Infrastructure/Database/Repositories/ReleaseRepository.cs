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
        Context.Release.Update(newRelease);
        await SaveAsync();

        return newRelease;
    }

    public async Task<IEnumerable<ReleaseGenre>> CreateReleaseGenreAsync(Release release, Genre[] genres)
    {
        var releaseGenre = new List<ReleaseGenre>();
        foreach (var genre in genres)
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

    public async Task<Release?> GetReleaseByDiscogIdAsync(uint discogdId)
    {
        var result = await Context.Release
            .Where(release => release.DiscogsId == discogdId)
            .Select(release => release)
            .SingleOrDefaultAsync();

        return result;
    }

    public async Task<Release?> GetReleaseByTitleAsync(string name)
    {
        var result = await Context.Release
            .Where(release => release.Title == name)
            .Select(release => release)
            .FirstOrDefaultAsync();

        return result;
    }

    public async Task<IEnumerable<ReleaseGenre>> GetReleaseGenreAsync(Release release, Genre[] genre)
    {
        var result = await Context.Release
            .Where(release => release.DiscogsId == release.DiscogsId)
            .Include(g => g.ReleaseGenre)
            .SelectMany(x=> x.ReleaseGenre)
            .ToListAsync();

        return result;
    }
}
