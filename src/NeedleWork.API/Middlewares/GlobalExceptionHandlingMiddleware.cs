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
        catch (InputValidationException ex)
        {
            context.Response.StatusCode = (int) HttpStatusCode.BadRequest;
            _logger.LogError(ex, ex.Message);

            ProblemDetails problem = new() 
            {
                Status = (int) HttpStatusCode.BadRequest,
                Type = "Validation error",
                Title = "One or more validation errors occurred",
                Detail = "The request contains invalid parameters. More information can be found in the errors.",
                Extensions =
                {
                    ["errors"] = ex.Errors
                }
            };

            var json = JsonSerializer.Serialize(problem);   

            context.Response.ContentType = "application/json";
            
            await context.Response.WriteAsync(json);
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
        catch (EmailAlreadyRegisteredException ex)
        {
            context.Response.StatusCode = (int) HttpStatusCode.BadRequest;
            _logger.LogError(ex, ex.Message);

            ProblemDetails problem = new() 
            {
                Status = (int) HttpStatusCode.BadRequest,
                Type = "Bad request",
                Title = "E-mail registered",
                Detail = ex.Message,
            };

            var json = JsonSerializer.Serialize(problem);   

            context.Response.ContentType = "application/json";
            
            await context.Response.WriteAsync(json);
        }
        catch (InvalidCredentialsException ex) 
        {
            context.Response.StatusCode = (int) HttpStatusCode.Unauthorized;
            _logger.LogError(ex, ex.Message);

            ProblemDetails problem = new() 
            {
                Status = (int) HttpStatusCode.Unauthorized,
                Type = "Unauthorized",
                Title = "Invalid credentials",
                Detail = ex.Message
            };

            var json = JsonSerializer.Serialize(problem);   

            context.Response.ContentType = "application/json";
            
            await context.Response.WriteAsync(json); 
        }
        catch (PurchaseItemAlreadyPresentException ex)
        {
            context.Response.StatusCode = (int) HttpStatusCode.BadRequest;
            _logger.LogError(ex, ex.Message);

            ProblemDetails problem = new() 
            {
                Status = (int) HttpStatusCode.BadRequest,
                Type = "Bad request",
                Title = "Invalid input",
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
                Title = "An internal server error has occured",
                Detail = "Contact admin for more information"
            };

            var json = JsonSerializer.Serialize(problem);   

            context.Response.ContentType = "application/json";
            
            await context.Response.WriteAsync(json);
        }
    }
}