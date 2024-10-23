using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PortalProductores.Domain.Dtos;
using PortalProductores.Domain.Exceptions;
using System.Net;

namespace PortalProductores.Api.Filters
{
    [AttributeUsage(AttributeTargets.All)]
    public sealed class AppExceptionFilterAttribute(ILogger<AppExceptionFilterAttribute> _logger) : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context != null && context.Exception != null)
            {
                string errorMessage = context.Exception.Message;

                var statusCode = context.Exception switch
                {
                    ArgumentNullException or AppException or ValidatorException => HttpStatusCode.BadRequest,
                    TimeoutErrorException => HttpStatusCode.RequestTimeout,
                    UnauthorizedAccessException => HttpStatusCode.Unauthorized,
                    _ => HttpStatusCode.InternalServerError,
                };

                context.HttpContext.Response.StatusCode = (int)statusCode;

                _logger.LogError(context.Exception, errorMessage);

                ObjectResultDto objectResult = new()
                {
                    Satisfactorio = false,
                    Codigo = (int)statusCode,
                    Mensaje = errorMessage
                };

                context.Result = new ObjectResult(objectResult);
            }
        }
    }
}
