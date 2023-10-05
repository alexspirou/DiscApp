using Disc.Application.DTOs.Artist;
using Disc.Domain.Abstractions.Repositories;
using Disc.Application.Extensions;
using Disc.Application.ServicesAbstractions;
using Disc.Application.Requests.ArtistOperations.CreateArtist;

namespace Disc.Infrastructure.Services
{
    public class ShowArtistDetailsService : IShowArtistDetailsService
    {

        private readonly IArtistRepository _artistRepository;

        public ShowArtistDetailsService(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }

        public async Task<CreateArtistCommand> GetArtistDetailsAsync(string name)
        {
            var artist = await _artistRepository.GetArtistByNameAsync(name);

            var artistDetails = artist.ToCreateArtistCommand();

            return artistDetails;
        }


    }


}
