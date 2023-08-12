using System.ComponentModel.DataAnnotations;

namespace Disc.Domain.Entities
{
    public class Style
    {
        [Key]
        public uint StyleId { get; set; }
        public string StyleName { get; set; } = null!;
        public IEnumerable<ReleaseStyle> ReleaseStyle { get; set; }

    }
}