using Hrithik.Api.ErrorKit.Abstractions;
using Hrithik.Api.ErrorKit.Mapping;
using Microsoft.Extensions.DependencyInjection;

namespace Hrithik.Api.ErrorKit.Extensions;

/// <summary>
/// Dependency injection extensions for Api Error Kit.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers Api Error Kit services.
    /// </summary>
    public static IServiceCollection AddApiErrorKit(this IServiceCollection services)
    {
        services.AddSingleton<IApiErrorFactory, DefaultApiErrorFactory>();
        return services;
    }
}
