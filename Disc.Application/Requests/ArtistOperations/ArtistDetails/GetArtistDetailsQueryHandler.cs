using Disc.Application.DTOs.Artist;
using Disc.Application.Extensions;
using Disc.Application.ServicesAbstractions;
using Disc.Domain.Abstractions.Repositories;
using Disc.Domain.Exceptions.ArtistExceptions;
using MediatR;
using System.Xml.Linq;

namespace Disc.Application.Requests.ArtistOperations.ArtistDetails
{
    public class GetArtistDetailsQueryHandler : IRequestHandler<GetArtistDetailsQuery, GetArtistDetailsQuery>
    {
        private readonly IArtistRepository _artistRepository;
        public GetArtistDetailsQueryHandler(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }
        public async Task<GetArtistDetailsQuery> Handle(GetArtistDetailsQuery request, CancellationToken cancellationToken)
        {
            var artist = await _artistRepository.GetArtistByNameAsync(request.RequestedArtistName);

            if (artist is null)
            {
                throw new InvalidArtistException(request.RequestedArtistName);
            }

            return artist.ToGetArtistDetailsQuery();
   
        }
    }
}
