using Disc.Application.DTOs.Artist;
using Disc.Application.ServicesAbstractions;
using Disc.Domain.Exceptions.ArtistExceptions;
using MediatR;

namespace Disc.Application.Requests.ArtistOperations.ArtistDetails
{
    public class GetArtistDetailsQueryHandler : IRequestHandler<GetArtistDetailsQuery, ArtistDetailsDto>
    {
        private readonly IShowArtistDetailsService _showArtistDetailsService;
        public GetArtistDetailsQueryHandler(IShowArtistDetailsService showArtistDetailsService)
        {
            _showArtistDetailsService = showArtistDetailsService;
        }
        public async Task<ArtistDetailsDto> Handle(GetArtistDetailsQuery request, CancellationToken cancellationToken)
        {

            var artistDetails = await _showArtistDetailsService.GetArtistDetailsAsync(request.ArtistName);
            if (artistDetails is null)
            {
                throw new InvalidArtistException(request.ArtistName);
            }

            return artistDetails;
        }
    }
}
