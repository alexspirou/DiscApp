using Disc.Application.DTOs.Artist;
using Disc.Domain.Entities;

namespace Disc.Application.Extensions
{
    public static class ArtistExtensions
    {
        public static ArtistDetailsDto ToArtistDetailsDto(this Artist artist)
        {
            return new ArtistDetailsDto
            {
                ArtistName = artist.ArtistName == null ? "N/A" : artist.ArtistName,
                RealName = artist.RealName == null ? "N/A" : artist.RealName,
                Country = artist.Country == null ? "N/A" : artist.Country.CountryName,
                Links = artist?.Links?.Select(x => x.Link).ToLinkDtoList(),
                Releases = artist?.Release.Select(x => x.ToReleaseDetailsDto()).ToList(),
            };
        }
    }
}
