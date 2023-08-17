using Disc.Domain.Entities;
using MediatR;

namespace Disc.Application.Requests.StyleOperations.Commands.CreateStyle
{
    public class CreateStyleCommand : IRequest<Style>
    {

        public Style Style { get; set; }

        public CreateStyleCommand(Style style)
        {
            Style = style;
         }
    }
}
