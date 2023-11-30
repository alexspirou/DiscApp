using Disc.Application.DTOs.Condition;

namespace Disc.Application.DTOs.Release
{
    public class ReleaseDetailsDto
    {
        public string ArtistName { get; set; }  
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public string Country { get; set; }
        public ConditionDto Condition { get; set; }
        public string[] Style { get; set; }
        public string[] Genre { get; set; }
    }
}
