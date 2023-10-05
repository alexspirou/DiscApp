using Disc.Application.DTOs.Release;
using Disc.Application.Requests.ReleaseOperations.Commands.CreateRelease;
using Disc.Domain.Entities;

namespace Disc.Application.Extensions
{
    public static class ReleaseExtensions
    {
        #region ToReleaseDto

        public static CreateReleaseCommand ToCreateReleaseCommand(this Release entity)
        {
            return new CreateReleaseCommand
            {
                Condition = entity?.Condition.ToConditionDto(),
                Country = entity?.Country?.CountryName,
                ReleaseYear = entity?.ReleaseYear == null ? 0 : entity.ReleaseYear,
                ArtistName = entity.Artist.ArtistName
            };
        }  
       
        public static List<CreateReleaseCommand> ToCreateReleasDtoList(this IEnumerable<Release> entities)
        {
            return entities?.Select(entity => entity.ToCreateReleaseCommand()).ToList();
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

        #endregion

        #region ToRelease
        public static Release ToRelease(this ReleasDetailsWithArtistDto dto)
        {

            var release = new Release()
            {
                Condition = new Condition { ConditionName = dto.Condition.ConditionName },
                Title = dto.Title,
                ReleaseYear = dto.ReleaseYear,
                Country = new Country { CountryName = dto.Country }
            };
            return release;
        }

        public static List<Release> ToReleaseList(this IEnumerable<ReleasDetailsWithArtistDto> dtos)
        {
            return dtos?.Select(dto => dto.ToRelease()).ToList();
        }

        #endregion
    }
}
