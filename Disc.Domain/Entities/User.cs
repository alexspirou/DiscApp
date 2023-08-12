using System.ComponentModel.DataAnnotations;

namespace Disc.Domain.Entities
{
    public class User
    {
        [Key]
        public uint UserId { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
        public ICollection<Release>? Release { get; set; }
    }
}