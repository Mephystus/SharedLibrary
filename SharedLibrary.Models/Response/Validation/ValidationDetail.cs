// -------------------------------------------------------------------------------------
//  <copyright file="ValidationDetail.cs" company="The AA (Ireland)">
//    Copyright (c) The AA (Ireland). All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------------------

namespace SharedLibrary.Models.Models.Validation;

using SharedLibrary.Models.Response.Base;

/// <summary>
/// Defines the validation detail.
/// </summary>
public class ValidationDetail : BaseDetail
{
    /// <summary>
    /// Gets or sets the field name.
    /// </summary>
    public string FieldName { get; set; } = default!;
}

