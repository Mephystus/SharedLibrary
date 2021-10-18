// -------------------------------------------------------------------------------------
//  <copyright file="ErrorResponse.cs" company="The AA (Ireland)">
//    Copyright (c) The AA (Ireland). All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------------------

namespace SharedLibrary.Models.Models.Error;

using SharedLibrary.Models.Response.Base;

/// <summary>
/// Defines the error response.
/// </summary>
public class ErrorResponse : BaseResponse
{
    /// <summary>
    /// Gets or sets the error details.
    /// </summary>
    public List<ErrorDetail> Details { get; set; } = new List<ErrorDetail>();
}
 
