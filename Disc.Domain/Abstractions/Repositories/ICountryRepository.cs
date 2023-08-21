using Disc.Domain.Entities;
using System.Collections;

namespace Disc.Domain.Abstractions.Repositories
{
    public interface ICountryRepository : IGenericRepository<Country>
    {
        string GetCountryNameById(uint id);

        Task<string> GetCountryNameByIdAsync(uint id);

        IEnumerable GetReleasesByCountryId(uint id);

        IEnumerable GetArtistsByCountryId(uint id);

        Task<IEnumerable> GetArtistsByCountryIdAsync(uint id);

        Country GetCountryByName(string name);

        Task<Country> GetCountryByNameAsync(string name);

        Country CreateCountry(string countryName);

        Task<Country> CreateCountryAsync(string countryName);
    }
}