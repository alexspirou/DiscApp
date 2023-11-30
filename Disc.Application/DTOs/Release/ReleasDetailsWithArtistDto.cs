using Disc.Application.DTOs.Artist;

namespace Disc.Application.DTOs.Release
{
    public class ReleasDetailsWithArtistDto : ReleaseDetailsDto
    {
        public ArtistDTO Artist { get; set; }
    }
}
