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

        [HttpPost, Route("CreateGenres/{genreDtos}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateConditions([FromBody] CreateGenreDto[] genreDtos)
        {
            var result = new List<Genre>();
            foreach (var conditionDto in genreDtos)
            {
                var genreMap = _mapper.Map<Genre>(conditionDto);
                var command = new CreateGenreCommand(genreMap);
                result.Add(await _mediator.Send(command));
            }
            return Ok(result);
        }

    }
}
