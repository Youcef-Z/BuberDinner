using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BuberDinner.Api.Filters;

public class ErrorHandlingFilterAttribute : ExceptionFilterAttribute {

    public override void OnException(ExceptionContext context) {
        Exception exception = context.Exception;

        var problemDetails = new ProblemDetails {
            Type = "https://tools.ietf.org/html/rfc2616#section-10",
            Title = "An error occurred while processing your request.",
            Detail = exception.Message,
            Status = 500
        };


        context.Result = new ObjectResult(problemDetails);

        context.ExceptionHandled = true;

    }
}
