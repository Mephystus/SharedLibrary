// -------------------------------------------------------------------------------------
//  <copyright file="UnhandledExceptionFilter.cs" company="The AA (Ireland)">
//    Copyright (c) The AA (Ireland). All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------------------

namespace SharedLibrary.Filters.Filters;

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using SharedLibrary.Models.Models.Error;

public class UnhandledExceptionFilter : IAsyncExceptionFilter
{
    /// <summary>
    /// The logger.
    /// </summary>
    private readonly ILogger<UnhandledExceptionFilter> _logger;

    /// <summary>
    /// Initialises a new instance of the <see cref="UnhandledExceptionFilter" /> class.
    /// </summary>
    /// <param name="logger">An instance of <see cref="ILogger{UnhandledExceptionFilter}"/></param>
    public UnhandledExceptionFilter(ILogger<UnhandledExceptionFilter> logger)
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
        if (!context.ExceptionHandled && context.Exception is Exception exception)
        {
            _logger.LogError(exception, "Unhandled exception!");

            var errorResponse = new ErrorResponse
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };

            errorResponse.Details.Add(new ErrorDetail
            {
                Message = "An error occurred, please try again later."
            });

            context.Result = new ObjectResult(errorResponse) 
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };
   
            context.ExceptionHandled = true;
        }

        return Task.CompletedTask;
    }
}
