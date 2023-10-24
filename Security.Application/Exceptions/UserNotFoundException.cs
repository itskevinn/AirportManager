using System.Runtime.Serialization;

namespace Security.Application.Exceptions;


/// <summary>
/// Exception that is thrown when user is not found in the database
/// </summary>
[Serializable]
public class UserNotFoundException : Exception
{
    public UserNotFoundException()
    {
    }

    protected UserNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public UserNotFoundException(string? message) : base(message)
    {
    }

    public UserNotFoundException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}