using Disc.Application.DTOs.Artist;
using Disc.Application.Requests.ArtistOperations.CreateArtist;

namespace Disc.Application.ServicesAbstractions
{
    public interface IShowArtistDetailsService
    {
        Task<CreateArtistCommand> GetArtistDetailsAsync(string name);
    }
}
