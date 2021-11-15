// -------------------------------------------------------------------------------------
//  <copyright file="ResponseBase.cs" company="The AA (Ireland)">
//    Copyright (c) The AA (Ireland). All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------------------

namespace SharedLibrary.Models.Response.Base;

/// <summary>
/// Defines the base class for the response.
/// </summary>
public abstract class ResponseBase
{
    #region Public Properties

    /// <summary>
    /// Gets or sets the status code.
    /// </summary>
    public int StatusCode { get; set; }

    #endregion Public Properties
}