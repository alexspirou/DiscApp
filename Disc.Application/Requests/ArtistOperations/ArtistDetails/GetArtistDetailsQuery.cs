using Disc.Application.DTOs.Artist;
using MediatR;

namespace Disc.Application.Requests.ArtistOperations.ArtistDetails
{
    public class GetArtistDetailsQuery : IRequest<ArtistDetailsDto>
    {
        public string ArtistName { get; set; }

        public GetArtistDetailsQuery(string name)
        {
            ArtistName = name;
        }
    }

}
