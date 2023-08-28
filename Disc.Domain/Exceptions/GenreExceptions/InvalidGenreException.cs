using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disc.Domain.Exceptions.GenreExceptions
{
    public class InvalidGenreException : Exception
    {
        public InvalidGenreException(string genre, string message, Exception innerException)
        : base($"Invalid genre: {genre}. {message}", innerException)
        {
        }
    }


}
