using Disc.Domain.Entities;
using System.Collections;

namespace Disc.Domain.Repositories
{
    public interface IStyleRepository : IGenericRepository<Style>
    {
        string GetStyleNameById(uint id);
        IEnumerable GetReleaseStyle(uint id);
    }
}
