using Hrithik.Api.ErrorKit.Constants;
using Hrithik.Api.ErrorKit.Exceptions;
using Hrithik.Api.ErrorKit.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Net.Http;

namespace Hrithik.Api.ErrorKit.Mapping;

/// <summary>
/// Maps exceptions to API error responses.
/// </summary>
public static class ExceptionToErrorMapper
{
    /// <summary>
    /// Converts an exception into a standardized <see cref="ApiError"/>.
    /// </summary>
    public static ApiError Map(Exception exception, HttpContext context)
    {
        var traceId = context.TraceIdentifier;

        return exception switch
        {
            ValidationException ve => MapValidation(ve, traceId),
            ApiException ae => MapApiException(ae, traceId),
            _ => MapInternal(exception, traceId)
        };
    }

    private static ApiError MapValidation(ValidationException ex, string traceId)
        => new()
        {
            Type = "https://errors.hrithik.dev/validation-failed",
            Title = "Validation Failed",
            Status = ex.StatusCode,
            Code = ex.ErrorCode,
            Message = ex.Message,
            Errors = ex.Errors,
            TraceId = traceId,
            Timestamp = DateTime.UtcNow
        };

    private static ApiError MapApiException(ApiException ex, string traceId)
        => new()
        {
            Type = "https://errors.hrithik.dev/api-error",
            Title = "Request Failed",
            Status = ex.StatusCode,
            Code = ex.ErrorCode,
            Message = ex.Message,
            TraceId = traceId,
            Timestamp = DateTime.UtcNow
        };

    private static ApiError MapInternal(Exception ex, string traceId)
        => new()
        {
            Type = "https://errors.hrithik.dev/internal-error",
            Title = "Internal Server Error",
            Status = StatusCodes.Status500InternalServerError,
            Code = ErrorCodes.InternalError,
            Message = "An unexpected error occurred.",
            TraceId = traceId,
            Timestamp = DateTime.UtcNow
        };
}
