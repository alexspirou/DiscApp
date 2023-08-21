using AutoMapper;
using Disc.Application.DTOs.Genre;
using Disc.Application.Requests.GenreOperations.Commands.CreateGenre;
using Disc.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Disc.WebApi.Controllers
{
    public class GenreApi : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public GenreApi(IMediator mediator, IMapper mapper )
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost, Route("CreateGenres/{newGenres}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateConditions([FromBody] GenreDto[] newGenres)
        {
            var result = new List<Genre>();
            foreach (var newGenre in newGenres)
            {
                var genreMap = _mapper.Map<Genre>(newGenre);
                var command = new CreateGenreCommand(genreMap);
                result.Add(await _mediator.Send(command));
            }
            return Ok(result);
        }

    }
}
