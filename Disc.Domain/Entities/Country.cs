using System.ComponentModel.DataAnnotations;

namespace Disc.Domain.Entities
{
    public class Country
    {
        [Key]
        public uint CountryId { get; set; }
        public string CountryName { get; set; }
        public IEnumerable<Release> Release { get; set; }
        public IEnumerable<Artist> Artists { get; set; }

    }
}