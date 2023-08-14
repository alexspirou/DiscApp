using Disc.Domain.Entities;

namespace Disc.Domain.Repositories
{
    public interface IReleaseStyleRepository : IGenericRepository<ReleaseStyle>
    {
        Task<ReleaseStyle> CreateReleaseStyleAsync(ReleaseStyle newReleaseStyle);
    }
}
