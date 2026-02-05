using Hrithik.Api.ErrorKit.Middleware;
using Microsoft.AspNetCore.Builder;

namespace Hrithik.Api.ErrorKit.Extensions;

/// <summary>
/// Application pipeline extensions for Api Error Kit.
/// </summary>
public static class ApplicationBuilderExtensions
{
    /// <summary>
    /// Enables standardized API error handling middleware.
    /// </summary>
    public static IApplicationBuilder UseApiErrorKit(this IApplicationBuilder app)
    {
        return app.UseMiddleware<ApiErrorHandlingMiddleware>();
    }
}
