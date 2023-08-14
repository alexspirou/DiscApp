namespace Disc.Domain.Entities
{
    public class ReleaseStyle
    {
        public uint ReleaseId { get; set; }
        public uint StyleId { get; set; } 
        public Release Release { get; set; }
        public Style Style { get; set; }
    }
}
