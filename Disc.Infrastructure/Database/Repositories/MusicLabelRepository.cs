using Disc.Domain.Abstractions.Repositories;
using Disc.Domain.Entities;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace Disc.Infrastructure.Database.Repositories;

public class MusicLabelRepository : GenericRepository<MusicLabel>, ILabelRepository
{

    public MusicLabelRepository(DiscAppContext context) : base(context)
    {

    }

    public async Task<MusicLabel> CreateMusicLabelAsync(MusicLabel newLabel)
    {
        Context.Label.Add(newLabel);
        await SaveAsync();

        return newLabel;
    }
    public async Task<Country?> GetCountryByIdAsync(uint id)
    {
        var result = await Context.Label
            .Where(label => label.LabelId == id)
            .Select(label => label.Country)
            .SingleOrDefaultAsync();

        return result;
    }

    public async Task<IEnumerable<Link>> GetLinksByIdAsync(uint id)
    {
        var result = await Context.Label
            .Where(label => label.LabelId == id)
            .SelectMany(label => label.Links)
            .ToListAsync();

        return result;
    }

    public async Task<string?> GetMusicLabelNameByIdAsync(uint id)
    {
        var result = await Context.Label
            .Where(label => label.LabelId == id)
            .Select(label => label.LabelName)
            .SingleOrDefaultAsync();

        return result;
    }

    public async Task<MusicLabel?> GetMusicLabelByNameAsync(string name)
    {
        var result = await Context.Label
            .Where(label => label.LabelName == name)
            .SingleOrDefaultAsync();

        return result;
    }

}
