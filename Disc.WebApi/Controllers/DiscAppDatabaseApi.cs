using Application.Artists.Commands.CreateArtist;
using Disc.Domain.Entities;
using Infrastructure.Database;
using Disc.Infrastructure.Database.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dummy;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DiscAppDatabaseApi : ControllerBase
    {

        private readonly ILogger<DiscAppDatabaseApi> _logger;
        private readonly IMediator _mediator;

        public DiscAppDatabaseApi(ILogger<DiscAppDatabaseApi> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet(Name = "GetArtist")]
        public IEnumerable<Artist> GetArtist()
        {
            return new List<Artist>();
        }

        [HttpPost(Name = "CreateArtist")]
        public async Task<IActionResult> CreateArtistDummy()
        {
            var artistReader = new ArtistReader();
            var artists = artistReader.ReadArtists(@"C:\Users\alexs\Desktop\djs.txt");

            var command = new CreateArtistCommand(artists);
            var result = await _mediator.Send(command);
            return Ok();
        }
    }
}