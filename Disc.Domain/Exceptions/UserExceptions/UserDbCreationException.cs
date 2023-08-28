namespace Disc.Domain.Exceptions.UserExceptions
{
    public class UserDbCreationException : Exception
    {
        public UserDbCreationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

    }
}
