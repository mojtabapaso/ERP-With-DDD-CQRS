using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ERP.Presentation.Middleware;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate next;
    private readonly ILogger<ExceptionHandlingMiddleware> logger;
    private readonly IHostEnvironment env;

    public ExceptionHandlingMiddleware(
        RequestDelegate next,
        ILogger<ExceptionHandlingMiddleware> logger,
        IHostEnvironment env)
    {
        this.next = next;
        this.logger = logger;
        this.env = env;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (EmployeeNotFoundException ex)
        {
            logger.LogWarning(ex, ex.Message);

            var problem = new ProblemDetails
            {
                Title = HttpStatusCode.NotFound.ToString(),
                Detail = ex.Message,
                Status = (int)HttpStatusCode.NotFound,
                Instance = context.Request.Path
            };

            context.Response.StatusCode = problem.Status.Value;
            //context.Response.ContentType = "application/problem+json";
            await context.Response.WriteAsJsonAsync(problem);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Unhandled exception occurred while processing the request.");

            var problem = new ProblemDetails
            {
                Status = (int)HttpStatusCode.InternalServerError,
                Instance = context.Request.Path,
            };

            if (env.IsDevelopment())
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
