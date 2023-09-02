using Disc.Application.DTOs.Link;
using Disc.Application.DTOs.Style;
using Disc.Domain.Entities;

namespace Disc.Application.Extensions
{
    public static class StyleExtensions
    {
        public static StyleDto ToStyleDto(this Style style)
        {
            return new StyleDto
            {
                StyleName = style.StyleName
            };
        }

        public static List<StyleDto> ToToStyleDtoList(this IEnumerable<Style> styles)
        {
            return styles?.Select(s => s.ToStyleDto()).ToList();
        }
    }
}
