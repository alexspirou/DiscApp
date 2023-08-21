using MediatR;
using Disc.Domain.Entities;

namespace Disc.Application.Requests.ReleaseOperations.Commands.CreateRelease
{
    public class CreateReleaseCommand : IRequest<Release>
    {
        public Release Release { get; set; }
        public Artist Artist { get; set; }
        public Genre [] Genres { get; set; }
        public Style [] Styles { get; set; }

        public CreateReleaseCommand(Release releases, Artist artist, Genre[] genre, Style[] style)
        {
            Release = releases;
            Artist = artist;
            Genres = genre;
            Styles = style;
        }


    }
}
