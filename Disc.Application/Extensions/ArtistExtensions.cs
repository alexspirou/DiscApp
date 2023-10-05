using Disc.Application.DTOs.Artist;
using Disc.Application.DTOs.Condition;
using Disc.Application.DTOs.Release;
using Disc.Application.Requests.ArtistOperations.CreateArtist;
using Disc.Application.Requests.ArtistOperations.SearchArtist;
using Disc.Domain.Entities;

namespace Disc.Application.Extensions
{
    public static class ArtistExtensions
    {
        #region ArtistDetailsDto extensions
        public static CreateArtistCommand ToCreateArtistCommand(this Artist artist)
        {
            return new CreateArtistCommand
            {
                ArtistName = artist.ArtistName == null ? "N/A" : artist.ArtistName,
                RealName = artist.RealName == null ? "N/A" : artist.RealName,
                Country = artist.Country == null ? "N/A" : artist.Country.CountryName,
                Link = artist.Links.Select(x => x.Link.SiteUrl).ToArray()
            };
        }   
        

        public static List<CreateArtistCommand> ToCreateArtistCommandList(this IEnumerable<Artist> artists)
        {
            return artists?.Select(a => a.ToCreateArtistCommand()).ToList();
        }


        #endregion

        #region SearchArtistDto extensions
        public static SearchArtistQuery ToSearchArtistQuery(this Artist artist)
        {
            return new SearchArtistQuery
            {
                ArtistName = artist.ArtistName == null ? "N/A" : artist.ArtistName,
            };
        }
        public static List<SearchArtistQuery> ToSearchArtistQueryList(this IEnumerable<Artist> artists)
        {
            return artists?.Select(a => a.ToSearchArtistQuery()).ToList();
        }
        public static SearchArtistQuery[] ToSearchArtistQueryArray(this IEnumerable<Artist> artists)
        {
            return artists?.Select(a => a.ToSearchArtistQuery()).ToArray();
        }
        #endregion
    }
}
