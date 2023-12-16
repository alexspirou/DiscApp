using Disc.Application.DTOs.Artist;
using Disc.Application.Extensions;
using Disc.Domain.Abstractions.Repositories;
using Disc.Domain.Exceptions.ArtistExceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disc.Application.Requests.ArtistOperations.SearchArtist
{
    public class SearchArtistQueryHandler : IRequestHandler<SearchArtistQuery, SearchArtistQuery[]>
    {
        private readonly IArtistRepository _artistRepository;
        public SearchArtistQueryHandler(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }
        public async Task<SearchArtistQuery[]> Handle(SearchArtistQuery request, CancellationToken cancellationToken)
        {
            var result = await _artistRepository.SearchArtistsByNameAsync(request.ArtistName);

            if(result is null)
            {
                return new SearchArtistQuery[0];
            }
            return result.Select(a=>a).ToSearchArtistQueryArray();
        }
    }
}
