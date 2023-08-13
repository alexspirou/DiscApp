
using Disc.Domain.Entities;
using Disc.Domain.Repositories;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Disc.Infrastructure.Database.Repositories
{
    internal class GenreRepository : GenericRepository<Genre>, IGenreRepository
    {
        public GenreRepository(DiscAppContext context) : base(context)
        {

        }
        public string GetGenreNameById(uint id)
        {
            var result = GetGenreNameByIdAsync(id).Result;
            return result;
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
                throw new Exception("Artist exception", ex);
            }
        }


        public Genre GetGenreById(uint id)
        {
            var result = GetGenreByIdAsync(id).Result;
            return result;
        }

        public async Task<Genre> GetGenreByIdAsync(uint id)
        {
            var result = await Context.Genre.Include(genre => genre.GenreName).Where(genre => genre.GenreId == id).Select(genre => genre).FirstOrDefaultAsync();
            return result;
        }
    }
}
