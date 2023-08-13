using Disc.Domain.Entities;
using Disc.Domain.Repositories;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace Disc.Infrastructure.Database.Repositories
{
    public class StyleRepository : GenericRepository<Style>, IStyleRepository
    {
        public StyleRepository(DiscAppContext context) : base(context)
        {

        }

        public string GetStyleNameById(uint id)
        {
            var styleName = Context.Style.Where(s => s.StyleId == id).Select(c => c.StyleName).FirstOrDefault();
            return styleName;
        }

        public IEnumerable GetReleaseStyle(uint id)
        {
            var styleName = Context.Style.Include(s => s.ReleaseStyle).Where(s => s.StyleId == id).Select(c => c.ReleaseStyle);
            return styleName;
        }
    }

}
