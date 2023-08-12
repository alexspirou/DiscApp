using Disc.Domain.Entities;
using System.Collections;

namespace Disc.Domain.Repositories
{
    public interface IArtistRepository : IGenericRepository<Artist>
    {
        Artist CreateArtist(Artist newArtist);
        Task<Artist> CreateArtistAsync(Artist newArtist);
        List<Artist> CreateArtists(List<Artist> newArtist);
        Task<List<Artist>> CreateArtistsAsync(List<Artist> newArtist);
        string GetNameByArtistID(uint id);
        string GetRealNameByArtistId(uint id);
        IEnumerable GetLinksByArtistID(uint id);
        IEnumerable GetMusicLabelByArtistID(uint id);
        IEnumerable GetReleaseByArtistID(uint id);
        Task<Artist> GetArtistByNameAsync(string name);

    }
}

