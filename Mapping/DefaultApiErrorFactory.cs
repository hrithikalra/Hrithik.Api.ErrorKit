using Hrithik.Api.ErrorKit.Abstractions;
using Hrithik.Api.ErrorKit.Constants;
using Hrithik.Api.ErrorKit.Exceptions;
using Hrithik.Api.ErrorKit.Models;
using Microsoft.AspNetCore.Http;
using System;

namespace Hrithik.Api.ErrorKit.Mapping;

/// <summary>
/// Default implementation of API error mapping.
/// </summary>
public sealed class DefaultApiErrorFactory : IApiErrorFactory
{
    public ApiError Create(Exception exception, HttpContext context)
    {
        var traceId = context.TraceIdentifier;

        return exception switch
        {
            ValidationException ve => CreateValidationError(ve, traceId),
            ApiException ae => CreateApiError(ae, traceId),
            _ => CreateInternalError(exception, traceId)
        };
    }

    private static ApiError CreateValidationError(ValidationException ex, string traceId)
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

    private static ApiError CreateApiError(ApiException ex, string traceId)
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

    private static ApiError CreateInternalError(Exception ex, string traceId)
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
