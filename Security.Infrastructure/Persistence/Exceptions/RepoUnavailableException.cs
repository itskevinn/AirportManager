using System.Runtime.Serialization;

namespace Security.Infrastructure.Persistence.Exceptions;

[Serializable]
public class RepoUnavailableException : Exception
{
    public RepoUnavailableException()
    {
    }

    public RepoUnavailableException(string message) : base(message)
    {
    }

    public RepoUnavailableException(string message, Exception inner) : base(message, inner)
    {
    }

    protected RepoUnavailableException(
        SerializationInfo info,
        StreamingContext context) : base(info, context)
    {
    }
}