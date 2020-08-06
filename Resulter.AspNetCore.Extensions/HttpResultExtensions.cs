namespace Resulter.AspNetCore
{
    using System;
    using Microsoft.AspNetCore.Mvc;
    using Resulter.Extensions;
    using Resulter.Http;
    using Resulter.Http.Generic;

    public static class HttpResultExtensions
    {
        public static IActionResult ToActionResult<TMessage>(this HttpResult<TMessage> result)
            => new StatusCodeResult((int)result.StatusCode);

        public static IActionResult ToActionResult<TData, TMessage>(this HttpResult<TData, TMessage> result)
        {
            if (result.IsSuccessful(out var successfulResult))
            {
                return new ObjectResult(successfulResult)
                {
                    StatusCode = (int)result.StatusCode,
                };
            }

            if (result.IsFailure(out var failureResult))
            {
                return new ObjectResult(failureResult.ErrorMessages)
                {
                    StatusCode = (int)result.StatusCode,
                };
            }

            throw new ApplicationException();
        }
    }
}