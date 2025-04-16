using System.Net;
using CapstoneProject.Business.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CapstoneProject.API.Exceptions
{
    public class InvalidLoginAttemptExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is InvalidLoginAttemptException)
            {
                ProblemDetails problemDetails = new ProblemDetails
                {
                    Title = context.Exception.Message,
                    Status = (int)HttpStatusCode.Unauthorized,
                };
                
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                context.Result = new ObjectResult(problemDetails);

                context.ExceptionHandled = true;
            }
        }
    }
}
