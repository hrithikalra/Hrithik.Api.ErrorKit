using Hrithik.Api.ErrorKit.Constants;
using Microsoft.AspNetCore.Http;

namespace Hrithik.Api.ErrorKit.Exceptions;

/// <summary>
/// Represents an authorization failure (HTTP 403).
/// </summary>
public sealed class ForbiddenException : ApiException
{
    public ForbiddenException(string message = "You do not have permission to perform this action.")
        : base(message, ErrorCodes.Forbidden, StatusCodes.Status403Forbidden)
    {
    }
}
