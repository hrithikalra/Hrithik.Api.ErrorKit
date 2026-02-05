using Hrithik.Api.ErrorKit.Models;
using Microsoft.AspNetCore.Http;
using System;

namespace Hrithik.Api.ErrorKit.Abstractions;

/// <summary>
/// Factory responsible for converting exceptions into API error responses.
/// </summary>
public interface IApiErrorFactory
{
    /// <summary>
    /// Creates an <see cref="ApiError"/> from an exception and HTTP context.
    /// </summary>
    ApiError Create(Exception exception, HttpContext context);
}
