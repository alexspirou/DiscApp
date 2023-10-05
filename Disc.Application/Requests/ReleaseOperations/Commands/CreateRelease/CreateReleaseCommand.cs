using MediatR;
using Disc.Domain.Entities;
using Disc.Application.DTOs.Condition;
using Disc.Application.DTOs.Artist;

namespace Disc.Application.Requests.ReleaseOperations.Commands.CreateRelease
{
    public class CreateReleaseCommand : IRequest<Release>
    {
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public string Country { get; set; }
        public ConditionDto Condition { get; set; }
        public string[] Style { get; set; }
        public string[] Genre { get; set; }
        public string ArtistName { get; set; }

        public CreateReleaseCommand()
        {

        }


    }
}
