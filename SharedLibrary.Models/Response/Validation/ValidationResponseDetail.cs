// -------------------------------------------------------------------------------------
//  <copyright file="ValidationResponseDetail.cs" company="The AA (Ireland)">
//    Copyright (c) The AA (Ireland). All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------------------

namespace SharedLibrary.Models.Models.Validation;

using SharedLibrary.Models.Response.Base;

/// <summary>
/// Defines the validation response detail.
/// </summary>
public class ValidationResponseDetail : ResponseDetailBase
{
    #region Public Properties

    /// <summary>
    /// Gets or sets the field name.
    /// </summary>
    public string FieldName { get; set; } = default!;

    #endregion Public Properties
}