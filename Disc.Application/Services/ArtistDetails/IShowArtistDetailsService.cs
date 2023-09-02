using Disc.Application.DTOs.Artist;

namespace Disc.Application.Services.ArtistDetails
{
    public interface IShowArtistDetailsService
    {
        Task<ArtistDetailsDto> GetArtistDetailsAsync(uint id);
    }
}
