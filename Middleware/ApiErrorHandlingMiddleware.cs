using Hrithik.Api.ErrorKit.Abstractions;
using Microsoft.AspNetCore.Http;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace Hrithik.Api.ErrorKit.Middleware;

/// <summary>
/// Middleware that catches exceptions and returns standardized API errors.
/// </summary>
public sealed class ApiErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ApiErrorHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context, IApiErrorFactory factory)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            var error = factory.Create(ex, context);

            context.Response.StatusCode = error.Status;
            context.Response.ContentType = "application/json";

            await context.Response.WriteAsync(
    JsonSerializer.Serialize(error)
);
        }
    }
}
