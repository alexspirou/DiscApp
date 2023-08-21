using Disc.Domain.Abstractions.Repositories;
using Disc.Domain.Entities;
using MediatR;

namespace Disc.Application.Requests.ConditionOperations.Commands.CreateCondition
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

            List<Condition> acceptableConditions = new List<Condition>
            {
                new Condition { ConditionName = "Mint (M)"},
                new Condition { ConditionName = "Near Mint (NM or M-)" },
                new Condition { ConditionName = "Very Good Plus (VG+)" },
                new Condition { ConditionName = "Very Good (VG)" },
                new Condition { ConditionName = "Good Plus (G+)", },
                new Condition { ConditionName = "Good (G)", },
                new Condition { ConditionName = "Fair (F)", },
                new Condition { ConditionName = "Poor (P)",  }
            };
            if (acceptableConditions.Any(x => x.ConditionName == request.Condtion.ConditionName))
            {
                var conditon = await _conditionRepository.GetConditionByNameAsync(request.Condtion.ConditionName);
                if (conditon is null)
                {
                    conditon = await _conditionRepository.CreateConditonAsync(request.Condtion);
                }

                return conditon;
            }
            else
            {
                throw new ArgumentException($"The {request.Condtion.ConditionName} condition is invalid. Please ensure that the condition meets the required criteria for this operation.");
            }


        }
    }
}
