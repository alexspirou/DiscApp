using System.ComponentModel.DataAnnotations;

namespace Disc.Domain.Entities
{
    public class User
    {
        [Key]
        public uint UserId { get; set; }
        public string Username { get; set; } 
        public string Password { get; set; } 
        public string Email { get; set; } 
        public ICollection<Release>? Release { get; set; }
    }
}