// -------------------------------------------------------------------------------------
//  <copyright file="NotFoundException.cs" company="The AA (Ireland)">
//    Copyright (c) The AA (Ireland). All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------------------

namespace SharedLibrary.Exceptions;

using System;

/// <summary>
/// Exception to be used when a particular entity is not found.
/// </summary>
[Serializable]
public class NotFoundException : Exception
{
    #region Public Constructors

    /// <summary>
    /// Initialises a new instance of the <see cref="NotFoundException"/> class.
    /// </summary>
    /// <param name="message">The message.</param>
    public NotFoundException(string message) : base(message)
    {
    }

    #endregion Public Constructors

}