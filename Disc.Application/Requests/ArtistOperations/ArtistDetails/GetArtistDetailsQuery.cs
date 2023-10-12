using Disc.Application.DTOs.Artist;
using Disc.Application.DTOs.Release;
using MediatR;
using System.Runtime.Serialization;

namespace Disc.Application.Requests.ArtistOperations.ArtistDetails
{
    public class GetArtistDetailsQuery : IRequest<GetArtistDetailsQuery>
    {
        [IgnoreDataMember]
        public string RequestedArtistName { get; set; }

        public string ArtistName { get; set; } = null!;
        public string RealName { get; set; }
        public string Country { get; set; } = null!;
        public IEnumerable<ReleaseDetailsDto> Releases { get; set; }
        public IEnumerable<string> Links { get; set; }

        public GetArtistDetailsQuery(string requestedArtistName)
        {
            RequestedArtistName = requestedArtistName;
        }  
        
        public GetArtistDetailsQuery()
        {
        }
    }

}
