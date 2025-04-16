using CapstoneProject.Business.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CapstoneProject.API.Exceptions
{
    public class NotFoundExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is NotFoundException)
            {
                ProblemDetails problemDetails = new ProblemDetails
                {
                    Title = context.Exception.Message,
                    Status = (int)HttpStatusCode.NotFound,
                };

                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                context.Result = new ObjectResult(problemDetails);

                context.ExceptionHandled = true;
            }
        }
    }
}
