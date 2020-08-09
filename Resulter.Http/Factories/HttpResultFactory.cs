namespace Resulter.Http.Factories
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using Resulter.Http.Generic;

    /// <summary>
    /// Represents the factory for <see cref="HttpResult{TData,TMessage}"/> and <see cref="HttpResult{TMessage}"/> result objects instantiation.
    /// </summary>
    public static class HttpResultFactory
    {
        /// <summary>
        /// Creates successful <see cref="HttpResult{TMessage}"/> result with default <see cref="string"/> error messages.
        /// </summary>
        /// <param name="statusCode">Http status code.</param>
        /// <returns>Successful <see cref="HttpResult{TMessage}"/> result with default <see cref="string"/> error messages.</returns>
        public static HttpResult<string> CreateSuccess(HttpStatusCode statusCode = HttpStatusCode.OK)
            => new HttpResult<string>(true, statusCode);

        /// <summary>
        /// Creates successful <see cref="HttpResult{TMessage}"/> result.
        /// </summary>
        /// <param name="statusCode">Http status code.</param>
        /// <typeparam name="TMessage">Type of error message.</typeparam>
        /// <returns>Successful <see cref="HttpResult{TMessage}"/> result.</returns>
        public static HttpResult<TMessage> CreateSuccess<TMessage>(HttpStatusCode statusCode = HttpStatusCode.OK)
            => new HttpResult<TMessage>(true, statusCode);

        /// <summary>
        /// Creates successful <see cref="HttpResult{TData,TMessage}"/> result with <see cref="string"/> error messages.
        /// </summary>
        /// <param name="data">Type of data.</param>
        /// <param name="statusCode">Http status code.</param>
        /// <typeparam name="TData">Type of data.</typeparam>
        /// <returns>Successful <see cref="HttpResult{TData,TMessage}"/> result with <see cref="string"/> error messages.</returns>
        public static HttpResult<TData, string> CreateSuccess<TData>(TData data, HttpStatusCode statusCode = HttpStatusCode.OK)
            => new HttpResult<TData, string>(true, statusCode, data);

        /// <summary>
        /// Creates successful <see cref="HttpResult{TData,TMessage}"/> result.
        /// </summary>
        /// <param name="data">Value of data.</param>
        /// <param name="statusCode">Http status code.</param>
        /// <typeparam name="TData">Type of data.</typeparam>
        /// <typeparam name="TMessage">Type of error message.</typeparam>
        /// <returns>Successful <see cref="HttpResult{TData,TMessage}"/> result.</returns>
        public static HttpResult<TData, TMessage> CreateSuccess<TData, TMessage>(TData data, HttpStatusCode statusCode = HttpStatusCode.OK)
            => new HttpResult<TData, TMessage>(true, statusCode, data);

        /// <summary>
        /// Creates failure <see cref="HttpResult{TMessage}"/> result with default <see cref="string"/> error messages.
        /// </summary>
        /// <param name="errorMessage">Message that represent errors.</param>
        /// <param name="statusCode">Http status code.</param>
        /// <param name="exception">Exception that represents error.</param>
        /// <returns>Failure <see cref="HttpResult{TMessage}"/> result with default <see cref="string"/> error messages.</returns>
        public static HttpResult<string> CreateFailure(
            string errorMessage,
            HttpStatusCode statusCode = HttpStatusCode.BadRequest,
            Exception? exception = null)
            => new HttpResult<string>(false, statusCode, new[] { errorMessage }, exception);

        /// <summary>
        /// Creates failure <see cref="HttpResult{TMessage}"/> result with default <see cref="string"/> error messages.
        /// </summary>
        /// <param name="errorMessages">Message collection that represent errors.</param>
        /// <param name="statusCode">Http status code.</param>
        /// <param name="exception">Exception that represents error.</param>
        /// <returns>Failure <see cref="HttpResult{TMessage}"/> result with default <see cref="string"/> error messages.</returns>
        public static HttpResult<string> CreateFailure(
            IEnumerable<string> errorMessages,
            HttpStatusCode statusCode = HttpStatusCode.BadRequest,
            Exception? exception = null)
            => new HttpResult<string>(false, statusCode, errorMessages, exception);

        /// <summary>
        /// Creates failure <see cref="HttpResult{TMessage}"/> result.
        /// </summary>
        /// <param name="errorMessage">Message that represent errors.</param>
        /// <param name="statusCode">Http status code.</param>
        /// <param name="exception">Exception that represents error.</param>
        /// <typeparam name="TMessage">Type of error message.</typeparam>
        /// <returns>Failure <see cref="HttpResult{TMessage}"/> result.</returns>
        public static HttpResult<TMessage> CreateFailure<TMessage>(
            TMessage errorMessage,
            HttpStatusCode statusCode = HttpStatusCode.BadRequest,
            Exception? exception = null)
            => new HttpResult<TMessage>(false, statusCode, new[] { errorMessage }, exception);

        /// <summary>
        /// Creates failure <see cref="HttpResult{TMessage}"/> result.
        /// </summary>
        /// <param name="errorMessages">Message collection that represent errors.</param>
        /// <param name="statusCode">Http status code.</param>
        /// <param name="exception">Exception that represents error.</param>
        /// <typeparam name="TMessage">Type of error message.</typeparam>
        /// <returns>Failure <see cref="HttpResult{TMessage}"/> result.</returns>
        public static HttpResult<TMessage> CreateFailure<TMessage>(
            IEnumerable<TMessage> errorMessages,
            HttpStatusCode statusCode = HttpStatusCode.BadRequest,
            Exception? exception = null)
            => new HttpResult<TMessage>(false, statusCode, errorMessages, exception);

        /// <summary>
        /// Creates failure <see cref="HttpResult{TData,TMessage}"/> result.
        /// </summary>
        /// <param name="errorMessage">Message that represent errors.</param>
        /// <param name="statusCode">Http status code.</param>
        /// <param name="exception">Exception that represents error.</param>
        /// <typeparam name="TData">Type of data.</typeparam>
        /// <typeparam name="TMessage">Type of error message.</typeparam>
        /// <returns>Failure <see cref="HttpResult{TData,TMessage}"/> result.</returns>
        public static HttpResult<TData, TMessage> CreateFailure<TData, TMessage>(
            TMessage errorMessage,
            HttpStatusCode statusCode = HttpStatusCode.BadRequest,
            Exception? exception = null)
            => new HttpResult<TData, TMessage>(
                false,
                statusCode,
                default!,
                new[] { errorMessage },
                exception);

        /// <summary>
        /// Creates failure <see cref="HttpResult{TData,TMessage}"/> result.
        /// </summary>
        /// <param name="errorMessages">Message collection that represent errors.</param>
        /// <param name="statusCode">Http status code.</param>
        /// <param name="exception">Exception that represents error.</param>
        /// <typeparam name="TData">Type of data.</typeparam>
        /// <typeparam name="TMessage">Type of error message.</typeparam>
        /// <returns>Failure <see cref="HttpResult{TData,TMessage}"/> result.</returns>
        public static HttpResult<TData, TMessage> CreateFailure<TData, TMessage>(
            IEnumerable<TMessage> errorMessages,
            HttpStatusCode statusCode = HttpStatusCode.BadRequest,
            Exception? exception = null)
            => new HttpResult<TData, TMessage>(false, statusCode, default!, errorMessages, exception);
    }
}