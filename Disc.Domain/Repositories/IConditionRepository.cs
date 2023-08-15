using Disc.Domain.Entities;
using System.Collections;

namespace Disc.Domain.Repositories
{
    public interface IConditionRepository : IGenericRepository<Condition>
    {
        Task<Condition> CreateConditonAsync(Condition newConditon);
        Task<string> GetConditionNameByIdAsync(uint id);

        Task<Condition> GetConditionByNameAsync(string conditionName);
        Task<Condition> GetConditionByIdAsync(uint id);
    }
}

