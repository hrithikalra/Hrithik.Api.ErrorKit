namespace Hrithik.Api.ErrorKit.Models;

/// <summary>
/// Represents a granular sub-error within an API error.
/// </summary>
public sealed class ApiSubError
{
    /// <summary>
    /// Machine-readable sub-error code.
    /// </summary>
    public string Code { get; init; }

    /// <summary>
    /// Human-readable sub-error message.
    /// </summary>
    public string Message { get; init; }
}
