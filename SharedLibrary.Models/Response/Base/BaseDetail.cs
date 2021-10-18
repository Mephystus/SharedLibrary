// -------------------------------------------------------------------------------------
//  <copyright file="BaseDetail.cs" company="The AA (Ireland)">
//    Copyright (c) The AA (Ireland). All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------------------

namespace SharedLibrary.Models.Response.Base;

/// <summary>
/// Defines the base detail.
/// </summary>
public abstract class BaseDetail
{
    /// <summary>
    /// Gets or sets the message.
    /// </summary>
    public string Message { get; set; } = default!;
}