using System.Net;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AirportGateway.Api.Filters;

[AttributeUsage(AttributeTargets.All)]
public sealed class AppExceptionFilterAttribute : ExceptionFilterAttribute
{
    private readonly ILogger<AppExceptionFilterAttribute> _logger;

    public AppExceptionFilterAttribute(ILogger<AppExceptionFilterAttribute> logger)
    {
        _logger = logger;
    }


    public override void OnException(ExceptionContext context)
    {
        {
            context.HttpContext.Response.StatusCode = context.Exception switch
            {
                not null => ((int)HttpStatusCode.BadRequest),
                _ => ((int)HttpStatusCode.InternalServerError)
            };

            _logger.LogError(context.Exception, context.Exception?.Message, new object?[] { context.Exception?.StackTrace });

            var msg = new
            {
                context.Exception?.Message
            };

            context.Result = new ObjectResult(msg);
        }
    }
}