using Disc.Domain.Abstractions.Repositories;
using Disc.Domain.Entities;
using Disc.Domain.Exceptions.ArtistExceptions;
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
            var newArtist = await _artistRepository.GetArtistByNameAsync(request.ArtistName);
            if (newArtist is null)
            {
                throw new InvalidArtistException(request.ArtistName);
            }
            var release = await CreateRelease(request, newArtist);

            // Assign Genre to release
            var genreList = new List<Genre>();
            foreach (var requestGenre in request.Genre)
            {
                var genre = await _genreRepository.GetGenreByNameAsync(requestGenre);
                if (genre is null)
                {
                    throw new NullReferenceException($"{requestGenre} : 'Genre' is not valid.");
                }
                genreList.Add(await _genreRepository.GetGenreByNameAsync(requestGenre));

            }
            release.ReleaseGenre = await _releaseRepository.CreateReleaseGenreAsync(release, genreList.ToArray());

            // Assign Style to release
            var styleList = new List<Style>();
            foreach (var requestStyle in request.Style)
            {
                var style = await _styleRepository.GetStyleByNameAsync(requestStyle);
                if (style is null)
                {
                    throw new NullReferenceException($"{requestStyle} : 'Style' is valid.");
                }
                styleList.Add(await _styleRepository.GetStyleByNameAsync(requestStyle));

            }
            release.ReleaseStyle = await _releaseRepository.CreateReleaseStyleAsync(release, styleList.ToArray());

            return release;
        }

        private async Task<Release> CreateRelease(CreateReleaseCommand newReleaseRequest, Artist artist)
        {
            var release = new Release()
            {
                Title = newReleaseRequest.Title,
                ReleaseYear = newReleaseRequest.ReleaseYear,
                Artist = artist
            };

            release.Country = await _countryRepository.GetCountryByNameAsync(newReleaseRequest.Country);
            if (release.Country is null)
            {
                throw new InvalidCountryException(newReleaseRequest.Country);
            }

            release.Condition = await _conditionRepository.GetConditionByNameAsync(newReleaseRequest.Condition.ConditionName);
            if (release.Condition is null)
            {
                throw new InvalidConditionException(newReleaseRequest.Condition.ConditionName);
            }

            release = await _releaseRepository.CreateReleaseAsync(release);

            return release;
        }
    }
}
