using Disc.Application.ServicesAbstractions;
using Disc.Domain.Abstractions.Repositories;
using Disc.Infrastructure.Database.Repositories;
using Disc.Infrastructure.Services;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Disc.Infrastructure
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            // Add dependency injection here
            services.AddDbContext<DiscAppContext>(options =>
            {
                var connectionsString = "Data Source=DESKTOP-8KR908D\\SQLEXPRESS;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
                options.UseSqlServer(connectionsString, builder =>
                {
                    builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
                });
            }
            );
            services.AddScoped<IArtistRepository, ArtistRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<IReleaseRepository, ReleaseRepository>();
            services.AddScoped<IConditionRepository, ConditioRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<IStyleRepository, StyleRepository>();

            services.AddScoped<IShowArtistDetailsService, ShowArtistDetailsService>();
            return services;
        }
    }
}
