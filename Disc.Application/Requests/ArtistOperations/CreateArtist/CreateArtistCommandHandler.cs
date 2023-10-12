using Disc.Domain.Abstractions.Repositories;
using Disc.Domain.Entities;
using MediatR;

namespace Disc.Application.Requests.ArtistOperations.CreateArtist
{
    public class CreateArtistCommandHandler : IRequestHandler<CreateArtistCommand, Artist>
    {
        IArtistRepository _artistRepository;
        ICountryRepository _countryRepository;

        public CreateArtistCommandHandler(IArtistRepository artistRepository, ICountryRepository countryRepository)
        {
            _artistRepository = artistRepository;
            _countryRepository = countryRepository;
        }
        public async Task<Artist> Handle(CreateArtistCommand request, CancellationToken cancellationToken)
        {
            var artist = await _artistRepository.GetArtistByNameAsync(request.ArtistDetails.ArtistName);

            if (artist is null)
            {
                var country = await _countryRepository.GetCountryByNameAsync(request.ArtistDetails.Country);

                if (country is null)
                {
                    throw new Exception("The country that is passed is not exist.");
                }
                artist.Country = country;
                artist = await _artistRepository.CreateArtistAsync(artist);
            }

            return artist;
        }

    }
}
