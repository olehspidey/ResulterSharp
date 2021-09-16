namespace Resulter.Http
{
    using System.Net;
    using Resulter.Abstract.Generic;
    using Extensions;
    using Resulter.Generic;
    using Generic;

    /// <summary>
    /// Represents extensions for <see cref="Resulter.ResultBase{TMessage}"/> and <see cref="Resulter.Generic.ResultBase{TData,TMessage}"/> results.
    /// </summary>
    public static class HttpResultExtensions
    {
        /// <summary>
        /// Converts <see cref="Resulter.ResultBase{TMessage}"/> to <see cref="HttpResultBase{TMessage}"/> http result with specific status code.
        /// </summary>
        /// <param name="resultBaseurce result.</param>
        /// <param name="statusCode">Http status code.</param>
        /// <typeparam name="TMessage">Type of error message.</typeparam>
        /// <returns><see cref="HttpResultBase{TMessage}"/> http result with specific status code.</returns>
        public static HttpResultBase<TMessage> ToHttpResult<TMessage>(this Result<TMessage> resultBase, HttpStatusCode statusCode)
        {
            if (resultBase is HttpResultBase<TMessage> httpResult)
                return httpResult;

            var failureResult = (IFailureResult<TMessage>)resultBase;

            return new HttpResultBase<TMessage>(resultBase.IsSuccessful, statusCode, failureResult.ErrorMessages, failureResult.Exception);
        }

        /// <summary>
        /// Converts <see cref="Resulter.Generic.ResultBase{TData,TMessage}"/> to <see cref="HttpResultBase{TData,TMessage}"/> http result with specific status code.
        /// </summary>
        /// <param name="resultBaseurce result.</param>
        /// <param name="statusCode">Http status code.</param>
        /// <typeparam name="TData">Type of data.</typeparam>
        /// <typeparam name="TMessage">Type of error message.</typeparam>
        /// <returns><see cref="Resulter.Generic.ResultBase{TData,TMessage}"/> http result with specific status code.</returns>
        public static HttpResultBase<TData, TMessage> ToHttpResult<TData, TMessage>(
            this Result<TData, TMessage> resultBase,
            HttpStatusCode statusCode)
        {
            if (resultBase is HttpResultBase<TData, TMessage> httpResult)
                return httpResult;

            if (resultBase.IsFailure(out var failureResult))
            {
                return new HttpResultBase<TData, TMessage>(
                    false,
                    statusCode,
                    default!,
                    failureResult.ErrorMessages,
                    failureResult.Exception);
            }

            return new HttpResultBase<TData, TMessage>(true, statusCode, ((ISuccessfulResult<TData>)resultBase).Data);
        }
    }
}