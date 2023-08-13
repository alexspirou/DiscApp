using Disc.Domain.Entities;
using Disc.Domain.Repositories;

namespace Disc.Infrastructure.Database.Repositories;

public class LinkRepository : GenericRepository<Link>, ILinkRepository
{
    public string GetUrlById(uint id)
    {
        {
            try
            {
                return Context.Link.Where(link => link.LinkId == id).Select(link => link.SiteUrl).ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("Link exception", ex);
            }
        }
    }
}