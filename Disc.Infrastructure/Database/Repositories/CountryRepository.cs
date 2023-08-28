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
        try
        {
            await InsertAsync(country);
            return country;
        }
        catch (Exception ex)
        {
            throw new CountryDbCreationException($"Failed to create country : {country.CountryName}", ex);
        }
    }

    public async Task<string> GetCountryNameByIdAsync(uint id)
    {
        try
        {
            var conditionName = await Context.Country.Where(c => c.CountryId == id).Select(c => c.CountryName).FirstOrDefaultAsync();
            return conditionName;
        }
        catch (Exception ex)
        {

            throw new CountryDbAccessException($"Failed to get Country with id {id}", ex);
        }

    }

    public async Task<IEnumerable> GetArtistsByCountryIdAsync(uint id)
    {
        try
        {
            var releases = await Context.Country.Include(c => c.Artists).Where(c => c.CountryId == id).Select(c => c.Artists).FirstOrDefaultAsync();
            return releases;
        }
        catch (Exception ex)
        {

            throw new ArtistDbAccessException($"Failed to get Artists from CountruId{id}", ex);
        }

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
            throw new CountryDbAccessException($"Failed to get country: {name} ", ex);
        }
    }

}
