using Disc.Domain.Entities;
using Disc.Domain.Repositories;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace Disc.Infrastructure.Database.Repositories;
public class ConditioRepository : GenericRepository<Condition>, IConditionRepository
{

    public ConditioRepository(DiscAppContext context) : base(context)
    {

    }

    public string GetConditionNameById(uint id)
    {
        var conditionName = GetConditionNameByIdAsync(id).Result;
        return conditionName;
    }
    public async Task<string> GetConditionNameByIdAsync(uint id)
    {
        var conditionName = await Context.Condition.Where(c => c.ConditionId == id).Select(c => c.ConditionName).FirstOrDefaultAsync();
        return conditionName;
    }

    public IEnumerable GetReleaseByConditionId(uint id)
    {
        var releases = Context.Condition.Include(c => c.Release).Where(c => c.ConditionId == id).Select(c => c.Release).FirstOrDefault();
        return releases;
    }
    public async Task<IEnumerable> GetReleaseByConditionIdAsync(uint id)
    {
        var releases = await Context.Condition.Include(c => c.Release).Where(c => c.ConditionId == id).Select(c => c.Release).FirstOrDefaultAsync();
        return releases;
    }
}
