// -------------------------------------------------------------------------------------
//  <copyright file="ErrorResponse.cs" company="The AA (Ireland)">
//    Copyright (c) The AA (Ireland). All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------------------

namespace SharedLibrary.Models.Models.Error;

/// <summary>
/// Defines the error response.
/// </summary>
public class ErrorResponse
{

    /// <summary>
    /// Gets or sets the error details.
    /// </summary>
    public List<ErrorDetail> Details { get; set; } = new List<ErrorDetail>();

    /// <summary>
    /// Gets or sets the status code.
    /// </summary>
    public int StatusCode { get; set; }
}
 
