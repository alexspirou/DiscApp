using Disc.Domain.Entities;
using System.Collections;

namespace Disc.Domain.Abstractions.Repositories
{
    public interface IArtistRepository : IGenericRepository<Artist>
    {
        Artist CreateArtist(Artist newArtist);
        Task<Artist> CreateArtistAsync(Artist newArtist);
        string GetNameByArtistID(uint id);
        string GetRealNameByArtistId(uint id);
        IEnumerable GetLinksByArtistID(uint id);
        IEnumerable GetMusicLabelByArtistID(uint id);
        IEnumerable GetReleaseByArtistID(uint id);
        Task<Artist> GetArtistByNameAsync(string name);
        List<Artist> GetAllArtists();

    }
}

