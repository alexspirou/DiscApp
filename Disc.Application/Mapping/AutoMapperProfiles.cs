using AutoMapper;
using Disc.Application.CountryOperations;
using Disc.Domain.Entities;

namespace Disc.Application.Mapping
{
    public class AutoMapperProfiles : Profile
    {

        public AutoMapperProfiles()
        {
            CreateMap<Country, CountryDto>();
            CreateMap<CountryDto, Country>();
        }

    }
}
