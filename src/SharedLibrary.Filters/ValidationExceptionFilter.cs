// -------------------------------------------------------------------------------------
//  <copyright file="ValidationExceptionFilter.cs" company="The AA (Ireland)">
//    Copyright (c) The AA (Ireland). All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------------------

namespace SharedLibrary.Filters.Filters;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using SharedLibrary.Exceptions;
using SharedLibrary.Models.Models.Validation;

/// <summary>
/// Exception filter to intercept <see cref="ValidationException"/>
/// </summary>
public class ValidationExceptionFilter : IAsyncExceptionFilter
{
    #region Private Fields

    /// <summary>
    /// The logger.
    /// </summary>
    private readonly ILogger<ValidationExceptionFilter> _logger;

    #endregion Private Fields

    #region Public Constructors

    /// <summary>
    /// Initialises a new instance of the <see cref="ValidationExceptionFilter" /> class.
    /// </summary>
    /// <param name="logger">An instance of <see cref="ILogger{ValidationExceptionFilter}"/></param>
    public ValidationExceptionFilter(ILogger<ValidationExceptionFilter> logger)
    {
        _logger = logger;
    }

    #endregion Public Constructors

    #region Public Methods

    /// <summary>
    /// Called after an action has thrown an System.Exception.
    /// </summary>
    /// <param name="context">The exception context</param>
    /// <returns>A Task that on completion indicates the filter has executed.</returns>
    public Task OnExceptionAsync(ExceptionContext context)
    {
        if (!context.ExceptionHandled && context.Exception is ValidationException validationException)
        {
            _logger.LogError(validationException, "Validation exception!");

            var response = new ValidationResponse
            {
                StatusCode = StatusCodes.Status400BadRequest
            };

            response.Details.Add(new ValidationResponseDetail
            {
                Message = validationException.Message,
                FieldName = validationException.FieldName
            });

            context.Result = new BadRequestObjectResult(response);
            context.ExceptionHandled = true;
        }

        return Task.CompletedTask;
    }

    #endregion Public Methods
}