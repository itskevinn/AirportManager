using System.Runtime.Serialization;

namespace Security.Infrastructure.Persistence.Exceptions;

/// <summary>
/// Exception that is thrown when database connection has errors
/// </summary>
[Serializable]
public class DatabaseUnavailableException : Exception
{
    public DatabaseUnavailableException()
    {
    }

    public DatabaseUnavailableException(string message) : base(message)
    {
    }

    public DatabaseUnavailableException(string message, Exception inner) : base(message, inner)
    {
    }

    protected DatabaseUnavailableException(
        SerializationInfo info,
        StreamingContext context) : base(info, context)
    {
    }
}