using Disc.Application.DTOs.Link;
using Disc.Application.DTOs.Style;
using Disc.Domain.Entities;

namespace Disc.Application.Extensions
{
    public static class StyleExtensions
    {
        #region ToStyleDto

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

        #endregion

        #region ToStyle
        public static Style ToStyle(this string style)
        {
            return new Style()
            {
                StyleName = style
            };
        }

        public static List<Style> ToStyleList(this IEnumerable<string> styles)
        {
            return styles?.Select(s => s.ToStyle()).ToList();
        }       
        
        public static Style[] ToStyleArray(this IEnumerable<string> styles)
        {
            return styles?.Select(s => s.ToStyle()).ToArray();
        }


#endregion
    }
}
