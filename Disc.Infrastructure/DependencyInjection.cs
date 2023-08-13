using Disc.Domain.Repositories;
using Disc.Infrastructure.Database.Repositories;
using Infrastructure.Database;
using Microsoft.Extensions.DependencyInjection;

namespace Disc.Infrastructure
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            // Add dependency injection here
            services.AddScoped<DiscAppContext>();
            services.AddScoped<IArtistRepository, ArtistRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<IReleaseRepository, ReleaseRepository>();
            return services;
        }
    }
}
