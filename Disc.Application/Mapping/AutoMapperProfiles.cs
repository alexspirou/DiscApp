using AutoMapper;
using Disc.Application.CountryOperations;
using Disc.Application.Modules.ConditionOperations;
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
        }

    }
}
