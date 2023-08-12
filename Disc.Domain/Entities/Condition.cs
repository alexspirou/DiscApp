using System.ComponentModel.DataAnnotations;

namespace Disc.Domain.Entities
{
    public class Condition
    {
        [Key]
        public uint ConditionId { get; set; }
        public string ConditionName { get; set; } = null!;
        public IEnumerable<Release>? Release { get; set; }
    }
}