using Disc.Domain.Abstractions.Repositories;
using Disc.Domain.Entities;
using Disc.Domain.Exceptions;
using Disc.Domain.Exceptions.ConditionExceptions;
using Disc.Domain.Exceptions.CountryExceptions;
using MediatR;

namespace Disc.Application.Requests.ReleaseOperations.Commands.CreateRelease
{
    public class CreateReleaseCommandHandler : IRequestHandler<CreateReleaseCommand, Release>
    {
        IReleaseRepository _releaseRepository;
        IArtistRepository _artistRepository;
        ICountryRepository _countryRepository;
        IStyleRepository _styleRepository;
        IConditionRepository _conditionRepository;
        IGenreRepository _genreRepository;
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
            foreach(var requestGenre in request.Genres)
            {
                var genre = _genreRepository.GetGenreByNameAsync(requestGenre.GenreName);
                if (genre is null)
                {
                    throw new NullReferenceException($"{requestGenre.GenreName} : 'Genre' is not valid.");
                }
            }   
            foreach(var requestStyle in request.Styles)
            {
                var style = await _styleRepository.GetStyleByNameAsync(requestStyle.StyleName);
                if (style is null)
                {
                    throw new NullReferenceException($"{requestStyle.StyleName} : 'Style' is valid.");
                }
            }


            release.ReleaseGenre = await _releaseRepository.CreateReleaseGenreAsync(release, request.Genres);
            release.ReleaseStyle = await _releaseRepository.CreateReleaseStyleAsync(release, request.Styles); ;



            return release;
        }

        private async Task<Release?> ValidateOrCreateRelease(CreateReleaseCommand request, Artist artist)
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

        private async Task<Artist?> ValidateOrCreateArtist(CreateReleaseCommand request)
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
