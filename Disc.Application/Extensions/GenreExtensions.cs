using Disc.Application.DTOs.Release;
using Disc.Application.DTOs.Style;
using Disc.Domain.Entities;

namespace Disc.Application.Extensions
{
    public static class GenreExtensions
    {
        #region ToGenre
        public static Genre ToGenre(this string genreDto)
        {
            var genre = new Genre()
            {
                GenreName = genreDto,
            };
            return genre;
        }

        public static List<Genre> ToGenreList(this IEnumerable<string> genreDtos)
        {
            return genreDtos?.Select(dto => dto.ToGenre()).ToList();
        } 
        public static Genre[] ToGenreArray(this IEnumerable<string> genreDtos)
        {
            return genreDtos?.Select(dto => dto.ToGenre()).ToArray();
        }

        #endregion
    }
}
