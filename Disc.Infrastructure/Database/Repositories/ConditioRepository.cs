using Disc.Domain.Abstractions.Repositories;
using Disc.Domain.Entities;
using Disc.Domain.Exceptions.ConditionExceptions;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Disc.Infrastructure.Database.Repositories;
public class ConditioRepository : GenericRepository<Condition>, IConditionRepository
{

    public ConditioRepository(DiscAppContext context) : base(context)
    {

    }

    public async Task<Condition> CreateConditonAsync(Condition newConditon)
    {
        Context.Condition.Add(newConditon);
        await SaveAsync();
        return newConditon;
    }

    public async Task<Condition?> GetConditionByIdAsync(uint id)
    {

        var result = await Context.Condition.Where(c => c.ConditionId == id).Select(c => c).FirstOrDefaultAsync();
        return result;
    }

    public async Task<Condition?> GetConditionByNameAsync(string conditionName)
    {
        var result = await Context.Condition.Where(c => c.ConditionName == conditionName).Select(c => c).FirstOrDefaultAsync();
        return result;
    }

    public async Task<string?> GetConditionNameByIdAsync(uint id)
    {
        var conditionName = await Context.Condition.Where(c => c.ConditionId == id).Select(c => c.ConditionName).FirstOrDefaultAsync();
        return conditionName;
    }


}
