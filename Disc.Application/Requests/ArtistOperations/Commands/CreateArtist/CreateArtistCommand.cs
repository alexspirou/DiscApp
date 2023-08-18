using Disc.Domain.Entities;
using MediatR;

namespace Disc.Application.Requests.ArtistOperations.Commands.CreateArtist
{
    public sealed class CreateArtistCommand : IRequest<Artist>
    {
        public Artist Artist { get; set; }
        public CreateArtistCommand(Artist artist)
        {
            Artist = artist;
        }

    }
}
