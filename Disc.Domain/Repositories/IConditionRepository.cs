using Disc.Domain.Entities;
using System.Collections;

namespace Disc.Domain.Repositories
{
    public interface IConditionRepository : IGenericRepository<Condition>
    {
        string GetConditionNameById(uint id);
        IEnumerable GetReleaseByConditionId(uint id);
    }
}

