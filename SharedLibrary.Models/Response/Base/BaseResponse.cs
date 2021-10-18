// -------------------------------------------------------------------------------------
//  <copyright file="ErrorResponse.cs" company="The AA (Ireland)">
//    Copyright (c) The AA (Ireland). All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------------------

namespace SharedLibrary.Models.Response.Base;

/// <summary>
/// Defines the base response.
/// </summary>
public abstract class BaseResponse
{
    /// <summary>
    /// Gets or sets the status code.
    /// </summary>
    public int StatusCode { get; set; }
}