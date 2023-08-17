using Disc.Domain.Entities;

namespace Disc.Domain.Repositories
{
    public interface IGenreRepository : IGenericRepository<Genre>
    {
        public Task<Genre> CreateGenreAsync(Genre newGener);
        public string GetGenreNameById(uint id);
        public Task<string> GetGenreNameByIdAsync(uint id);
        public Genre GetGenreById(uint id);
        public Task<Genre> GetGenreByIdAsync(uint id);
        public Task<Genre> GetGenreByNameAsync(string name);
    }
}
