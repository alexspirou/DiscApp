using Disc.Domain.Entities;
using MediatR;

namespace Disc.Application.Requests.ArtistOperations.GetAllArtist
{
    public class GetAllArtistsQuery : IRequest<List<Artist>>
    {


    }
}
