﻿// -------------------------------------------------------------------------------------
//  <copyright file="ValidationResponse.cs" company="The AA (Ireland)">
//    Copyright (c) The AA (Ireland). All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------------------

namespace SharedLibrary.Models.Models.Validation;

using SharedLibrary.Models.Response.Base;

/// <summary>
/// Defines the validation response.
/// </summary>
public class ValidationResponse : BaseResponse
{
    /// <summary>
    /// Gets or sets the error details.
    /// </summary>
    public List<ValidationDetail> Details { get; set; } = new List<ValidationDetail>();
}
 
