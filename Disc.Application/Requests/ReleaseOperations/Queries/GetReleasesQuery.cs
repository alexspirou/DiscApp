using Disc.Application.DTOs.Release;
using MediatR;

namespace Disc.Application.Requests.ReleaseOperations.Queries
{
    public class GetReleasesQuery : IRequest<ReleaseDetailsDto[]>
    {
        public int From { get;set; }
        public int To { get;set; }

        public GetReleasesQuery(int from, int to)
        {
            From = from;
            To = to;  
        }
    }
}
