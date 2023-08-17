using Disc.Application.Requests.ArtistOperations.Commands.CreateArtist;
using Disc.Application.Requests.ArtistsOperations.Queries.GetAllArtist;
using Disc.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dummy;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArtistApi : ControllerBase
    {

        private readonly ILogger<ArtistApi> _logger;
        private readonly IMediator _mediator;

        public ArtistApi(ILogger<ArtistApi> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet(Name = "GetArtist")]
        public async Task<IActionResult> GetArtist()
        {
            var query = new GetAllArtistsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost, Route("CreateArtist/Artist")]
        public async Task<IActionResult> CreateArtist(Artist newArtist)
        {
            var command = new CreateArtistCommand(newArtist);
            var result = await _mediator.Send(command);

            return Ok();
        }
    }
}