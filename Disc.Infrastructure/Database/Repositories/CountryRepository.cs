using Disc.Domain.Entities;
using Disc.Domain.Repositories;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace Disc.Infrastructure.Database.Repositories;
public class CountryRepository : GenericRepository<Country>, ICountryRepository
{

    public CountryRepository(DiscAppContext context) : base(context)
    {

    }

    public string GetCountryNameById(uint id)
    {
        var result = GetCountryNameByIdAsync(id).Result;
        return result;
    } 
    public async Task<string> GetCountryNameByIdAsync(uint id)
    {
        var conditionName = await Context.Country.Where(c => c.CountryId == id).Select(c => c.CountryName).FirstOrDefaultAsync();
        return conditionName;
    }

    public IEnumerable GetReleasesByCountryId(uint id)
    {
        var releases = Context.Country.Include(c => c.Release).Where(c => c.CountryId == id).Select(c => c.Release).FirstOrDefault();
        return releases;
    }

    public IEnumerable GetArtistsByCountryId(uint id)
    {
        var releases = GetArtistsByCountryIdAsync(id).Result;
        return releases;
    }

    public async Task<IEnumerable> GetArtistsByCountryIdAsync(uint id)
    {
        var releases = await Context.Country.Include(c => c.Artists).Where(c => c.CountryId == id).Select(c => c.Artists).FirstOrDefaultAsync();
        return releases;
    } // TODO : Move to artist repo

    public Country GetCountryByName(string name)
    {
        var result = GetCountryByNameAsync(name).Result;
        return result;
    }

    public async Task<Country> GetCountryByNameAsync(string name)
    {
        try
        {
            var country = await Context.Country.Where(c => c.CountryName == name).FirstOrDefaultAsync();
            return country;
        }
        catch (Exception ex)
        {
            throw new Exception("Country exception", ex);
        }
    }

    public Country CreateCountry(string countryName)
    {
        return CreateCountryAsync(countryName).Result;
    }

    public async Task<Country> CreateCountryAsync(string countryName)
    {
        var country = GetCountryByName(countryName);

        if (country == null)
        {
            country = new Country()
            {
                CountryName = countryName
            };
            await InsertAsync(country);
        }
        return country;
    }


}
