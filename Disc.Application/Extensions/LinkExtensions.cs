using Disc.Application.DTOs.Link;
using Disc.Domain.Entities;

namespace Disc.Application.Extensions
{
    public static class LinkExtensions
    {
        public static LinkDto ToLinkDto(this Link entity)
        {
            return new LinkDto
            {
                SiteUrl = entity.SiteUrl
            };
        }

        public static List<LinkDto> ToLinkDtoList(this IEnumerable<Link> entities)
        {
            return entities?.Select(entity => entity.ToLinkDto()).ToList();
        }
    }
}
