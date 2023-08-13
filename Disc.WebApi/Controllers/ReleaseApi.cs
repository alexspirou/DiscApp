using Application.Artists.Commands.CreateArtist;
using Disc.Application.Releases.Commands.CreateRelease;
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

        [HttpPost, Route("CreateReleaseDummy")]
        public async Task<IActionResult> CreateReleaseDummy()
        {
            var releaseList = new List<Release>();

            var release = new Release()
            {
                Artist = await _artistRepository.GetArtistByNameAsync("AlexSpyrou"),
                Country = new Country() { CountryName = "USA" },
                ReleaseGenre = new List<ReleaseGenre>()
                {
                    new ReleaseGenre(){
                        Genre = new Genre(){GenreName = "Electronic"},
                    }
                },
                ReleaseStyle = new List<ReleaseStyle>()
                {
                    new ReleaseStyle(){
                        Style = new Style(){StyleName = "Techno"},
                    }
                },
                DiscogsId = 40494,
                Title = "O.M.X – Turn On",
                ReleaseYear = 1994

            };
            releaseList.Add(release);
            var command = new CreateReleaseCommand(releaseList);
            var result = await _mediator.Send(command);

            return Ok();
        }
    }
}
