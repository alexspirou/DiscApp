using Disc.Domain.Entities;

namespace Disc.Domain.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        IEnumerable<User> GetUserById(uint id);
        string GetNameByUserID(uint id);
    }
}


