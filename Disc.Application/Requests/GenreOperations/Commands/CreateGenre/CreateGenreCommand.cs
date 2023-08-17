using Disc.Domain.Entities;
using MediatR;

namespace Disc.Application.Requests.GenreOperations.Commands.CreateGenre
{
    public class CreateGenreCommand : IRequest<Genre>
    {
        public Genre Genre { get; set; }
        public CreateGenreCommand(Genre genre)
        {
            Genre = genre;
        }
    }
}
