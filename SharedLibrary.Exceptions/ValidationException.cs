// -------------------------------------------------------------------------------------
//  <copyright file="ValidationException.cs" company="The AA (Ireland)">
//    Copyright (c) The AA (Ireland). All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------------------

namespace SharedLibrary.Exceptions;

using System;
using System.Globalization;

/// <summary>
/// Service exception to be used when a particular entity is not found.
/// </summary>
public class ValidationException : Exception
{
    /// <summary>
    /// Initialises a new instance of the <see cref="ValidationException"/> class.
    /// </summary>
    public ValidationException()
    {
    }

    /// <summary>
    /// Initialises a new instance of the <see cref="ValidationException"/> class.
    /// </summary>
    /// <param name="message">The message.</param>
    public ValidationException(string message) : base(message)
    {
    }

    /// <summary>
    /// Initialises a new instance of the <see cref="ValidationException"/> class.
    /// </summary>
    /// <param name="message">The message.</param>
    /// <param name="args">The arguments.</param>
    public ValidationException(string message, params object[] args)
        : base(string.Format(CultureInfo.CurrentCulture, message, args))
    {
    }
}
