using Disc.Domain.Abstractions.Repositories;
using Disc.Domain.Entities;
using Disc.Domain.Exceptions.ArtistExceptions;
using Disc.Domain.Exceptions.CountryExceptions;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace Disc.Infrastructure.Database.Repositories;
public class CountryRepository : GenericRepository<Country>, ICountryRepository
{

    public CountryRepository(DiscAppContext context) : base(context)
    {

    }
    public async Task<Country> CreateCountryAsync(Country country)
    {
        await InsertAsync(country);
        return country;
    }

    public async Task<string?> GetCountryNameByIdAsync(uint id)
    {
        var conditionName = await Context.Country.Where(c => c.CountryId == id).Select(c => c.CountryName).FirstOrDefaultAsync();
        return conditionName;
    }

    public async Task<IEnumerable<Artist>> GetArtistsByCountryIdAsync(uint id)
    {
        var releases = await Context.Country.Include(c => c.Artists).Where(c => c.CountryId == id).SelectMany(c => c.Artists).ToListAsync();
        return releases;
    }

    public async Task<Country?> GetCountryByNameAsync(string name)
    {
        var country = await Context.Country.Where(c => c.CountryName == name).FirstOrDefaultAsync();
        return country;
    }

}
