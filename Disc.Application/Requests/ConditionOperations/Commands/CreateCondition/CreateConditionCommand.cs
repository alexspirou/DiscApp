using Disc.Domain.Entities;
using MediatR;

namespace Disc.Application.Requests.ConditionOperations.Commands.CreateCondition
{
    public class CreateConditionCommand : IRequest<Condition>
    {
        public Condition Condtion { get; set; }
        public CreateConditionCommand(Condition condition)
        {
            Condtion = condition;
        }
    }
}
