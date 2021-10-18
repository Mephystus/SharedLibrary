// -------------------------------------------------------------------------------------
//  <copyright file="HealthCheckResponse.cs" company="The AA (Ireland)">
//    Copyright (c) The AA (Ireland). All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------------------

namespace SharedLibrary.Models.HealthCheck;

/// <summary>
/// Defines the health check detail.
/// </summary>
public class HealthCheckResponse
{
    /// <summary>
    /// Gets or sets the details.
    /// </summary>
    public IEnumerable<HealthCheckDetail> Details { get; set; } = default!;

    /// <summary>
    /// Gets or sets the duration.
    /// </summary>
    public TimeSpan Duration { get; set; }

    /// <summary>
    /// Gets or sets the status.
    /// </summary>
    public string Status { get; set; } = default!;
}
