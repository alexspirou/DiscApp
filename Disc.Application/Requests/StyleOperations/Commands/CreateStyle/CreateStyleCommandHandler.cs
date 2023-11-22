using Disc.Domain.Abstractions.Repositories;
using Disc.Domain.Entities;
using MediatR;

namespace Disc.Application.Requests.StyleOperations.Commands.CreateStyle
{
    public class CreateStyleCommandHandler : IRequestHandler<CreateStyleCommand, Style>
    {
        private readonly Disc.Infrastructure.Database.Repositories.StyleRepository _styleRepository;
        public CreateStyleCommandHandler(IStyleRepository styleRepository)
        {
            _styleRepository = styleRepository;
        }
        public async Task<Style> Handle(CreateStyleCommand request, CancellationToken cancellationToken)
        {
            var style = await _styleRepository.GetStyleByNameAsync(request.Style.StyleName);
            if(style is null)
            {
                style = await _styleRepository.CreateStyleAsync(request.Style);
            }

            return style;
        }
    }
}
