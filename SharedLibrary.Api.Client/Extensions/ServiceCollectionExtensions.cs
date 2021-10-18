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
}