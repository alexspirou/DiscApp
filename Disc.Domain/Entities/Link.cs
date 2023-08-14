using System.ComponentModel.DataAnnotations;

namespace Disc.Domain.Entities
{
    public class Link
    {
        [Key]
        public uint LinkId { get; set; }
        public string SiteUrl { get; set; }
        public IEnumerable<ArtistLink> Artist { get; set; }

    }
}
