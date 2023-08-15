using AutoMapper;
using Disc.Application.CountryOperations.Commands.CreateCountry;
using Disc.Application.Modules.ConditionOperations;
using Disc.Application.Modules.ConditionOperations.Commands.CreateCondition;
using Disc.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Disc.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConditionApi : ControllerBase
    {
        IMediator _mediator;
        IMapper _mapper;

        public ConditionApi(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;

        }
        [HttpPost, Route("CreateCondition/{conditionDto}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateCondition([FromBody] ConditionDto conditionDto)
        {
            var conditionMap = _mapper.Map<Condition>(conditionDto);
            var command = new CreateConditionCommand(conditionMap);
            var result = await _mediator.Send(command);

            return Ok(result);
        }        
        
        [HttpPost, Route("CreateConditions/{conditionsDto}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateConditions([FromBody] ConditionDto [] conditionDtos)
        {
            var result = new List<Condition>();
            foreach(var conditionDto in conditionDtos)
            {
                var conditionMap = _mapper.Map<Condition>(conditionDto);
                var command = new CreateConditionCommand(conditionMap);
                result.Add(await _mediator.Send(command));
            }
            return Ok(result);
        }
    }
}
