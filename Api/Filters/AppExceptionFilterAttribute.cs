using System.Net;
using Domain.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Filters;

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
                AppException => ((int)HttpStatusCode.BadRequest),
                _ => ((int)HttpStatusCode.InternalServerError)
            };

            _logger.LogError(context.Exception, context.Exception.Message, new[] { context.Exception.StackTrace });

            var msg = new
            {
                context.Exception.Message
            };

            context.Result = new ObjectResult(msg);
        }
    }
}