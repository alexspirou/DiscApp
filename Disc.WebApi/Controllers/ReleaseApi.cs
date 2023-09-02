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

        [HttpPost, Route("CreateRelases/{newReleases}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateReleases(ReleasDetailsWithArtistDto[] newReleases)
        {
            var result = new List<ReleasDetailsWithArtistDto>();
            foreach (var newRelease in newReleases)
            {
                if (newRelease is null)
                {
                    continue;
                }
                var release = new Release()
                {
                    Condition = new Condition { ConditionName = newRelease.Condition.ConditionName },
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

                result.Add(_mapper.Map<ReleasDetailsWithArtistDto>(createNewRelease));
            }


            return Ok(result);
        }
        [HttpPost, Route("CreateRelase/newReleases")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateRelease(ReleasDetailsWithArtistDto newRelease)
        {
            var release = new Release()
            {
                Condition = new Condition { ConditionName = newRelease.Condition.ConditionName },
                Title = newRelease.Title ,
                ReleaseYear = newRelease.ReleaseYear,
                Country = new Country { CountryName = newRelease.Country }
            };
            var command = new CreateReleaseCommand(
                release,
                _mapper.Map<Artist>(newRelease.Artist),
                 newRelease.Style.Select(genre => new Genre { GenreName = genre }).ToArray(),
                newRelease.Genre.Select(style => new Style { StyleName = style }).ToArray());
            var createNewRelease = await _mediator.Send(command);

            return Ok(_mapper.Map<ReleasDetailsWithArtistDto>(createNewRelease));
        }
    }
}
