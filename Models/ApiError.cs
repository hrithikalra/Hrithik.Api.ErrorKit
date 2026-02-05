using Hrithik.Api.ErrorKit.Abstractions;
using System;
using System.Collections.Generic;

namespace Hrithik.Api.ErrorKit.Models;

/// <summary>
/// Represents a standardized API error response.
/// Designed to be frontend-friendly and consistent across all APIs.
/// </summary>
public sealed class ApiError : IApiError
{
    /// <summary>
    /// A URI reference that identifies the problem type.
    /// </summary>
    public string Type { get; init; }

    /// <summary>
    /// A short, human-readable summary of the problem.
    /// </summary>
    public string Title { get; init; }

    /// <summary>
    /// HTTP status code of the error.
    /// </summary>
    public int Status { get; init; }

    /// <summary>
    /// Application-specific error code.
    /// Example: VALIDATION_ERROR, USER_NOT_FOUND
    /// </summary>
    public string Code { get; init; }

    /// <summary>
    /// Detailed error message safe to display to clients.
    /// </summary>
    public string Message { get; init; }

    /// <summary>
    /// Field-level validation or sub-errors.
    /// </summary>
    public IDictionary<string, string[]> Errors { get; init; }

    /// <summary>
    /// Trace identifier used for diagnostics and support.
    /// </summary>
    public string TraceId { get; init; }

    /// <summary>
    /// Timestamp when the error occurred (UTC).
    /// </summary>
    public DateTime Timestamp { get; init; }

    public IReadOnlyCollection<ApiSubError> SubErrors { get; init; }

}
