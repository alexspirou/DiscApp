using Disc.Domain.Entities;
using MediatR;

namespace Application.Artists.Commands.CreateArtist
{
    public sealed class CreateArtistCommand : IRequest<List<Artist>>
    {
        public List<Artist> Artists { get; set; }
        public CreateArtistCommand(List<Artist> artists)
        {
            Artists = artists;
        }
        public CreateArtistCommand(Artist artist)
        {
            
        }
    }
}
