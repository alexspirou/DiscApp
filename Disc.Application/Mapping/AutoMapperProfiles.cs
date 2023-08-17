using AutoMapper;
using Disc.Application.DTOs.Condition;
using Disc.Application.DTOs.Country;
using Disc.Application.DTOs.Genre;
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

        }

    }
}
