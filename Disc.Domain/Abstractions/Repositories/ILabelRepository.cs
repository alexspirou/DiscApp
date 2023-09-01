using Disc.Domain.Entities;

namespace Disc.Domain.Abstractions.Repositories
{
    public interface ILabelRepository : IGenericRepository<MusicLabel>
    {
        Task<MusicLabel> CreateMusicLabelAsync(MusicLabel newLabel);
        public Task<string?> GetMusicLabelNameByIdAsync(uint id);
        public Task <IEnumerable<Link>> GetLinksByIdAsync(uint id);
        public Task<Country?> GetCountryByIdAsync(uint id);

        Task<MusicLabel?> GetMusicLabelByNameAsync(string name);
    }
}
