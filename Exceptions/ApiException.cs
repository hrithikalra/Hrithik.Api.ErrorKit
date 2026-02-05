using System;

namespace Hrithik.Api.ErrorKit.Exceptions;

/// <summary>
/// Base exception for all API-specific errors.
/// </summary>
public abstract class ApiException : Exception
{
    /// <summary>
    /// HTTP status code associated with this exception.
    /// </summary>
    public int StatusCode { get; }

    /// <summary>
    /// Application-specific error code.
    /// </summary>
    public string ErrorCode { get; }

    protected ApiException(string message, string errorCode, int statusCode)
        : base(message)
    {
        ErrorCode = errorCode;
        StatusCode = statusCode;
    }
}
