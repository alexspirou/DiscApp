using Disc.Application.DTOs.Artist;
using Disc.Application.DTOs.Condition;
using Disc.Application.DTOs.Release;
using Disc.Application.Requests.ArtistOperations.ArtistDetails;
using Disc.Application.Requests.ArtistOperations.CreateArtist;
using Disc.Application.Requests.ArtistOperations.GetAllArtist;
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
                ArtistDetails = new ArtistDetailsDto
                {
                    ArtistName = artist.ArtistName == null ? "N/A" : artist.ArtistName,
                    RealName = artist.RealName == null ? "N/A" : artist.RealName,
                    Country = artist.Country == null ? "N/A" : artist.Country.CountryName,
                    Links = artist.Links.Select(x => x.Link.SiteUrl).ToArray()
                }
            };
        }   

        public static List<CreateArtistCommand> ToCreateArtistCommandList(this IEnumerable<Artist> artists)
        {
            return artists?.Select(a => a.ToCreateArtistCommand()).ToList();
        }


        #endregion

        #region SearchArtistQuery extensions
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

        #region GetAllArtist extensions 
        // TODO : Add image 

        public static GetAllArtistsQuery ToGetAllArtistQuery(this Artist artist)
        {
            return new GetAllArtistsQuery
            {
                ArtistName = artist.ArtistName == null ? "N/A" : artist.ArtistName,
            };
        }
        public static List<GetAllArtistsQuery> ToGetAllArtistQueryList(this IEnumerable<Artist> artists)
        {
            return artists?.Select(a => a.ToGetAllArtistQuery()).ToList();
        }
        public static GetAllArtistsQuery[] ToGetAllArtistQueryArray(this IEnumerable<Artist> artists)
        {
            return artists?.Select(a => a.ToGetAllArtistQuery()).ToArray();
        }


        #endregion

        #region GetArtistDetailsQuery extensions

        public static GetArtistDetailsQuery ToGetArtistDetailsQuery(this Artist artist)
        {
            return new GetArtistDetailsQuery
            {
                Releases = artist.Release.ToToReleaseDetailsDtoArray(),
                ArtistName = artist.ArtistName == null ? "N/A" : artist.ArtistName,
                RealName = artist.RealName == null ? "N/A" : artist.RealName,
                Country = artist.Country == null ? "N/A" : artist.Country.CountryName,
                Links = artist.Links.Select(x => x.Link.SiteUrl).ToArray()
                
            };
        }

        #endregion
    }
}
