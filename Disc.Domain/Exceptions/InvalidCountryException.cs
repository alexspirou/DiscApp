namespace Disc.Domain.Exceptions
{
    public class InvalidCountryException : Exception
    {
        public InvalidCountryException(string country)
            : base($"Invalid country code: {country}")
        {
        }

        public InvalidCountryException(string country, string message)
            : base($"Invalid country: {country}. {message}")
        {
        }

        public InvalidCountryException(string country, string message, Exception innerException)
            : base($"Invalid country: {country}. {message}", innerException)
        {
        }
    }
}
