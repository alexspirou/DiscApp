using Disc.Domain.Abstractions.Repositories;
using Disc.Domain.Entities;

namespace Disc.Infrastructure.Database.Repositories
{
    public class ReleaseStyleRepository : GenericRepository<ReleaseStyle>, IReleaseStyleRepository
    {
        public Task<ReleaseStyle> CreateReleaseStyleAsync(ReleaseStyle newReleaseStyle)
        {
            throw new NotImplementedException();
        }
    }
}
