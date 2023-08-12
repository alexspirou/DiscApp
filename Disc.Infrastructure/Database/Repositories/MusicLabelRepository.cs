using Disc.Domain.Entities;
using Domain.Repositories;
using Infrastructure.Database;

namespace Disc.Infrastructure.Database.Repositories;

public class MusicLabelRepository : GenericRepository<MusicLabel>, ILabelRepository
{

    public MusicLabelRepository(DiscAppContext context) : base(context)
    {

    }

    public string GetCountryById(uint id)
    {
        try
        {
            return Context.Label.Where(label => label.LabelId == id).Select(label => label.Country).ToString();
        }
        catch (Exception ex)
        {
            throw new Exception("MusicLabel exception", ex);
        }
    }

    public IEnumerable<Link> GetLinksById(uint id)
    {
        try
        {
            return (IEnumerable<Link>)Context.Label.Where(label => label.LabelId == id).Select(label => label.Links);
        }
        catch (Exception ex)
        {
            throw new Exception("MusicLabel exception", ex);
        }
    }

    public string MusicLabelNameById(uint id)
    {
        try
        {
            return Context.Label.Where(label => label.LabelId == id).Select(label => label.LabelName).ToString();
        }
        catch (Exception ex)
        {
            throw new Exception("MusicLabel exception", ex);
        }
    }

    public MusicLabel GetMusicLabelByName(string name)
    {
        try
        {
            return Context.Label.Where(label => label.LabelName == name).SingleOrDefault();
        }
        catch (Exception ex)
        {
            throw new Exception("MusicLabel exception", ex);
        }
    }

    public MusicLabel CreateMusicLabel(string labelName, Country country, IEnumerable<Link> links = null, IEnumerable<ArtistMusicLabel> artist = null)
    {
        var musicLabel = GetMusicLabelByName(labelName);

        if (musicLabel == null)
        {
            musicLabel = new MusicLabel { LabelName = labelName, Country = country.CountryName, Artist = artist, Links = links };
            Insert(musicLabel);
        }

        return musicLabel;
    }
}
