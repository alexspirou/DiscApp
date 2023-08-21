using Disc.Domain.Abstractions.Repositories;
using Disc.Domain.Entities;
using Disc.Domain.Exceptions;
using MediatR;

namespace Disc.Application.Requests.ReleaseOperations.Commands.CreateRelease
{
    public class CreateReleaseCommandHandler : IRequestHandler<CreateReleaseCommand, Release>
    {
        private readonly IReleaseRepository _releaseRepository;
        private readonly IArtistRepository _artistRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly IStyleRepository _styleRepository;
        private readonly IConditionRepository _conditionRepository;
        private readonly IGenreRepository _genreRepository;
        public CreateReleaseCommandHandler(IReleaseRepository releaseRepository, IArtistRepository artistRepository,
            ICountryRepository countryRepository, IStyleRepository styleRepository, 
            IConditionRepository conditionRepository, IGenreRepository genreRepository)
        {
            _releaseRepository = releaseRepository;
            _artistRepository = artistRepository;
            _countryRepository = countryRepository;
            _styleRepository = styleRepository;
            _conditionRepository = conditionRepository;
            _genreRepository = genreRepository;
        }
        public async Task<Release> Handle(CreateReleaseCommand request, CancellationToken cancellationToken)
        {
            var artist = await ValidateOrCreateArtist(request);
            var release = await ValidateOrCreateRelease(request, artist);
            // Assign Genre to release
            if (request.Genres.Any(genre => genre is null))
            {
                throw new NullReferenceException("Genre is null");
            }
            release.ReleaseGenre = await _releaseRepository.CreateReleaseGenreAsync(release, request.Genres);

            if (request.Styles.Any(style => style is null))
            {
                throw new NullReferenceException("Style is null");
            }
            release.ReleaseStyle = await _releaseRepository.CreateReleaseStyleAsync(release, request.Styles); ;

            return release;
        }

        private async Task<Release> ValidateOrCreateRelease(CreateReleaseCommand request, Artist artist)
        {
            var release = await _releaseRepository.GetReleaseByDiscogIdAsync(request.Release.DiscogsId);
            if (release is null)
            {
                request.Release.Artist = artist;
                request.Release.Country = await _countryRepository.GetCountryByNameAsync(request.Release.Country.CountryName);
                if (request.Release.Country is null)
                {
                    throw new InvalidCountryException(request.Release.Artist.Country.CountryName);
                }
                if (request.Release.Condition is null)
                {
                    throw new InvalidConditionException(request.Release.Artist.Country.CountryName);
                }
                request.Release.Condition = await _conditionRepository.GetConditionByNameAsync(request.Release.Condition.ConditionName);
                release = await _releaseRepository.CreateReleaseAsync(request.Release);
            }

            return release;
        }

        private async Task<Artist> ValidateOrCreateArtist(CreateReleaseCommand request)
        {
            var artist = await _artistRepository.GetArtistByNameAsync(request.Artist.ArtistName);
            if (artist is null)
            {
                request.Artist.Country = await _countryRepository.GetCountryByNameAsync(request.Artist.Country.CountryName);
                if (request.Artist.Country is null)
                {
                    throw new InvalidCountryException(request.Release.Artist.Country.CountryName);
                }
                artist =  await _artistRepository.CreateArtistAsync(request.Artist);
            }
            return artist;
        }
    }
}
