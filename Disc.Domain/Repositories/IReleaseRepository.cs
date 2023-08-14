using Disc.Domain.Entities;
using System.Collections;

namespace Disc.Domain.Repositories
{
    public interface IReleaseRepository : IGenericRepository<Release>
    {
        Task<Release> CreateReleaseAsync(Release newRelease);
        Task<Release> GetReleaseByTitleAsync(string name); 
        Task<Release> GetReleaseByDiscogIdAsync(uint id);
        string GetTitleById(uint id);
        Artist GetArtistById(uint id);
        Country GetCountryById(uint id);
        int GetReleaseYearById(uint id);
        IEnumerable GetGenreById(uint id);
        Condition GetConditionById(uint id);
    }
}



