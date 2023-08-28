
using Disc.Domain.Abstractions.Repositories;
using Disc.Domain.Entities;
using Disc.Domain.Exceptions.CountryExceptions;
using Disc.Domain.Exceptions.GenreExceptions;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Disc.Infrastructure.Database.Repositories
{
    internal class GenreRepository : GenericRepository<Genre>, IGenreRepository
    {
        public GenreRepository(DiscAppContext context) : base(context)
        {

        }

        public async Task<Genre> CreateGenreAsync(Genre newGenre)
        {
            try
            {
                Context.Genre.Add(newGenre);
                await SaveAsync();
                return newGenre;
            }
            catch (Exception ex)
            {
                throw new CountryDbCreationException($"Faied to create Genre: {newGenre.ToString()}", ex);
            }
        }

        public async Task<Genre> GetGenreByNameAsync(string name)
        {
            try
            {
                var result = await Context.Genre.Where(genre => genre.GenreName == name).FirstOrDefaultAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw new GenreDbAccessException($"Failed to get genre id with name {name}", ex);
            }
        }

        public async Task<string> GetGenreNameByIdAsync(uint id)
        {
            try
            {
                var result = await Context.Genre.Where(genre => genre.GenreId == id).Select(genre => genre.GenreName).FirstOrDefaultAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw new GenreDbAccessException($"Failed to get Genre name with id {id}", ex);
            }
        }

        public async Task<Genre> GetGenreByIdAsync(uint id)
        {
            try
            {
                var result = await Context.Genre.Include(genre => genre.GenreName).Where(genre => genre.GenreId == id).Select(genre => genre).FirstOrDefaultAsync();
                return result;
            }
            catch (Exception ex)
            {

                throw new GenreDbAccessException($"Failed to get Genre with id {id}", ex);
            }
        }
 
    }
}
