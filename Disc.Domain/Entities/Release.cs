using System.ComponentModel.DataAnnotations;

namespace Disc.Domain.Entities
{
    public class Release
    {
        [Key]
        public uint DiscogsId { get; set; }
        public string Title { get; set; } 
        public Artist Artist { get; set; }
        public Country Country { get; set; }
        public int ReleaseYear { get; set; }
        public IEnumerable<ReleaseGenre>? ReleaseGenre { get; set; }
        public IEnumerable<ReleaseStyle>? ReleaseStyle { get; set; }
        public Condition? Condition { get; set; }
    } 

}
