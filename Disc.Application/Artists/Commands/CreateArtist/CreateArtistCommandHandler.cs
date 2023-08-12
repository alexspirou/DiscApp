using Disc.Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Artists.Commands.CreateArtist
{
    public class CreateArtistCommandHandler : IRequestHandler<CreateArtistCommand, List<Artist>>
    {
        IArtistRepository _artistRepository;
        ICountryRepository _countryRepository;

        public CreateArtistCommandHandler(IArtistRepository artistRepository, ICountryRepository countryRepository)
        {
            _artistRepository = artistRepository;
            _countryRepository = countryRepository;
        }
        public async Task<List<Artist>> Handle(CreateArtistCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var artistsList = new List<Artist>();
                var tasks = new List<Task>();
                var mutex = new Mutex();

                foreach (var artist in request.Artists)
                {
                   var currentTask = await Task.Factory.StartNew(async () =>
                    {
                        bool haveLock = mutex.WaitOne();
                        try
                        {
                            var country = await _countryRepository.GetCountryByNameAsync(artist.Country.CountryName);

                            if (country is null)
                            {
                                country = new Country() { CountryName = artist.Country.CountryName };
                            }

                            artist.Country = country;
                            var createdArtist = await _artistRepository.CreateArtistAsync(artist);
                            artistsList.Add(createdArtist);
                        }
                        finally
                        {
                            if (haveLock) mutex.ReleaseMutex();
                        }

                    });

                    tasks.Add(currentTask);

                }
                await Task.WhenAll(tasks);
                return artistsList;

            }
            catch (Exception ex)
            {
                throw new Exception("Artist could not be created", ex);
            }

        }
    }
}
