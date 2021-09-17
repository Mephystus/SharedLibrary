// -------------------------------------------------------------------------------------
//  <copyright file="ErrorDetail.cs" company="The AA (Ireland)">
//    Copyright (c) The AA (Ireland). All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------------------

namespace SharedLibrary.Filters.Filters;

using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SharedLibrary.Models.Models.Error;

/// <summary>
/// Filter that checks for invalid models. 
/// </summary>
public class ValidationFilter : IAsyncActionFilter
{
    /// <summary>
    /// Intercepts the execution pipeline to check for validation.
    /// </summary>
    /// <param name="context">The execution context.</param>
    /// <param name="next">The next action to be executed.</param>
    /// <returns>A <see cref="Task"/> that on completion indicates the filter has executed.</returns>
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if (!context.ModelState.IsValid)
        {
            ErrorResponse errorResponse = GetErrorResponse(context);

            context.Result = new BadRequestObjectResult(errorResponse);

            return;
        }

        await next();
    }

    /// <summary>
    /// Gets the <see cref="ErrorResponse"/> from the context.
    /// </summary>
    /// <param name="context">The executing context.</param>
    /// <returns>An instance of <see cref="ErrorResponse"/></returns>
    private static ErrorResponse GetErrorResponse(ActionExecutingContext context)
    {
        var errors = context.ModelState
            .Where(x => x.Value.Errors.Count > 0)
            .ToDictionary(x => x.Key, x => x.Value.Errors.Select(x => x.ErrorMessage)).ToList();

        var errorResponse = new ErrorResponse
        {
            StatusCode = StatusCodes.Status400BadRequest
        };

        foreach (var error in errors)
        {
            foreach (var detail in error.Value)
            {
                errorResponse.Details.Add(new ErrorDetail
                {
                    FieldName = error.Key,
                    Message = detail
                });
            }
        }

        return errorResponse;
    }
}
 
