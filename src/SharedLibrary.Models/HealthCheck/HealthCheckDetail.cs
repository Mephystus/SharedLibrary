// -------------------------------------------------------------------------------------
//  <copyright file="HealthCheckDetail.cs" company="The AA (Ireland)">
//    Copyright (c) The AA (Ireland). All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------------------

namespace SharedLibrary.Models.HealthCheck;

/// <summary>
/// Defines the health check detail.
/// </summary>
public class HealthCheckDetail
{
    #region Public Properties

    /// <summary>
    /// Gets or sets the component.
    /// </summary>
    public string Component { get; set; } = default!;

    /// <summary>
    /// Gets or sets the description.
    /// </summary>
    public string Description { get; set; } = default!;

    /// <summary>
    /// Gets or sets the status.
    /// </summary>
    public string Status { get; set; } = default!;

    #endregion Public Properties
}