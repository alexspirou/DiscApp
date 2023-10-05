using Disc.Domain.Abstractions.Repositories;
using Disc.Domain.Entities;
using Infrastructure.Database;

namespace Disc.Infrastructure.Database.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(DiscAppContext context) : base(context)
        {

        }

        public string GetNameByUserID(uint id)
        {
            var result = Context.User
                .Where(usr => usr.UserId == id)
                .Select(usr => usr.Username).FirstOrDefault();

            return result;
        }

        public IEnumerable<User?> GetUserById(uint id)
        {
            return Context.User
                .Where(usr => usr.UserId == (int)id)
                .ToList();
        }
    }
}
