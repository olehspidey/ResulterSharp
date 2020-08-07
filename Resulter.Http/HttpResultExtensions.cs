namespace Resulter.Http
{
    using System.Net;
    using Resulter.Abstract.Generic;
    using Resulter.Extensions;
    using Resulter.Generic;
    using Resulter.Http.Generic;

    public static class HttpResultExtensions
    {
        public static HttpResult<TMessage> ToHttpResult<TMessage>(this Result<TMessage> result, HttpStatusCode statusCode)
        {
            if (result is HttpResult<TMessage> httpResult)
                return httpResult;

            var failureResult = (IFailureResult<TMessage>)result;

            return new HttpResult<TMessage>(result.IsSuccessful, statusCode, failureResult.ErrorMessages, failureResult.Exception);
        }

        public static HttpResult<TData, TMessage> ToHttpResult<TData, TMessage>(
            this Result<TData, TMessage> result,
            HttpStatusCode statusCode)
        {
            if (result is HttpResult<TData, TMessage> httpResult)
                return httpResult;

            if (result.IsFailure(out var failureResult))
            {
                return new HttpResult<TData, TMessage>(
                    false,
                    statusCode,
                    default!,
                    failureResult.ErrorMessages,
                    failureResult.Exception);
            }

            return new HttpResult<TData, TMessage>(true, statusCode, ((ISuccessfulResult<TData>)result).Data);
        }
    }
}