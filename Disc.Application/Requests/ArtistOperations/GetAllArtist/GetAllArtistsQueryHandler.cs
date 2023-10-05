using Disc.Domain.Abstractions.Repositories;
using Disc.Domain.Entities;
using MediatR;

namespace Disc.Application.Requests.ArtistOperations.GetAllArtist
{
    internal class GetAllArtistsQueryHandler : IRequestHandler<GetAllArtistsQuery, List<Artist>>
    {
        private readonly IArtistRepository _artistRepository;
        public GetAllArtistsQueryHandler(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }
        public async Task<List<Artist>> Handle(GetAllArtistsQuery request, CancellationToken cancellationToken)
        {
            //var artist = await _artistRepository.GetAllArtistsAsync();

            //return artist;
            throw new NotImplementedException();
        }
    }
}
