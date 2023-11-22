using Disc.Domain.Abstractions.Repositories;
using Disc.Domain.Entities;
using Disc.Infrastructure.Database.Repositories;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Disc.Infrastructure.Database.Repositories
{
    public class StyleRepository : GenericRepository<Style>, IStyleRepository
    {
        public StyleRepository(DiscAppContext context) : base(context)
        {

        }
        public async Task<Style> CreateStyleAsync(Style newStyle)
        {
            Context.Style.Add(newStyle);
            await SaveAsync();

            return newStyle;    
        }

        public async Task<string?> GetStyleNameByIdAsync(uint id)
        {
            var result = await Context.Style
                .Where(s => s.StyleId == id)
                .Select(c => c.StyleName)
                .SingleOrDefaultAsync();

            return result;
        }

        public async Task<Style?> GetStyleByNameAsync(string name)
        {
            var result = await Context.Style
                .Where(s => s.StyleName == name)
                .FirstOrDefaultAsync();

            return result;
        }
    }

}
public class StyleRepositoryV2 : GenericRepository<Style>, IStyleRepository
{
    public Task<Style> CreateStyleAsync(Style newStyle)
    {
        throw new NotImplementedException();
    }

    public Task<Style> GetStyleByNameAsync(string name)
    {
        throw new NotImplementedException();
    }

    public Task<string> GetStyleNameByIdAsync(uint id)
    {
        throw new NotImplementedException();
    }
}