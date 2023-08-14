using Application.ArtistOperations.Commands.CreateArtist;
using Disc.Domain.Entities;
using Disc.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disc.Application.ReleaseOperations.Commands.CreateRelease
{
    public class CreateReleaseCommandHandler : IRequestHandler<CreateReleaseCommand, Release>
    {
        IReleaseRepository _releaseRepository;
        IArtistRepository _artistRepository;
        ICountryRepository _countryRepository;
        IReleaseStyleRepository _relaseStyleRepository;
        public CreateReleaseCommandHandler(IReleaseRepository releaseRepository, IArtistRepository artistRepository, ICountryRepository countryRepository, IReleaseStyleRepository releaseStyleRepository)
        {
            _releaseRepository = releaseRepository;
            _artistRepository = artistRepository;
            _countryRepository = countryRepository;
            _relaseStyleRepository = releaseStyleRepository;
        }
        public async Task<Release> Handle(CreateReleaseCommand request, CancellationToken cancellationToken)
        {
            request.Release.Artist = await _artistRepository.GetArtistByNameAsync(request.Release.Artist.ArtistName);
            request.Release.Country = await _countryRepository.CreateCountryAsync("USA");
            var release = await _releaseRepository.CreateReleaseAsync(request.Release);
            var releaseStyleList = new List<ReleaseStyle>();

            foreach(var releaseStyle in request.Release.ReleaseStyle)
            {
                releaseStyleList.Add(await _relaseStyleRepository.CreateReleaseStyleAsync(releaseStyle));
            }
            release.ReleaseStyle = releaseStyleList;

            return release;
        }
    }
}
