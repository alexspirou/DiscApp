using System.ComponentModel.DataAnnotations;

namespace Disc.Domain.Entities
{
    public class Artist 
    {
        [Key]
        public uint ArtistId { get; set; }
        public string ArtistName { get; set; } 
        public string RealName { get; set; }
        public Country Country { get; set; } 
        public IEnumerable<ArtistLink> Links { get; set; }
        public IEnumerable<ArtistMusicLabel> MusicLabel { get; set; }
        public IEnumerable<Release> Release { get; set; }

        public override string ToString()
        {
            string realNameString = !string.IsNullOrEmpty(RealName) ? RealName : "N/A";
            return $"ArtistId: {ArtistId}, ArtistName: {ArtistName}, RealName: {realNameString}, Country: {Country.CountryName}";
        }
    }




}