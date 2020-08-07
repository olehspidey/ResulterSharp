namespace Resulter.AspNetCore
{
    using System;
    using System.Net;
    using Microsoft.AspNetCore.Mvc;
    using Resulter.Abstract.Generic;
    using Resulter.Extensions;
    using Resulter.Http;
    using Resulter.Http.Generic;

    public static class HttpResultExtensions
    {
        public static IActionResult ToActionResult<TMessage>(this HttpResult<TMessage> result)
        {
            if (result.IsFailure(out var failureResult))
            {
                return failureResult.MapFailureResultToObjectResult(result.StatusCode);
            }

            return new StatusCodeResult((int)result.StatusCode);
        }

        public static IActionResult ToActionResult<TData, TMessage>(this HttpResult<TData, TMessage> result)
        {
            if (result.IsFailure(out var failureResult))
            {
                return failureResult.MapFailureResultToObjectResult(result.StatusCode);
            }

            if (result.IsSuccessful(out var data))
            {
                return new ObjectResult(data)
                {
                    DeclaredType = typeof(ISuccessfulResult<TData>),
                    StatusCode = (int)result.StatusCode,
                };
            }

            throw new ApplicationException();
        }

        private static ObjectResult MapFailureResultToObjectResult<TMessage>(this IFailureResult<TMessage> failureResult, HttpStatusCode statusCode)
            => new ObjectResult(new ErrorModel<TMessage>(failureResult.ErrorMessages))
            {
                StatusCode = (int)statusCode,
                DeclaredType = typeof(IFailureResult<TMessage>),
            };
    }
}