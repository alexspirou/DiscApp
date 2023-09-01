using Disc.Domain.Entities;

namespace Disc.Domain.Abstractions.Repositories
{
    public interface IGenreRepository : IGenericRepository<Genre>
    {
        public Task<Genre> CreateGenreAsync(Genre newGener);
        public Task<string?> GetGenreNameByIdAsync(uint id);
        public Task<Genre?> GetGenreByIdAsync(uint id);
        public Task<Genre?> GetGenreByNameAsync(string name);
    }
}
