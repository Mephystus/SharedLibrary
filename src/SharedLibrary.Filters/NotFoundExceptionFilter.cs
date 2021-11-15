// -------------------------------------------------------------------------------------
//  <copyright file="NotFoundExceptionFilter.cs" company="The AA (Ireland)">
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
/// Exception filter to intercept <see cref="NotFoundException"/>
/// </summary>
public class NotFoundExceptionFilter : IAsyncExceptionFilter
{
    #region Private Fields

    /// <summary>
    /// The logger.
    /// </summary>
    private readonly ILogger<NotFoundExceptionFilter> _logger;

    #endregion Private Fields

    #region Public Constructors

    /// <summary>
    /// Initialises a new instance of the <see cref="NotFoundExceptionFilter" /> class.
    /// </summary>
    /// <param name="logger">An instance of <see cref="ILogger{NotFoundExceptionFilter}"/></param>
    public NotFoundExceptionFilter(ILogger<NotFoundExceptionFilter> logger)
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
        if (!context.ExceptionHandled && context.Exception is NotFoundException notFoundException)
        {
            _logger.LogError(notFoundException, "Not found exception!");

            var response = new ErrorResponse
            {
                StatusCode = StatusCodes.Status404NotFound
            };

            response.Details.Add(new ErrorResponseDetail
            {
                Message = notFoundException.Message
            });

            context.Result = new NotFoundObjectResult(response);
            context.ExceptionHandled = true;
        }

        return Task.CompletedTask;
    }

    #endregion Public Methods
}