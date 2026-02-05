using Hrithik.Api.ErrorKit.Constants;
using Microsoft.AspNetCore.Http;

namespace Hrithik.Api.ErrorKit.Exceptions;

/// <summary>
/// Represents a resource-not-found API error.
/// </summary>
public sealed class NotFoundException : ApiException
{
    public NotFoundException(string message)
        : base(message, ErrorCodes.NotFound, StatusCodes.Status404NotFound)
    {
    }
}
