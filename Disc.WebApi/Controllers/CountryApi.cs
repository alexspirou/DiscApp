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
        [HttpPost, Route("CreateCountry/{newCountry}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateCountry([FromBody] CountryDto newCountry)
        {
            var countryMap = _mapper.Map<Country>(newCountry);
            var command = new CreateCountryCommand(countryMap);
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPost, Route("CreateCountries/{newCountries}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateCountries([FromBody] CountryDto[] newCountries)
        {
            var result = new List<Country>();
            foreach (var countryDto in newCountries)
            {
                var countryMap = _mapper.Map<Country>(countryDto);
                var command = new CreateCountryCommand(countryMap);
                result.Add(await _mediator.Send(command));
            }

            return Ok(result);
        }
    }


}
