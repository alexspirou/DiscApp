using Disc.Domain.Entities;

namespace WebApi.Dummy
{
    /// <summary>
    /// Dummy class to create records from text file.
    /// </summary>
    public class ArtistReader
    {
        public List<Artist> ReadArtists(string filePath)
        {
            var artists = new List<Artist>();

            try
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 3)
                    {
                        artists.Add(new Artist
                        {
                            ArtistName = parts[0].Trim(),
                            RealName = parts[1].Trim(),
                            Country = new Country { CountryName=  parts[2].Trim() }
                        });
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"The file {filePath} was not found.");
            }

            return artists;
        }
    }
}
