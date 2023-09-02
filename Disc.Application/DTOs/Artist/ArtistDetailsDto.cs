using Disc.Application.DTOs.Link;
using Disc.Application.DTOs.Release;

namespace Disc.Application.DTOs.Artist
{
    public class ArtistDetailsDto
    {
        public string ArtistName { get; set; } = null!;
        public string? RealName { get; set; }
        public string Country { get; set; } = null!;
        public IEnumerable<ReleaseDetailsDto?>? Releases { get; set; }
        public IEnumerable<LinkDto?>?  Links { get; set; }

        // TODO : Add image, videos 
    }
}
