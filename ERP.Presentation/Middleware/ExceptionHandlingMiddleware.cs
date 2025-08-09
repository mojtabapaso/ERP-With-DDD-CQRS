using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;

namespace ERP.Presentation.Middleware;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;
    private readonly IHostEnvironment _env;

    public ExceptionHandlingMiddleware(
        RequestDelegate next,
        ILogger<ExceptionHandlingMiddleware> logger,
        IHostEnvironment env)
    {
        _next = next;
        _logger = logger;
        _env = env;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (EmployeeNotFoundException ex)
        {
            _logger.LogWarning(ex, "Employee not found.");

            var problem = new ProblemDetails
            {
                Title = "Not Found",
                Detail = "Employee not found.",
                Status = (int)HttpStatusCode.NotFound,
                Type = "https://httpstatuses.com/404",
                Instance = context.Request.Path
            };

            context.Response.StatusCode = problem.Status.Value;
            context.Response.ContentType = "application/problem+json";
            await context.Response.WriteAsJsonAsync(problem);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unhandled exception occurred while processing the request.");

            var problem = new ProblemDetails
            {
                Status = (int)HttpStatusCode.InternalServerError,
                Instance = context.Request.Path,
                Type = "https://httpstatuses.com/500"
            };

            if (_env.IsDevelopment())
            {
                problem.Title = ex.Message;
                problem.Detail = ex.StackTrace;
            }
            else
            {
                problem.Title = "Internal Server Error";
                problem.Detail = "An unexpected error occurred. Please try again later.";
            }

            context.Response.StatusCode = problem.Status.Value;
            context.Response.ContentType = "application/problem+json";
            await context.Response.WriteAsJsonAsync(problem);
        }
    }
}
