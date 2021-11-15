// -------------------------------------------------------------------------------------
//  <copyright file="ServiceCollectionExtensions.cs" company="The AA (Ireland)">
//    Copyright (c) The AA (Ireland). All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------------------

namespace SharedLibrary.Api.Client.Extensions;

using Microsoft.Extensions.DependencyInjection;
using Polly;
using SharedLibrary.Api.Client.Configuration;

/// <summary>
/// Provides extension methods for the <see cref="IServiceCollection"/>.
/// </summary>
public static class ServiceCollectionExtensions
{
    #region Public Methods

    /// <summary>
    /// Adds the customer API client into the DI pipeline.
    /// </summary>
    /// <param name="services">The service collections.</param>
    /// <param name="clientSettingsDictionary">The collection of HTTP client settings.</param>
    /// <param name="key">The key for the client settings dictionary.</param>
    /// <returns>An instance of <see cref="IServiceCollection"/>.</returns>
    public static IServiceCollection AddHttpClient<TClient, TImplementation>(
        this IServiceCollection services,
        Dictionary<string, HttpClientSettings> clientSettingsDictionary,
        string key)
        where TClient : class
        where TImplementation : class, TClient
    {
        if (!clientSettingsDictionary.ContainsKey(key))
        {
            throw new ArgumentException($"Could not find the key '{key}' in the dictionary '{nameof(clientSettingsDictionary)}'", key);
        }

        var clientSettings = clientSettingsDictionary[key];

        services.AddHttpClient<TClient, TImplementation>(clientSettings);

        return services;
    }

    /// <summary>
    /// Adds the HTTP client into the DI pipeline.
    /// </summary>
    /// <typeparam name="TClient">The contract type.</typeparam>
    /// <typeparam name="TImplementation">The implementation type.</typeparam>
    /// <param name="services">The service collection</param>
    /// <param name="clientSettings">The HTTP client settings.</param>
    /// <returns>An instance of <see cref="IHttpClientBuilder"/></returns>
    public static IHttpClientBuilder AddHttpClient<TClient, TImplementation>(
        this IServiceCollection services,
        HttpClientSettings clientSettings)
        where TClient : class
        where TImplementation : class, TClient
    {
        IHttpClientBuilder builder = services.AddHttpClient<TClient, TImplementation>(
            clientSettings.BaseUrl,
            client =>
            {
                client.BaseAddress = new Uri(clientSettings.BaseUrl);

                if (clientSettings.RequestHeaders != null)
                {
                    foreach (var header in clientSettings.RequestHeaders)
                    {
                        client.DefaultRequestHeaders.Add(header.Key, header.Value);
                    }
                }
            });

        var circuitBreaker = clientSettings.CircuitBreaker;

        if (circuitBreaker?.Enabled ?? false)
        {
            builder.AddTransientHttpErrorPolicy(policy =>
                policy.CircuitBreakerAsync(
                    circuitBreaker.EventsBeforeBreak,
                    TimeSpan.FromSeconds(circuitBreaker.BreakDurationInSeconds)));
        }

        var retry = clientSettings.Retry;

        if (retry?.Enabled ?? false)
        {
            builder.AddTransientHttpErrorPolicy(policy =>
                policy.WaitAndRetryAsync(
                    retry.NumberOfRetries,
                    retryAttempt => retry.GetSleepDuration(retryAttempt)));
        }

        var timeout = clientSettings.Timeout;

        if (timeout?.Enabled ?? false)
        {
            builder.AddPolicyHandler(
                Policy.TimeoutAsync<HttpResponseMessage>(
                    timeout.TimeoutInSeconds,
                    timeout.TimeoutStrategy));
        }

        return builder;
    }

    #endregion Public Methods
}