using Disc.Domain.Entities;
using System.Collections;

namespace Disc.Domain.Abstractions.Repositories
{
    public interface ICountryRepository : IGenericRepository<Country>
    {
        Task<Country> CreateCountryAsync(Country countryName);
        Task<Country> GetCountryByNameAsync(string name);

        Task<string?> GetCountryNameByIdAsync(uint id);

        Task<IEnumerable<Artist>> GetArtistsByCountryIdAsync(uint id);

    }
}