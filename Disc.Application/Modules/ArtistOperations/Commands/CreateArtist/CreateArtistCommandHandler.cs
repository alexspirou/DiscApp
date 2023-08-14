using Application.ArtistOperations.Commands.CreateArtist;
using Disc.Domain.Entities;
using Disc.Domain.Repositories;
using MediatR;

namespace Disc.Application.Modules.ArtistOperations.Commands.CreateArtist
{
    public class CreateArtistCommandHandler : IRequestHandler<CreateArtistCommand, List<Artist>>
    {
        IArtistRepository _artistRepository;
        ICountryRepository _countryRepository;

        public CreateArtistCommandHandler(IArtistRepository artistRepository, ICountryRepository countryRepository)
        {
            _artistRepository = artistRepository;
            _countryRepository = countryRepository;
        }
        public async Task<List<Artist>> Handle(CreateArtistCommand request, CancellationToken cancellationToken)
        {
            var artistsList = new List<Artist>();
            foreach (var artist in request.Artists)
            {
                artist.Country = await _countryRepository.CreateCountryAsync(artist.Country.CountryName);
                artistsList.Add(await _artistRepository.CreateArtistAsync(artist));
            }
            return artistsList;
        }

    }
}
