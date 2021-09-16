namespace Resulter.AspNetCore
{
    using System;
    using System.Net;
    using Microsoft.AspNetCore.Mvc;
    using Resulter.Abstract.Generic;
    using Extensions;
    using Http;
    using Resulter.Http.Generic;

    public static class HttpResultExtensions
    {
        public static IActionResult ToActionResult<TMessage>(this HttpResult<TMessage> resultBase)
        {
            if (resultBase.IsFailure(out var failureResult))
            {
                return failureResult.MapFailureResultToObjectResult(resultBase.StatusCode);
            }

            return new StatusCodeResult((int)resultBase.StatusCode);
        }

        public static IActionResult ToActionResult<TData, TMessage>(this HttpResult<TData, TMessage> resultBase)
        {
            if (resultBase.IsFailure(out var failureResult))
            {
                return failureResult.MapFailureResultToObjectResult(resultBase.StatusCode);
            }

            if (resultBase.IsSuccessful(out var data))
            {
                return new ObjectResult(data)
                {
                    DeclaredType = typeof(ISuccessfulResult<TData>),
                    StatusCode = (int)resultBase.StatusCode,
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