using Disc.Domain.Entities;
using System.Collections;

namespace Disc.Domain.Abstractions.Repositories
{
    public interface IStyleRepository : IGenericRepository<Style>
    {
        Task<Style> CreateStyleAsync(Style newStyle);
        Task<string?> GetStyleNameByIdAsync(uint id);
        Task<Style?> GetStyleByNameAsync(string name);
    }
}
