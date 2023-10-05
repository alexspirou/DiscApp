
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

            Context.Genre.Add(newGenre);
            await SaveAsync();

            return newGenre;
        }

        public async Task<Genre?> GetGenreByNameAsync(string name)
        {
            var result = await Context.Genre
                .Where(genre => genre.GenreName == name)
                .SingleOrDefaultAsync();
            return result;
        }

        public async Task<string?> GetGenreNameByIdAsync(uint id)
        {
            var result = await Context.Genre
                .Where(genre => genre.GenreId == id)
                .Select(genre => genre.GenreName)
                .SingleOrDefaultAsync();

            return result;
        }

        public async Task<Genre?> GetGenreByIdAsync(uint id)
        {
            var result = await Context.Genre
                .Include(genre => genre.GenreName)
                .Where(genre => genre.GenreId == id)
                .Select(genre => genre)
                .SingleOrDefaultAsync();

            return result;
        }

    }
}
