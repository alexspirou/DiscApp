namespace Disc.Domain.Entities
{
    public class ReleaseGenre
    {
        public uint ReleaseId { get; set; }
        public uint GenreId { get; set; }
        public Release Release { get; set; }
        public Genre Genre { get; set; }
    }
}
