using System.ComponentModel.DataAnnotations;

namespace Disc.Domain.Entities
{
    public class Condition
    {
        [Key]
        public uint ConditionId { get; set; }
        public string? ConditionName { get; set; } 
        public string? Description { get; set; } 
        public IEnumerable<Release>? Release { get; set; }

        public override string ToString()
        {
            return $"ConditionId: {ConditionId}, ConditionName: {ConditionName}{ConditionName}";
        }
    }
}