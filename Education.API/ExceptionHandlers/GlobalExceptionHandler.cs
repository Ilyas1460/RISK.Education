using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Education.API.ExceptionHandlers;

public class GlobalExceptionHandler : IExceptionHandler
{
    private readonly IProblemDetailsService _problemDetailsService;

    public GlobalExceptionHandler(IProblemDetailsService problemDetailsService)
    {
        _problemDetailsService = problemDetailsService;
    }

    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

        await _problemDetailsService.WriteAsync(new ProblemDetailsContext()
        {
            HttpContext = httpContext,
            ProblemDetails = new ProblemDetails()
            {
                Type = exception.GetType().Name,
                Title = "An error occurred while processing your request.",
                Detail = exception.Message
            }
        });

        return true;
    }
}
