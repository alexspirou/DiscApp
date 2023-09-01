using Disc.Domain.Abstractions.Repositories;
using Disc.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Disc.Infrastructure.Database.Repositories;

public class LinkRepository : GenericRepository<Link>, ILinkRepository
{
    public async Task<string?> GetUrlByIdAsync(uint id)
    {
        var resut = await Context.Link.Where(link => link.LinkId == id).Select(link => link.SiteUrl).FirstOrDefaultAsync();
        return resut;
    }
}