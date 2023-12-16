using AutoMapper;
using Disc.Application.Extensions;
using Disc.Application.Requests.ArtistOperations.ArtistDetails;
using Disc.Application.Requests.ArtistOperations.CreateArtist;
using Disc.Application.Requests.ArtistOperations.GetAllArtist;
using Disc.Application.Requests.ArtistOperations.SearchArtist;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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

        [HttpPost, Route("CreateArtist/newArtist")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateArtist(CreateArtistCommand createNewArtist)
        {
            var result = await _mediator.Send(createNewArtist);
            return Ok(result.ToCreateArtistCommand());
        }

        [HttpPost, Route("CreateArtist/newArtists")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateArtist(CreateArtistCommand[] createNewArtists)
        {
            var result = new List<CreateArtistCommand>();
            foreach (var createNewArtist in createNewArtists)
            {
                var createdArtist = await _mediator.Send(createNewArtist);
                result.Add(createdArtist.ToCreateArtistCommand());
            }
            return Ok(JsonConvert.SerializeObject(result));
        }


        [HttpGet, Route("SearchArtistByName/{name}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> SearchArtistByName(string name)
        {
            var artistDetails = await _mediator.Send(new SearchArtistQuery(name));
            return Ok(JsonConvert.SerializeObject(artistDetails, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            }));
        }

        [HttpGet, Route("GetArtistDetails/{name}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetArtistDetails(string name)
        {
            var artistDetails = await _mediator.Send(new GetArtistDetailsQuery(name));
            return Ok(JsonConvert.SerializeObject(artistDetails));
        }        
        
        [HttpGet, Route("GetArtists/{size}/{page}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetArtists(int size, int page)
        {
            var artistDetails = await _mediator.Send(new GetAllArtistsQuery(size, page));
            return Ok(JsonConvert.SerializeObject(artistDetails));
        }
    }
}