using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PortalProductores.Domain.Dtos;

namespace PortalProductores.Api.Filters
{
    [AttributeUsage(AttributeTargets.All)]
    public sealed class AppCorrectFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (context != null && context.Exception == null
                && context.HttpContext.Response.StatusCode >= 200 && context.HttpContext.Response.StatusCode < 300
            )
            {
                if (context.Result is FileContentResult)
                {
                    return;
                }

                ObjectResultDto objectResult = new()
                {
                    Satisfactorio = true,
                    Codigo = (int)context.HttpContext.Response.StatusCode,
                    Mensaje = "Operación exitosa",
                    Data = context.Result is EmptyResult
                        ? null!
                        : (context.Result as ObjectResult)!.Value!
                };

                context.Result = new ObjectResult(objectResult);
            }
        }
    }
}
