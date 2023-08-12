using Disc.Domain.Entities;

namespace Disc.Domain.Repositories
{
    public interface IGenreRepository : IGenericRepository<Genre>
    {
        public string GetGenreNameById(uint id);
        public Task<string> GetGenreNameByIdAsync(uint id);
        public string GetStyleById(uint id);
        public Task<string> GetStyleByIdAsync(uint id);
    }
}
