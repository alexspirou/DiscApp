using Disc.Domain.Abstractions.Repositories;
using MediatR;
using Disc.Application.Extensions;
using Disc.Domain.Entities;

namespace Disc.Application.Requests.ArtistOperations.GetAllArtist
{
    internal class GetAllArtistsQueryHandler : IRequestHandler<GetAllArtistsQuery, List<GetAllArtistsQuery>>
    {
        private readonly IArtistRepository _artistRepository;
        public GetAllArtistsQueryHandler(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }
        public async Task<List<GetAllArtistsQuery>> Handle(GetAllArtistsQuery request, CancellationToken cancellationToken)
        {
            var artist = (List<Artist>)(await _artistRepository.GetAllArtistsAsync(request.Size, request.Page, request.Country, request.MusicLabel));

            return artist.ToGetAllArtistQueryList();
        }
    }
}
