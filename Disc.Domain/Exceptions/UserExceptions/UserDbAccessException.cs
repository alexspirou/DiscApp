namespace Disc.Domain.Exceptions.UserExceptions
{
    public class UserDbAccessException : Exception
    {
        public UserDbAccessException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
