namespace Hrithik.Api.ErrorKit.Models;

/// <summary>
/// Represents a single validation failure.
/// </summary>
public sealed class ValidationError
{
    /// <summary>
    /// Name of the invalid field.
    /// </summary>
    public string Field { get; init; }

    /// <summary>
    /// Validation error message.
    /// </summary>
    public string Message { get; init; }
}
