using Disc.Domain.Abstractions.Repositories;
using Disc.Domain.Entities;
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
        public async Task<Style> CreateStyleAsync(Style newStyle)
        {
            Context.Style.Add(newStyle);
            await SaveAsync();
            return newStyle;    
        }


        public async Task<string> GetStyleNameByIdAsync(uint id)
        {
            try
            {
                var result = await Context.Style.Where(s => s.StyleId == id).Select(c => c.StyleName).FirstOrDefaultAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Style exceptions", ex);
            }

        }

        public async Task<Style> GetStyleByNameAsync(string name)
        {
            try
            {
                var result = await Context.Style.Where(s => s.StyleName == name).FirstOrDefaultAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Style exceptions", ex);
            }

        }
    }

}
