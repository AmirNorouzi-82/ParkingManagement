using Microsoft.AspNetCore.Mvc;
using Serilog;

public class ExceptionHandlingMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Unhandled exception. Path={Path} Method={Method}",
                context.Request.Path, context.Request.Method);

            if (context.Response.HasStarted)
                return;

            context.Response.ContentType = "application/problem+json";

            var problem = new ProblemDetails
            {
                Title = "Internal Server Error",
                Status = StatusCodes.Status500InternalServerError,
                Detail = "An unexpected error occurred.",
                Instance = context.Request.Path
            };

            var env = context.RequestServices.GetRequiredService<IHostEnvironment>();
            if (env.IsDevelopment())
                problem.Extensions["exception"] = ex.Message;

            context.Response.StatusCode = problem.Status.Value;
            await context.Response.WriteAsJsonAsync(problem);
        }
    }
}
