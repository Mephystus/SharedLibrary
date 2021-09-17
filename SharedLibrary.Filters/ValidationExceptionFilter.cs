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
using SharedLibrary.Models.Models.Error;

/// <summary>
/// Exception filter to intercept <see cref="ValidationException"/>
/// </summary>
public class ValidationExceptionFilter : IAsyncExceptionFilter
{
    /// <summary>
    /// The logger.
    /// </summary>
    private readonly ILogger<ValidationExceptionFilter> _logger;

    /// <summary>
    /// Initialises a new instance of the <see cref="ValidationExceptionFilter" /> class.
    /// </summary>
    /// <param name="logger">An instance of <see cref="ILogger{ValidationExceptionFilter}"/></param>
    public ValidationExceptionFilter(ILogger<ValidationExceptionFilter> logger)
    {
        _logger = logger;
    }

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

            var errorResponse = new ErrorResponse
            {
                StatusCode = StatusCodes.Status400BadRequest
            };

            errorResponse.Details.Add(new ErrorDetail
            {
                Message = validationException.Message
            });

            context.Result = new BadRequestObjectResult(errorResponse);
            context.ExceptionHandled = true;
        }

        return Task.CompletedTask;
    }
}
