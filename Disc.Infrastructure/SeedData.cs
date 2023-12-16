using Disc.Domain.Abstractions.Repositories;
using Disc.Domain.Entities;

namespace Disc.Infrastructure
{
    public class SeedData
    {
        private readonly IArtistRepository _artistRepository;
        private readonly IConditionRepository _conditionRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly IStyleRepository _styleRepository;

        public SeedData(IArtistRepository artistRepository, IConditionRepository conditionRepository, IGenreRepository genreRepository, IStyleRepository styleRepository)
        {
            _artistRepository = artistRepository;
            _conditionRepository = conditionRepository;
            _genreRepository = genreRepository;
            _styleRepository = styleRepository;

        }
        public async Task GenerateTestData()
        {

            await SeedArtists();
            await GenerateConditions();
            await GenerateGenres();
            await GenerateStyles();

        }


        private async Task SeedArtists()
        { 
            var artists = new List<Artist>
            {
                new Artist { ArtistId = 1, ArtistName = "Bob Marley", RealName = "Robert Nesta Marley", Country = new Country { CountryId = 1, CountryName = "Jamaica" } },
                new Artist { ArtistId = 3, ArtistName = "Beyoncé", RealName = "Beyoncé Giselle Knowles-Carter", Country = new Country { CountryId = 3, CountryName = "United States" } },
                new Artist { ArtistId = 4, ArtistName = "Sezen Aksu", RealName = "Fatma Sezen Yıldırım", Country = new Country { CountryId = 4, CountryName = "Turkey" } },
                new Artist { ArtistId = 5, ArtistName = "Carlos Santana", RealName = "Carlos Augusto Santana Alves", Country = new Country { CountryId = 5, CountryName = "Mexico" } },
                new Artist { ArtistId = 6, ArtistName = "Edith Piaf", RealName = "Édith Giovanna Gassion", Country = new Country { CountryId = 6, CountryName = "France" } },
                new Artist { ArtistId = 7, ArtistName = "Fela Kuti", RealName = "Olufela Olusegun Oludotun Ransome-Kuti", Country = new Country { CountryId = 7, CountryName = "Nigeria" } },
                new Artist { ArtistId = 8, ArtistName = "Shakira", RealName = "Shakira Isabel Mebarak Ripoll", Country = new Country { CountryId = 8, CountryName = "Colombia" } },
                new Artist { ArtistId = 9, ArtistName = "Ravi Shankar", RealName = "Ravi Shankar Chowdhury", Country = new Country { CountryId = 9, CountryName = "India" } },
                new Artist { ArtistId = 10, ArtistName = "Gustavo Cerati", RealName = "Gustavo Adrián Cerati", Country = new Country { CountryId = 10, CountryName = "Argentina" } },
                new Artist { ArtistId = 11, ArtistName = "A. R. Rahman", RealName = "Allah Rakha Rahman", Country = new Country { CountryId = 11, CountryName = "India" } },
                new Artist { ArtistId = 12, ArtistName = "Céline Dion", RealName = "Céline Marie Claudette Dion", Country = new Country { CountryId = 12, CountryName = "Canada" } },
                new Artist { ArtistId = 13, ArtistName = "Buena Vista Social Club", RealName = "Various Artists", Country = new Country { CountryId = 13, CountryName = "Cuba" } },
                new Artist { ArtistId = 14, ArtistName = "Abdul Halim Hafez", RealName = "Abdul Halim Ali Shabana", Country = new Country { CountryId = 14, CountryName = "Egypt" } },
                new Artist { ArtistId = 15, ArtistName = "Amy Winehouse", RealName = "Amy Jade Winehouse", Country = new Country { CountryId = 15, CountryName = "United Kingdom" } },
            };

        artists.ForEach(async artist => await _artistRepository.CreateArtistAsync(artist));

        }


        public async Task GenerateConditions()
        {
            var conditions = new List<Condition>
            {
                new Condition
                {
                    ConditionId = 1,
                    ConditionName = "Mint (M)",
                    Description = "Perfect, with no visible signs of wear or damage."
                },
                new Condition
                {
                    ConditionId = 2,
                    ConditionName = "Very Good Plus (VG+)",
                    Description = "Slight signs of wear and may have some light scuffs or scratches."
                },
                new Condition
                {
                    ConditionId = 3,
                    ConditionName = "Very Good (VG)",
                    Description = "More noticeable wear and scuffs, but still plays well."
                },
                new Condition
                {
                    ConditionId = 4,
                    ConditionName = "Good (G)",
                    Description = "Significant wear, scratches, and potential surface noise during playback."
                },
                new Condition
                {
                    ConditionId = 5,
                    ConditionName = "Poor (P) / Fair (F)",
                    Description = "Heavy wear, skips, and may have serious damage."
                }
            };

            conditions.ForEach(async condition => await _conditionRepository.CreateConditonAsync(condition));
        }

        public async Task GenerateGenres()
        {
            var genres = new List<Genre>
            {
                new Genre { GenreId = 1, GenreName = "Electronic" },
                new Genre { GenreId = 2, GenreName = "Rock" },
                new Genre { GenreId = 3, GenreName = "Hip Hop" },
                new Genre { GenreId = 4, GenreName = "Pop" },
                new Genre { GenreId = 5, GenreName = "Jazz" }
            };

            genres.ForEach(async genre => await _genreRepository.CreateGenreAsync(genre));
        }
        public async Task GenerateStyles()
        {
            var styles = new List<Style>
            {
                new Style { StyleId = 1, StyleName = "Techno" },
                new Style { StyleId = 2, StyleName = "House" },
                new Style { StyleId = 3, StyleName = "R&B" },
                new Style { StyleId = 4, StyleName = "Classical" },
                new Style { StyleId = 5, StyleName = "Reggae" }
            };

            foreach (var style in styles)
            {
                await _styleRepository.CreateStyleAsync(style);
            }
        }
    }
}
