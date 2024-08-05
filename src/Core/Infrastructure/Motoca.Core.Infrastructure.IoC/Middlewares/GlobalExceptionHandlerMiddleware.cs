using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Motoca.Core.Infrastructure.IoC.Middlewares;

public class GlobalExceptionHandlerMiddleware : IMiddleware
{
    private readonly ILogger<GlobalExceptionHandlerMiddleware> _logger;

    public GlobalExceptionHandlerMiddleware(ILogger<GlobalExceptionHandlerMiddleware> logger)
    {
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (DbUpdateException ex)
        {
            await AddLog(context.Request.Path, null, ex.InnerException?.Message ?? ex.Message, context, next);
        }
        catch (Exception ex)
        {
            await AddLog(context.Request.Path, null, ex.InnerException?.Message ?? ex.Message, context, next);
        }
    }

    private async Task AddLog(string endpoint, byte[] buffer, string error, HttpContext context, RequestDelegate next,
        int statusCode = StatusCodes.Status400BadRequest)
    {
        try
        {
            _logger.LogError($"Unexpected error: {error}");

            context.Response.StatusCode = statusCode;
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
        }
        finally
        {
            context.Response.Headers.Add("Accept", "application/json");
            context.Response.Headers.Add("Content-Type", "application/json");

            var json = JsonConvert.SerializeObject(new
            {
                message = error
            });
            
            await context.Response.WriteAsync(json);
        }
    }
}