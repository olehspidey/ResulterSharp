namespace Resulter.AspNetCore
{
    using System;
    using Extensions;
    using Generic;
    using Microsoft.AspNetCore.Mvc;

    public static class ResultExtensions
    {
        public static IActionResult ToIActionResult<TData>(this Result<TData> result)
        {
            if (result.IsFailure(out var failureResult))
            {
                return new BadRequestObjectResult(failureResult.ErrorMessages);
            }

            return new OkResult();
        }

        public static IActionResult ToIActionResult<TData, TMessage>(this Result<TData, TMessage> result)
        {
            if (result.IsFailure(out var failureResult))
            {
                return new BadRequestObjectResult(failureResult.ErrorMessages);
            }

            if (result.IsSuccessful(out var data))
            {
                return new OkObjectResult(data);
            }

            throw new ApplicationException();
        }
        
        public static ActionResult ToActionBaseResult<TData>(this Result<TData> result)
        {
            if (result.IsFailure(out var failureResult))
            {
                return new BadRequestObjectResult(failureResult.ErrorMessages);
            }

            return new OkResult();
        }

        public static ActionResult ToActionBaseResult<TData, TMessage>(this Result<TData, TMessage> result)
        {
            if (result.IsFailure(out var failureResult))
            {
                return new BadRequestObjectResult(failureResult.ErrorMessages);
            }

            if (result.IsSuccessful(out var data))
            {
                return new OkObjectResult(data);
            }

            throw new ApplicationException();
        }
        
        public static ActionResult<TMessage> ToActionResult<TMessage>(this Result<TMessage> result)
        {
            if (result.IsFailure(out var failureResult))
            {
                return new BadRequestObjectResult(failureResult.ErrorMessages);
            }

            return new OkResult();
        }

        public static ActionResult<TData> ToActionResult<TData, TMessage>(this Result<TData, TMessage> result)
        {
            if (result.IsFailure(out var failureResult))
            {
                return new BadRequestObjectResult(failureResult.ErrorMessages);
            }

            if (result.IsSuccessful(out var data))
            {
                return new OkObjectResult(data);
            }

            throw new ApplicationException();
        }
    }
}