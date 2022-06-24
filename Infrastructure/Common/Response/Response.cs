using System.Net;

namespace Infrastructure.Common.Response;

public class Response<T>
{
    public Response(HttpStatusCode statusCode, string message, bool success, T data = default!,
        Exception exception = null!)
    {
        StatusCode = statusCode;
        Message = message;
        Success = success;
        Data = data;
        Exception = exception;
        ExceptionMessage = exception?.Message;
    }

    public HttpStatusCode StatusCode { get; set; }
    public string Message { get; set; }
    public bool Success { get; set; }
    public T Data { get; set; }
    public string? ExceptionMessage { get; set; }
    public Exception Exception { get; set; }
}