using Disc.Domain.Repositories;
using Disc.Domain.Entities;
using MediatR;

namespace Disc.Application.CountryOperations.Commands.CreateCountry
{
    public class CreateCountryCommandHandler : IRequestHandler<CreateCountryCommand, Country>
    {
        private readonly ICountryRepository _countryRepository;
        public CreateCountryCommandHandler(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
         }
        public async Task<Country> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
        {
            var country = await _countryRepository.GetCountryByNameAsync(request.Country.CountryName);

            if(country is null)
            {
                country = await _countryRepository.CreateCountryAsync(request.Country.CountryName);
            }

            return country;
        }
    }
}
