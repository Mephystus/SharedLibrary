// -------------------------------------------------------------------------------------
//  <copyright file="HealthCheckDetail.cs" company="The AA (Ireland)">
//    Copyright (c) The AA (Ireland). All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------------------

namespace SharedLibrary.Models.Models.HealthCheck;

/// <summary>
/// Defines the health check detail.
/// </summary>
public class HealthCheckDetail
{
    /// <summary>
    /// Gets or sets the component.
    /// </summary>
    public string Component { get; set; }

    /// <summary>
    /// Gets or sets the description.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Gets or sets the status.
    /// </summary>
    public string Status { get; set; }
}