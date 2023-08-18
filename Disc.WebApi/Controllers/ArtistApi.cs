using AutoMapper;
using Disc.Application.DTOs.Artist;
using Disc.Application.Requests.ArtistOperations.Commands.CreateArtist;
using Disc.Application.Requests.ArtistsOperations.Queries.GetAllArtist;
using Disc.Domain.Entities;
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
        private readonly IMapper _mapper;

        public ArtistApi(ILogger<ArtistApi> logger, IMediator mediator, IMapper mapper)
        {
            _logger = logger;
            _mediator = mediator;
            _mapper = mapper;
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
        public async Task<IActionResult> CreateArtist(CreateArtistDto newArtist)
        {
            var artistMap = _mapper.Map<Artist>(newArtist);
            var command = new CreateArtistCommand(artistMap);
            var result = await _mediator.Send(command);

            return Ok();
        } 
        
        [HttpPost, Route("CreateArtist/newArtists")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateArtist(CreateArtistDto[] newArtists)
        {
            var result = new List<Artist>();
            foreach (var newArtist in newArtists)
            {
                var command = new CreateArtistCommand(_mapper.Map<Artist>(newArtist));
                var createdArtist = await _mediator.Send(command);

                result.Add(createdArtist);
            }
            return Ok(JsonConvert.SerializeObject(result));
        }
    }
}