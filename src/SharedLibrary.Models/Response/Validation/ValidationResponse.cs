// -------------------------------------------------------------------------------------
//  <copyright file="ValidationResponse.cs" company="The AA (Ireland)">
//    Copyright (c) The AA (Ireland). All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------------------

namespace SharedLibrary.Models.Models.Validation;

using SharedLibrary.Models.Response.Base;

/// <summary>
/// Defines the validation response.
/// </summary>
public class ValidationResponse : ResponseBase
{
    #region Public Properties

    /// <summary>
    /// Gets or sets the error details.
    /// </summary>
    public List<ValidationResponseDetail> Details { get; set; } = new List<ValidationResponseDetail>();

    #endregion Public Properties
}