using System.ComponentModel.DataAnnotations;

namespace Disc.Domain.Entities
{
    public class Genre
    {
        [Key]
        public uint GenreId { get; set; }
        public string GenreName { get; set; } = null!;
        public IEnumerable<ReleaseGenre>? ReleaseGenre { get; set; }
    }
}
