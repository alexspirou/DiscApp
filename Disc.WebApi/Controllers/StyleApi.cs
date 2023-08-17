﻿using AutoMapper;
using Disc.Application.DTOs.Style;
using Disc.Application.Requests.StyleOperations.Commands.CreateStyle;
using Disc.Domain.Entities;
using Disc.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Disc.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StyleApi : ControllerBase
    {
        private readonly ILogger<ReleaseApi> _logger;
        private readonly IMediator _mediator;
        private readonly IStyleRepository _styleRepository;
        private readonly IMapper _mapper;

        public StyleApi(ILogger<ReleaseApi> logger, IMediator mediator, IMapper mapper,IStyleRepository styleRepository)
        {
            _logger = logger;
            _mediator = mediator;
            _styleRepository = styleRepository;
            _mapper = mapper;   
        }

        [HttpPost, Route("CreateStyles/{styleDtos}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateStyles([FromBody] CreateStyleDto[] styleDtos)
        {
            var result = new List<Style>();
            foreach (var styleDto in styleDtos)
            {
                var genreMap = _mapper.Map<Style>(styleDto);
                var command = new CreateStyleCommand(genreMap);
                result.Add(await _mediator.Send(command));
            }
            return Ok(result);
        }

    }
}
