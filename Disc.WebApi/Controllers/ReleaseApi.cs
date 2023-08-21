using AutoMapper;
using Disc.Application.DTOs.Release;
using Disc.Application.Requests.ReleaseOperations.Commands.CreateRelease;
using Disc.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Disc.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReleaseApi : ControllerBase
    {

        private readonly ILogger<ReleaseApi> _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ReleaseApi(ILogger<ReleaseApi> logger, IMediator mediator, IMapper mapper)
        {
            _logger = logger;
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost, Route("CreateReleaseDummy/{release}")]
        public async Task<IActionResult> CreateReleaseDummy([FromQuery] uint artistId, [FromQuery] uint countryId, [FromQuery] uint conditionId, Release release)
        {
            //var command = new CreateReleaseCommand(release);
            //var result = await _mediator.Send(command);

            return Ok();
        }

        [HttpPost, Route("CreateRelases/{newReleases}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateReleases(CreateReleasDto[] newReleases)
        {
            var result = new List<CreateReleasDto>();
            foreach (var newRelease in newReleases)
            {
                var release = new Release()
                {
                    Condition = new Condition { ConditionName = newRelease.Condition },
                    Title = newRelease.Title,
                    ReleaseYear = newRelease.ReleaseYear,
                    Country = new Country { CountryName = newRelease.Country }
                };
                var command = new CreateReleaseCommand(
                    release,
                    _mapper.Map<Artist>(newRelease.Artist),
                     newRelease.Style.Select(genre => new Genre { GenreName = genre }).ToArray(),
                    newRelease.Genre.Select(style => new Style { StyleName = style }).ToArray());
                var createNewRelease = await _mediator.Send(command);

                result.Add(_mapper.Map<CreateReleasDto>(createNewRelease));
            }

            return Ok(result);
        }
        [HttpPost, Route("CreateRelase/newReleases")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateRelease(CreateReleasDto newRelease)
        {

            var release = new Release()
            {
                Condition = new Condition { ConditionName = newRelease.Condition },
                Title = newRelease.Title,
                ReleaseYear = newRelease.ReleaseYear,
                Country = new Country { CountryName = newRelease.Country }
            };
            var command = new CreateReleaseCommand(
                release,
                _mapper.Map<Artist>(newRelease.Artist),
                 newRelease.Style.Select(genre => new Genre { GenreName = genre }).ToArray(),
                newRelease.Genre.Select(style => new Style { StyleName = style }).ToArray());
            var createNewRelease = await _mediator.Send(command);


            return Ok(_mapper.Map<CreateReleasDto>(createNewRelease));
        }
    }
}
