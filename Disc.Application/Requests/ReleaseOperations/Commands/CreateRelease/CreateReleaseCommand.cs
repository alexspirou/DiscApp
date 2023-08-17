using MediatR;
using Disc.Domain.Entities;

namespace Disc.Application.Requests.ReleaseOperations.Commands.CreateRelease
{
    public class CreateReleaseCommand : IRequest<Release>
    {
        public Release Release { get; set; }

        public CreateReleaseCommand(Release releases)
        {
            Release = releases;
         }


    }
}
