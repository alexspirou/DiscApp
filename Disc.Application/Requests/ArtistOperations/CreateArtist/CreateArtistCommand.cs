using Disc.Application.DTOs.Artist;
using Disc.Domain.Entities;
using MediatR;

namespace Disc.Application.Requests.ArtistOperations.CreateArtist
{
    public sealed class CreateArtistCommand : IRequest<Artist>
    {
        public string ArtistName { get; set; }
        public string RealName { get; set; }
        public string Country { get; set; }
        public string[] Link { get; set; }
        public string[] MusicLabel { get; set; }
        public CreateArtistCommand()
        {
        }

    }
}
