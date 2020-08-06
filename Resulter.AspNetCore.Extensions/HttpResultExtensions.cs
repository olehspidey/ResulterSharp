﻿namespace Resulter.AspNetCore
{
    using System;
    using Extensions;
    using Http;
    using Http.Generic;
    using Microsoft.AspNetCore.Mvc;

    public static class HttpResultExtensions
    {
        public static IActionResult ToActionResult<TMessage>(this HttpResult<TMessage> result)
            => new StatusCodeResult((int) result.StatusCode);

        public static IActionResult ToActionResult<TData, TMessage>(this HttpResult<TData, TMessage> result)
        {
            if (result.IsSuccessful(out var successfulResult))
            {
                return new ObjectResult(successfulResult)
                {
                    StatusCode = (int) result.StatusCode,
                };
            }

            if (result.IsFailure(out var failureResult))
            {
                return new ObjectResult(failureResult.Messages)
                {
                    StatusCode = (int) result.StatusCode,
                };
            }

            throw new ApplicationException();
        }
    }
}