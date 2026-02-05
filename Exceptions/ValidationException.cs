using Hrithik.Api.ErrorKit.Constants;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Hrithik.Api.ErrorKit.Exceptions;

/// <summary>
/// Represents validation failures with field-level errors.
/// </summary>
public sealed class ValidationException : ApiException
{
    /// <summary>
    /// Validation errors grouped by field name.
    /// </summary>
    public IDictionary<string, string[]> Errors { get; }

    public ValidationException(IDictionary<string, string[]> errors)
        : base("One or more validation errors occurred.",
               ErrorCodes.ValidationError,
               StatusCodes.Status400BadRequest)
    {
        Errors = errors;
    }
}
