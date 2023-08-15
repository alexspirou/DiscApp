using Disc.Application.CountryOperations.Commands.CreateCountry;
using Disc.Domain.Entities;
using Disc.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disc.Application.Modules.ConditionOperations.Commands.CreateCondition
{
    public class CreateConditionCommandHandler : IRequestHandler<CreateConditionCommand, Condition>
    {
        IConditionRepository _conditionRepository;

        public CreateConditionCommandHandler(IConditionRepository conditionRepository)
        {
            _conditionRepository = conditionRepository;
        }

        public async Task<Condition> Handle(CreateConditionCommand request, CancellationToken cancellationToken)
        {
            var conditon = await _conditionRepository.GetConditionByNameAsync(request.Condtion.ConditionName);
            if(conditon is null)
            {
                conditon = await _conditionRepository.CreateConditonAsync(request.Condtion);
            }

            return conditon;
        }
    }
}
