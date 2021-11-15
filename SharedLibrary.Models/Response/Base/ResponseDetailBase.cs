// -------------------------------------------------------------------------------------
//  <copyright file="ResponseDetailBase.cs" company="The AA (Ireland)">
//    Copyright (c) The AA (Ireland). All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------------------

namespace SharedLibrary.Models.Response.Base;

/// <summary>
/// Defines the base class for the response detail.
/// </summary>
public abstract class ResponseDetailBase
{
    #region Public Properties

    /// <summary>
    /// Gets or sets the message.
    /// </summary>
    public string Message { get; set; } = default!;

    #endregion Public Properties
}