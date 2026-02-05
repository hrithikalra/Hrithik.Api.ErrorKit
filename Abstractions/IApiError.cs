using System;

namespace Hrithik.Api.ErrorKit.Abstractions;

/// <summary>
/// Represents a standardized API error contract.
/// Implemented by all API error response models.
/// </summary>
public interface IApiError
{
    /// <summary>
    /// Problem type URI reference.
    /// </summary>
    string Type { get; }

    /// <summary>
    /// Short, human-readable title.
    /// </summary>
    string Title { get; }

    /// <summary>
    /// HTTP status code.
    /// </summary>
    int Status { get; }

    /// <summary>
    /// Application-specific error code.
    /// </summary>
    string Code { get; }

    /// <summary>
    /// Client-safe error message.
    /// </summary>
    string Message { get; }

    /// <summary>
    /// Correlation / trace identifier.
    /// </summary>
    string TraceId { get; }

    /// <summary>
    /// Error timestamp (UTC).
    /// </summary>
    DateTime Timestamp { get; }
}
