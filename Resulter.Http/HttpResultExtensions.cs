namespace Resulter.Http
{
    using System.Net;
    using Resulter.Abstract.Generic;
    using Resulter.Extensions;
    using Resulter.Generic;
    using Resulter.Http.Generic;

    /// <summary>
    /// Represents extensions for <see cref="Result{TMessage}"/> and <see cref="Result{TData,TMessage}"/> results.
    /// </summary>
    public static class HttpResultExtensions
    {
        /// <summary>
        /// Converts <see cref="Result{TMessage}"/> to <see cref="HttpResult{TMessage}"/> http result with specific status code.
        /// </summary>
        /// <param name="result">Source result.</param>
        /// <param name="statusCode">Http status code.</param>
        /// <typeparam name="TMessage">Type of error message.</typeparam>
        /// <returns><see cref="HttpResult{TMessage}"/> http result with specific status code.</returns>
        public static HttpResult<TMessage> ToHttpResult<TMessage>(this Result<TMessage> result, HttpStatusCode statusCode)
        {
            if (result is HttpResult<TMessage> httpResult)
                return httpResult;

            var failureResult = (IFailureResult<TMessage>)result;

            return new HttpResult<TMessage>(result.IsSuccessful, statusCode, failureResult.ErrorMessages, failureResult.Exception);
        }

        /// <summary>
        /// Converts <see cref="Result{TData,TMessage}"/> to <see cref="HttpResult{TData,TMessage}"/> http result with specific status code.
        /// </summary>
        /// <param name="result">Source result.</param>
        /// <param name="statusCode">Http status code.</param>
        /// <typeparam name="TData">Type of data.</typeparam>
        /// <typeparam name="TMessage">Type of error message.</typeparam>
        /// <returns><see cref="Result{TData,TMessage}"/> http result with specific status code.</returns>
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