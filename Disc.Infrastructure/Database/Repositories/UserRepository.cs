using Disc.Domain.Entities;
using Disc.Domain.Repositories;
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
            return Context.User.Where(usr => usr.UserId == id).Select(usr => usr.Username).ToString();
        }

        public IEnumerable<User> GetUserById(uint id)
        {
            try
            {
                return Context.User.Where(usr => usr.UserId == (int)id).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }
    }
}
