using Application;
using Disc.Infrastructure;
using Newtonsoft.Json;
using Serilog;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services
                .AddApplication()
                .AddInfrastructure();


            builder.Services.AddCors(
            options =>
            {
                options.AddPolicy( "Any",
                cors =>
                {
                        cors.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
            });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Host.UseSerilog((context, configuration) =>
            configuration.ReadFrom.Configuration(context.Configuration));

            var app = builder.Build();
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            };


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                // Seed data during application startup
                using (var scope = app.Services.CreateScope())
                {
                    var seedDataWrapper = scope.ServiceProvider.GetRequiredService<SeedData>();
                    seedDataWrapper.GenerateTestData();
                }

                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors("Any");
            app.MapControllers();

            app.Run();
        }
    }

}