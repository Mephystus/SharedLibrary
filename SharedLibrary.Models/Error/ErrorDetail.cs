// -------------------------------------------------------------------------------------
//  <copyright file="ErrorDetail.cs" company="The AA (Ireland)">
//    Copyright (c) The AA (Ireland). All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------------------

namespace SharedLibrary.Models.Models.Error;

/// <summary>
/// Defines the error detail.
/// </summary>
public class ErrorDetail
{
    /// <summary>
    /// Gets or sets the field name.
    /// </summary>
    public string FieldName { get; set; }

    /// <summary>
    /// Gets or sets the message.
    /// </summary>
    public string Message { get; set; }
}

