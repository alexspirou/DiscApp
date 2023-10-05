using Disc.Domain.Entities;

namespace Disc.Domain.Exceptions.ArtistExceptions
{
    public class InvalidArtistException : Exception
    {
        public InvalidArtistException(string name)
            : base($"Invalid artist: {name}")
        {
        } 


        public InvalidArtistException(Artist artist, string message)
            : base($"Invalid artist: {artist.ArtistName}. {message}")
        {
        }

        public InvalidArtistException(Artist artist, string message, Exception innerException)
            : base($"Invalid artist: {artist.ArtistName}. {message}", innerException)
        {
        }
    }
}
