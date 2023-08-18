using AutoMapper;
using Disc.Application.DTOs.Condition;
using Disc.Application.Requests.ConditionOperations.Commands.CreateCondition;
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
        [HttpPost, Route("CreateCondition/{newCondition}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateCondition([FromBody] ConditionDto newCondition)
        {
            var conditionMap = _mapper.Map<Condition>(newCondition);
            var command = new CreateConditionCommand(conditionMap);
            var result = await _mediator.Send(command);

            return Ok(result);
        }        
        
        [HttpPost, Route("CreateConditions/{newCondition}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateConditions([FromBody] ConditionDto [] newConditions)
        {
            var result = new List<Condition>();
            foreach(var newCondition in newConditions)
            {
                var conditionMap = _mapper.Map<Condition>(newCondition);
                var command = new CreateConditionCommand(conditionMap);
                result.Add(await _mediator.Send(command));
            }
            return Ok(result);
        }
    }
}
