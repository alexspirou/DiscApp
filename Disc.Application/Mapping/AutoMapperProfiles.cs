using AutoMapper;
using Disc.Application.DTOs.Artist;
using Disc.Application.DTOs.Condition;
using Disc.Application.DTOs.Country;
using Disc.Application.DTOs.Genre;
using Disc.Application.DTOs.Release;
using Disc.Application.DTOs.Style;
using Disc.Domain.Entities;
using System.Data;

namespace Disc.Application.Mapping
{
    public class AutoMapperProfiles : Profile
    {

        public AutoMapperProfiles()
        {
            // Country
            CreateMap<Country, CountryDto>();
            CreateMap<CountryDto, Country>();
            // Condition
            CreateMap<Condition, ConditionDto>();
            CreateMap<ConditionDto, Condition>();
            // Genre
            CreateMap<Genre, GenreDto>();
            CreateMap<GenreDto, Genre>();
            // Style
            CreateMap<Style, StyleDto>();
            CreateMap<StyleDto, Style>();
            // Artist
            CreateMap<Artist, CreateArtistDto>().ForMember(artistDto =>
            artistDto.Country, m => m.MapFrom(a => a.Country.CountryName));

            CreateMap<CreateArtistDto, Artist>().ForMember(artist =>
            artist.Country, m => m.MapFrom(i => new Country { CountryName = i.Country }));
            // Release
            CreateMap<Release, ReleaseDetailsDto>().ForMember(releasDto =>
            releasDto.Country, m => m.MapFrom(a => a.Country.CountryName));

            CreateMap<ReleaseDetailsDto, Release>()
            .ForMember(release => release.Country, m => m.MapFrom(i => new Country
            {
                CountryName = i.Country
            }))
            .ForMember(release => release.Condition, m => m.MapFrom(i => new Condition
            {
                ConditionName = i.Condition.ConditionName
            }));

            CreateMap<Release, ReleasDetailsWithArtistDto>()
           .ForMember(release => release.Genre, m => m.MapFrom(i => i.ReleaseGenre.Select(x => x.Genre.GenreName).ToList()))
           .ForMember(release => release.Style, m => m.MapFrom(i => i.ReleaseStyle.Select(x => x.Style.StyleName).ToList()))
           .ForMember(release => release.Country, m => m.MapFrom(i => i.Country.CountryName))
           .ForMember(release => release.Condition, m => m.MapFrom(i => i.Condition.ConditionName))
           .ForMember(release => release.Artist, m => m.MapFrom(i => new CreateArtistDto(i.Artist.ArtistName, i.Artist.RealName, i.Artist.Country.CountryName)));

        }

    }
}
