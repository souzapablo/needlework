using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using NeedleWork.Core.Exceptions;

namespace NeedleWork.API.Middlewares;

public class GlobalExceptionHandlingMiddleware : IMiddleware
{
    private readonly ILogger<GlobalExceptionHandlingMiddleware> _logger;

    public GlobalExceptionHandlingMiddleware(ILogger<GlobalExceptionHandlingMiddleware> logger)
    {
        _logger = logger;
    }
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (NotFoundException ex)
        {
            context.Response.StatusCode = (int) HttpStatusCode.NotFound;
            _logger.LogError(ex, ex.Message);

            ProblemDetails problem = new() 
            {
                Status = (int) HttpStatusCode.NotFound,
                Type = "Not found",
                Title = "Not found",
                Detail = ex.Message
            };

            var json = JsonSerializer.Serialize(problem);   

            context.Response.ContentType = "application/json";
            
            await context.Response.WriteAsync(json);
        }
        catch (Exception ex)
        {
            context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
            _logger.LogCritical(ex, ex.Message);

            ProblemDetails problem = new() 
            {
                Status = (int) HttpStatusCode.InternalServerError,
                Type = "Server error",
                Title = "Server error",
                Detail = "An internal server error has occured"
            };

            var json = JsonSerializer.Serialize(problem);   

            context.Response.ContentType = "application/json";
            
            await context.Response.WriteAsync(json);
        }
    }
}