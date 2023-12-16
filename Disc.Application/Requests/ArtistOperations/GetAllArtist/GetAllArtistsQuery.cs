using Disc.Domain.Entities;
using MediatR;

namespace Disc.Application.Requests.ArtistOperations.GetAllArtist
{
    public class GetAllArtistsQuery : IRequest<List<GetAllArtistsQuery>>
    {
        public string ArtistName { get ; set; }
        public int Page { get; set; } = 1;
        public int Size { get; set; } = 1;
        public Country Country { get; set; }
        public MusicLabel MusicLabel { get; set; }
        public GetAllArtistsQuery(int size, int page, Country country, MusicLabel musicLabel)
        {
            Size = size;
            Page = page;
            Country = country;
            MusicLabel = musicLabel;
        }
        public GetAllArtistsQuery()
        {
                
        }
    }
}
