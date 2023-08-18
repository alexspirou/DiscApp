using AutoMapper;
using Disc.Application.DTOs.Artist;
using Disc.Application.DTOs.Condition;
using Disc.Application.DTOs.Country;
using Disc.Application.DTOs.Genre;
using Disc.Application.DTOs.Release;
using Disc.Application.DTOs.Style;
using Disc.Domain.Entities;

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
            CreateMap<Genre, CreateGenreDto>();
            CreateMap<CreateGenreDto, Genre>();
            // Style
            CreateMap<Style, CreateStyleDto>();
            CreateMap<CreateStyleDto, Style>();
            // Artist
            CreateMap<Artist, CreateArtistDto>().ForMember(artistDto =>
            artistDto.Country, m => m.MapFrom(a => a.Country.CountryName));

            CreateMap<CreateArtistDto, Artist>().ForMember(artist =>
            artist.Country, m => m.MapFrom(i => new Country { CountryName = i.Country })); 
            // Release
            CreateMap<Release, CreateReleasDto>().ForMember(releasDto =>
            releasDto.Country, m => m.MapFrom(a => a.Country.CountryName));

            CreateMap<CreateReleasDto, Release>()
            .ForMember(release => release.Country, m => m.MapFrom(i => new Country
            {
                    CountryName = i.Country 
            }))  
            .ForMember(release => release.Condition, m => m.MapFrom(i => new Condition
            {
                    ConditionName = i.Condition
            }))
            .ForMember(release=> release.Artist, m => m.MapFrom(i => new Artist()
            {
                ArtistName = i.Artist.ArtistName,
                Country = new Country { CountryName = i.Artist.Country },
                RealName = i.Artist.RealName,   
            }));
        }

    }
}
