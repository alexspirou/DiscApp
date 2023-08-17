using AutoMapper;
using Disc.Application.DTOs.Country;
using Disc.Application.Requests.CountryOperations.Commands.CreateCountry;
using Disc.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Disc.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountryApi : ControllerBase
    {
        IMediator _mediator;
        IMapper _mapper;
        public CountryApi(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        [HttpPost, Route("CreateCountry/{countryDto}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateCountry([FromBody] CountryDto countryDto)
        {
            var countryMap = _mapper.Map<Country>(countryDto);
            var command = new CreateCountryCommand(countryMap);
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPost, Route("CreateCountries/{countriesDto}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateCountries([FromBody] CountryDto[] countriesDto)
        {
            var result = new List<Country>();
            foreach (var countryDto in countriesDto)
            {
                var countryMap = _mapper.Map<Country>(countryDto);
                var command = new CreateCountryCommand(countryMap);
                result.Add(await _mediator.Send(command));
            }

            return Ok(result);
        }
    }


}
