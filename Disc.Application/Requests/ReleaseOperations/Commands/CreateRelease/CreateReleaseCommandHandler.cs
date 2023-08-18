using Disc.Domain.Entities;
using Disc.Domain.Exceptions;
using Disc.Domain.Repositories;
using MediatR;

namespace Disc.Application.Requests.ReleaseOperations.Commands.CreateRelease
{
    public class CreateReleaseCommandHandler : IRequestHandler<CreateReleaseCommand, Release>
    {
        IReleaseRepository _releaseRepository;
        IArtistRepository _artistRepository;
        ICountryRepository _countryRepository;
        IReleaseStyleRepository _relaseStyleRepository;
        IConditionRepository _conditionRepository;
        public CreateReleaseCommandHandler(IReleaseRepository releaseRepository, IArtistRepository artistRepository,
            ICountryRepository countryRepository, IReleaseStyleRepository releaseStyleRepository, IConditionRepository conditionRepository)
        {
            _releaseRepository = releaseRepository;
            _artistRepository = artistRepository;
            _countryRepository = countryRepository;
            _relaseStyleRepository = releaseStyleRepository;
            _conditionRepository = conditionRepository;
        }
        public async Task<Release> Handle(CreateReleaseCommand request, CancellationToken cancellationToken)
        {
            var artist = await _artistRepository.GetArtistByNameAsync(request.Release.Artist.ArtistName);
            if(artist is null)
            {
                request.Release.Artist.Country = await _countryRepository.GetCountryByNameAsync(request.Release.Artist.Country.CountryName);
                if(request.Release.Artist.Country is null)
                {
                    throw new InvalidCountryException(request.Release.Artist.Country.CountryName);
                }
                request.Release.Artist = await _artistRepository.CreateArtistAsync(request.Release.Artist);
            }
            
            var release = await _releaseRepository.GetReleaseByDiscogIdAsync(request.Release.DiscogsId);
            if(release is null)
            {
                request.Release.Country = await _countryRepository.GetCountryByNameAsync(request.Release.Country.CountryName);
                if (request.Release.Artist.Country is null)
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
    }
}
