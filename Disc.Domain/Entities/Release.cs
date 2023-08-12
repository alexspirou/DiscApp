using System.ComponentModel.DataAnnotations;

namespace Disc.Domain.Entities
{

    public class Release
    {
        [Key]
        public uint DiscogsId { get; set; }
        public string Title { get; set; } = null!;
        public Artist Artist { get; set; } = null!;
        public Country Country { get; set; } = null!;
        public int ReleaseYear { get; set; }
        public IEnumerable<ReleaseGenre> ReleaseGenre { get; set; } = null!;
        public IEnumerable<ReleaseStyle> ReleaseStyle { get; set; } = null!;
        public Condition? Condition { get; set; }
       
    }
}
