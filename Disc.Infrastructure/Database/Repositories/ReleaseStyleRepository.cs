using Disc.Domain.Entities;
using Disc.Domain.Repositories;

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
