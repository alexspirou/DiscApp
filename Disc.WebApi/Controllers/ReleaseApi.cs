using AutoMapper;
using Disc.Application.DTOs.Release;
using Disc.Application.Extensions;
using Disc.Application.Requests.ArtistOperations.ArtistDetails;
using Disc.Application.Requests.ReleaseOperations.Commands.CreateRelease;
using Disc.Application.Requests.ReleaseOperations.Queries;
using Disc.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
        public async Task<IActionResult> CreateReleases(CreateReleaseCommand[] newReleases)
        {
            var result = new List<CreateReleaseCommand>();
            foreach (var newRelease in newReleases)
            {
                var createNewRelease = await _mediator.Send(newRelease);
                result.Add(createNewRelease.ToCreateReleaseCommand());
            }
            return Ok(result);
        }
        [HttpPost, Route("CreateRelase/newReleases")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateRelease(CreateReleaseCommand newRelease)
        {
            var createNewRelease = await _mediator.Send(newRelease);
            return Ok(createNewRelease.ToCreateReleaseCommand());
        }


        [HttpGet, Route("GetReleaseDetails/{from}/{to}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetReleaseDetails(int from, int to)
        {
            var releaseDetails = await _mediator.Send(new GetReleasesQuery(from, to));

            return Ok(JsonConvert.SerializeObject(releaseDetails));
        }
    }
}
