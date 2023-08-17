using Disc.Domain.Entities;
using Disc.Domain.Repositories;
using MediatR;

namespace Disc.Application.Requests.ArtistsOperations.Queries.GetAllArtist
{
    internal class GetAllArtistsQueryHandler : IRequestHandler<GetAllArtistsQuery, List<Artist>>
    {
        IArtistRepository _artistRepository;
        public GetAllArtistsQueryHandler(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }
        public async Task<List<Artist>> Handle(GetAllArtistsQuery request, CancellationToken cancellationToken)
        {
            var artist = _artistRepository.GetAllArtists();

            return artist;
        }
    }
}
