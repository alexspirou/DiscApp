using Disc.Domain.Entities;
using Disc.Domain.Repositories;
using MediatR;

namespace Disc.Application.Requests.ArtistOperations.Commands.CreateArtist
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
            var artist = await _artistRepository.GetArtistByNameAsync(request.Artist.ArtistName);
            var country = await _countryRepository.GetCountryByNameAsync(request.Artist.Country.CountryName);

            if(country is null)
            {
                throw new Exception("The country that is passed is not exist.");
            }
            if (artist is null)
            {
                request.Artist.Country = country;
                artist = await _artistRepository.CreateArtistAsync(request.Artist);
            }
            return artist;
        }

    }
}
