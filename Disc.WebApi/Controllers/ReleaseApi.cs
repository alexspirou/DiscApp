using Application.ArtistOperations.Commands.CreateArtist;
using Disc.Application.ReleaseOperations.Commands.CreateRelease;
using Disc.Domain.Entities;
using Disc.Domain.Repositories;
using Disc.WebApi.Dummy;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers;
using WebApi.Dummy;

namespace Disc.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReleaseApi : ControllerBase
    {

        private readonly ILogger<ReleaseApi> _logger;
        private readonly IMediator _mediator;
        private readonly IArtistRepository _artistRepository;

        public ReleaseApi(ILogger<ReleaseApi> logger, IMediator mediator, IArtistRepository artistRepository)
        {
            _logger = logger;
            _mediator = mediator;
            _artistRepository = artistRepository;
        }

        [HttpPost, Route("CreateReleaseDummy/{release}")]
        public async Task<IActionResult> CreateReleaseDummy([FromQuery] uint artistId, [FromQuery] uint countryId, [FromQuery] uint conditionId,   Release release)
        {
            //var command = new CreateReleaseCommand(release);
            //var result = await _mediator.Send(command);

            return Ok();
        }
    }
}
