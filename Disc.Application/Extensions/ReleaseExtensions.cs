using Disc.Application.DTOs.Release;
using Disc.Domain.Entities;

namespace Disc.Application.Extensions
{
    public static class ReleaseExtensions
    {
        public static ReleasDetailsWithArtistDto ToCreateReleasDto(this Release entity)
        {
            return new ReleasDetailsWithArtistDto
            {
                Condition = entity?.Condition.ToConditionDto(),
                Country = entity?.Country?.CountryName,
                ReleaseYear = entity?.ReleaseYear == null ? 0 : entity.ReleaseYear,
            };
        }
        public static List<ReleasDetailsWithArtistDto> ToCreateReleasDtoList(this IEnumerable<Release> entities)
        {
            return entities?.Select(entity => entity.ToCreateReleasDto()).ToList();
        }
        public static ReleaseDetailsDto ToReleaseDetailsDto(this Release release)
        {
            return new ReleaseDetailsDto
            {
                Condition = release.Condition.ToConditionDto(),
                Country = release.Country?.CountryName,
                ReleaseYear = release.ReleaseYear, 
                Title = release.Title,
                Style = release.ReleaseStyle.Select(x => x.Style.StyleName).ToArray(),
                Genre = release.ReleaseGenre.Select(x => x.Genre.GenreName).ToArray()
            };
        }

        public static List<ReleaseDetailsDto> ToToReleaseDetailsDtoList(this IEnumerable<Release> releases)
        {
            return releases?.Select(release => release.ToReleaseDetailsDto()).ToList();
        }     

    }
}
