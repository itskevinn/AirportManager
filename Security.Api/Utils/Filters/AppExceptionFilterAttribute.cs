using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Security.Domain.Exceptions;

namespace Security.Api.Utils.Filters;

[AttributeUsage(AttributeTargets.All)]
public sealed class AppExceptionFilterAttribute : ExceptionFilterAttribute
{
    private readonly ILogger<AppExceptionFilterAttribute>? _logger;

    public AppExceptionFilterAttribute(ILogger<AppExceptionFilterAttribute>? logger)
    {
        _logger = logger;
    }


    public override void OnException(ExceptionContext context)
    {
        context.HttpContext.Response.StatusCode = context.Exception switch
        {
            AppException => ((int)HttpStatusCode.BadRequest),
            _ => ((int)HttpStatusCode.InternalServerError)
        };

        _logger?.LogError(context.Exception, "{EMessage}. \n Full StackTrace: {FullStackTrace}",
            context.Exception.Message, context.Exception.StackTrace);

        var msg = new
        {
            context.Exception.Message
        };

        context.Result = new ObjectResult(msg);
    }
}