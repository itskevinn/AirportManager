namespace Security.Infrastructure.Core.Utils
{
    public class Response
    {
        public Response(bool success)
        {
            Success = success;
        }

        public Response(bool success, string? error)
            : this(success)
        {
            Error = error;
        }

        public bool Success { get; private set; }

        public string? Error { get; private set; }

        public static implicit operator bool(Response response)
        {
            return response.Success;
        }
    }

    public class FailResponse : Response
    {
        public FailResponse()
            : base(false)
        {
        }

        public FailResponse(string? error)
            : base(false, error)
        {
        }
    }

    public class SuccessResponse : Response
    {
        public SuccessResponse()
            : base(true)
        {
        }

        public static DataResponse<T> WithData<T>(T data)
        {
            return new DataResponse<T>(data);
        }
    }

    public class DataResponse<T> : SuccessResponse
    {
        public DataResponse(T obj)
        {
            Data = obj;
        }

        public T Data { get; private set; }
    }
}