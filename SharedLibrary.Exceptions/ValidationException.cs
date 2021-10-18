// -------------------------------------------------------------------------------------
//  <copyright file="ValidationException.cs" company="The AA (Ireland)">
//    Copyright (c) The AA (Ireland). All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------------------

namespace SharedLibrary.Exceptions;

using System;
using System.Runtime.Serialization;

/// <summary>
/// Exception to be used when validation fails.
/// </summary>
[Serializable]
public class ValidationException : Exception
{
    /// <summary>
    /// Initialises a new instance of the <see cref="ValidationException"/> class.
    /// </summary>
    /// <param name="message">The message.</param>
    public ValidationException(string message) : base(message)
    {
        FieldName = string.Empty;
    }

    /// <summary>
    /// Initialises a new instance of the <see cref="ValidationException"/> class.
    /// </summary>
    /// <param name="message">The message.</param>
    /// <param name="fieldName">The field/property name.</param>
    public ValidationException(string message, string fieldName) : base(message)
    {
        FieldName = fieldName;
    }

    /// <summary>
    /// Initialises a new instance of the <see cref="ValidationException"/> class.
    /// </summary>
    /// <param name="fieldName">The field/property name.</param>
    /// <param name="info">An instance of <see cref="SerializationInfo"/></param>
    /// <param name="context">An instance of <see cref="StreamingContext"/></param>
    protected ValidationException(string fieldName, SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
        FieldName = fieldName;
    }

    /// <summary>
    /// Gets or sets the field name.
    /// </summary>
    public string FieldName { get; set; } = default!;
}
