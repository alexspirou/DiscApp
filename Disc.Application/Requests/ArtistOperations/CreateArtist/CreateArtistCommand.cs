using Disc.Application.DTOs.Artist;
using Disc.Domain.Entities;
using MediatR;

namespace Disc.Application.Requests.ArtistOperations.CreateArtist
{
    public sealed class CreateArtistCommand : IRequest<Artist>
    {
        public ArtistDetailsDto ArtistDetails { get; set; } 

        public CreateArtistCommand()
        {
        }

    }
}
