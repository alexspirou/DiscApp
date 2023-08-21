
using Disc.Domain.Abstractions.Repositories;
using Disc.Domain.Entities;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Disc.Infrastructure.Database.Repositories
{
    internal class GenreRepository : GenericRepository<Genre>, IGenreRepository
    {
        public GenreRepository(DiscAppContext context) : base(context)
        {

        }
        public async Task<uint> GetGenreIdByName(string name)
        {
            try
            {
                var result = await Context.Genre.Where(genre => genre.GenreName == name).Select(x=>x.GenreId).FirstAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Genre exception", ex);
            }
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
                throw new Exception("Genre exceptions", ex);
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
                throw new Exception("Artist exception", ex);
            }
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
