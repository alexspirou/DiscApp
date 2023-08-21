using Disc.Application.Requests.ReleaseOperations.Commands.CreateRelease;
using Disc.Domain.Abstractions.Repositories;
using Disc.Domain.Entities;
using MediatR;

namespace Disc.Application.Requests.GenreOperations.Commands.CreateGenre
{
    public class CreateGenreCommandHandler : IRequestHandler<CreateGenreCommand, Genre>
    {
        private readonly IGenreRepository _genreRepository;

        public CreateGenreCommandHandler(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }


        public async Task<Genre> Handle(CreateGenreCommand request, CancellationToken cancellationToken)
        {
            var genre = await _genreRepository.GetGenreByNameAsync(request.Genre.GenreName);
            if(genre == null)
            {
                genre = await _genreRepository.CreateGenreAsync(request.Genre);
            }

            return genre;
        }
    }
}
