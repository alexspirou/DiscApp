using Disc.Domain.Entities;
using System.Collections;

namespace Disc.Domain.Abstractions.Repositories
{
    public interface IReleaseRepository : IGenericRepository<Release>
    {
        Task<Release> CreateReleaseAsync(Release newRelease);
        Task<IEnumerable<ReleaseGenre>> CreateReleaseGenreAsync(Release release, Genre[] genre);
        Task<IEnumerable<ReleaseGenre>> GetReleaseGenreAsync(Release release, Genre[] genre);
        Task<IEnumerable<ReleaseStyle>> CreateReleaseStyleAsync(Release release, Style[] genre);
        Task<Release?> GetReleaseByTitleAsync(string name);
        Task<Release?> GetReleaseByDiscogIdAsync(uint id);
        Task<IEnumerable<Release>> GetReleaseRange(int from, int to);
    }
}



