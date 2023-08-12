
using Disc.Domain.Entities;
using Domain.Repositories;
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


        public string GetStyleById(uint id)
        {
            var result = GetStyleByIdAsync(id).Result;
            return result;
        }

        public async Task<string> GetStyleByIdAsync(uint id)
        {
            var result = await Context.Style.Include(s => s.StyleName).Where(s => s.StyleId == id).Select(c => c.StyleName).FirstOrDefaultAsync();
            return result;
        }
    }
}
