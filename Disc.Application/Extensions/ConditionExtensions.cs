using Disc.Application.DTOs.Condition;
using Disc.Application.DTOs.Link;
using Disc.Domain.Entities;

namespace Disc.Application.Extensions
{
    public static class ConditionExtensions
    {
        public static ConditionDto ToConditionDto(this Condition condition)
        {
            return new ConditionDto(condition?.ConditionName, condition?.Description);
        }

        public static List<ConditionDto> ToConditionDtoList(this IEnumerable<Condition> conditions)
        {
            return conditions?.Select(c => c.ToConditionDto()).ToList();
        }

    }
}
