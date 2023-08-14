using System.ComponentModel.DataAnnotations;

namespace Disc.Domain.Entities
{
    public class MusicLabel
    {
        [Key]
        public uint LabelId { get; set; }
        public string LabelName { get; set; }
        public IEnumerable<Link>? Links { get; set; }
        public IEnumerable<ArtistMusicLabel>? Artist { get; set; }
        public Country Country { get; set; }

    }
}
