using Disc.Application.DTOs.Artist;
using MediatR;

namespace Disc.Application.Requests.ArtistOperations.SearchArtist
{
    public class SearchArtistQuery : IRequest<SearchArtistQuery[]>
    {
        public string ArtistName { get; set; }
        public SearchArtistQuery(string artistName)
        {
            ArtistName = artistName;
        }       
        
        public SearchArtistQuery()
        {
        }
    }
}
