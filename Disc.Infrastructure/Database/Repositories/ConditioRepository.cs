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
        try
        {
            Context.Condition.Add(newConditon);
            await SaveAsync();
            return newConditon;
        }
        catch(Exception ex)
        {
            throw new CondtionDbCreationException($"Failed to create Condition: {newConditon.ToString()}", ex);
        }

    }

    public async Task<Condition> GetConditionByIdAsync(uint id)
    {
        try
        {
            var result = await Context.Condition.Where(c => c.ConditionId == id).Select(c => c).FirstOrDefaultAsync();
            return result;
        }
        catch (Exception ex)
        {
            throw new CondtionDbCreationException($"Failed to get Condtion with id: {id}", ex);
        }
    }

    public async Task<Condition> GetConditionByNameAsync(string conditionName)
    {
        try
        {
            var result = await Context.Condition.Where(c => c.ConditionName == conditionName).Select(c => c).FirstOrDefaultAsync();
            return result;
        }
        catch(Exception ex)
        {
            throw new CondtionDbCreationException($"Failed to get Condtion with name: {conditionName}", ex);
        }
    }

    public async Task<string> GetConditionNameByIdAsync(uint id)
    {
        try
        {
            var conditionName = await Context.Condition.Where(c => c.ConditionId == id).Select(c => c.ConditionName).FirstOrDefaultAsync();
            return conditionName;
        }
        catch(Exception ex)
        {
            throw new CondtionDbCreationException($"Failed to get Condtion with id: {id}", ex);
        }

    }


}
