using Disc.Application.DTOs.Artist;
using Disc.Application.Services.ArtistDetails;
using Disc.Domain.Abstractions.Repositories;
using Disc.Application.Extensions;

namespace Disc.Infrastructure.Services.ArtistDetailsImpl
{
    public class ShowArtistDetailsService : IShowArtistDetailsService
    {

        private readonly IArtistRepository _artistRepository;

        public ShowArtistDetailsService(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }

        public async Task<ArtistDetailsDto> GetArtistDetailsAsync(uint id)
        {
            var artist = await _artistRepository.GetByIdAsync(id);

           var artistDetails =  artist.ToArtistDetailsDto();

            return artistDetails;
        }


    }


}
