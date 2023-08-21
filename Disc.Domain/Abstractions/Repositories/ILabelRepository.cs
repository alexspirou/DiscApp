using Disc.Domain.Entities;

namespace Disc.Domain.Abstractions.Repositories
{
    public interface ILabelRepository : IGenericRepository<MusicLabel>
    {
        public string MusicLabelNameById(uint id);
        public IEnumerable<Link> GetLinksById(uint id);
        public string GetCountryById(uint id);
    }
}
