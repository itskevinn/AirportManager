using System.Runtime.Serialization;

namespace Security.Application.Exceptions;
/// <summary>
/// Excepción cuando ocurre un conflicto con la base de datos
/// </summary>
[Serializable]
public class ConflictException : Exception
{
	public ConflictException()
	{
	}

	protected ConflictException(SerializationInfo info, StreamingContext context) : base(info, context)
	{
	}

	public ConflictException(string? message) : base(message)
	{
	}

	public ConflictException(string? message, Exception? innerException) : base(message, innerException)
	{
	}
}