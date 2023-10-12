using Disc.Application.DTOs.Release;
using Disc.Application.Extensions;
using Disc.Domain.Abstractions.Repositories;
using MediatR;

namespace Disc.Application.Requests.ReleaseOperations.Queries
{
    public class GetReleasesQueryHandler : IRequestHandler<GetReleasesQuery, ReleaseDetailsDto[]>
    {
        private readonly IReleaseRepository _releaseRepository;
        public GetReleasesQueryHandler(IReleaseRepository releaseRepository)
        {
            _releaseRepository = releaseRepository;
        }
        async Task<ReleaseDetailsDto[]> IRequestHandler<GetReleasesQuery, ReleaseDetailsDto[]>.Handle(GetReleasesQuery request, CancellationToken cancellationToken)
        {
            var releases = await _releaseRepository.GetReleaseRange(request.From, request.To);
            return releases.ToToReleaseDetailsDtoArray();

        }
    }
}
