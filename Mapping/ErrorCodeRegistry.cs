using System;
using System.Collections.Generic;

namespace Hrithik.Api.ErrorKit.Mapping;

/// <summary>
/// Central registry mapping exception types to error codes.
/// </summary>
public static class ErrorCodeRegistry
{
    private static readonly Dictionary<Type, string> _registry = new();

    /// <summary>
    /// Registers an exception to error code mapping.
    /// </summary>
    public static void Register<TException>(string errorCode)
        where TException : Exception
    {
        _registry[typeof(TException)] = errorCode;
    }

    /// <summary>
    /// Resolves an error code for the given exception.
    /// </summary>
    public static string Resolve(Exception exception)
    {
        var type = exception.GetType();
        return _registry.TryGetValue(type, out var code)
            ? code
            : Constants.ErrorCodes.InternalError;
    }
}
