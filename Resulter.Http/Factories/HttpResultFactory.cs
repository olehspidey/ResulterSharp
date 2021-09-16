namespace Resulter.Http.Factories
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using Generic;

    /// <summary>
    /// Represents the factory for <see cref="HttpResultBase{TData,TMessage}"/> and <see cref="HttpResultBase{TMessage}"/> result objects instantiation.
    /// </summary>
    public static class HttpResultFactory
    {
        /// <summary>
        /// Creates successful <see cref="HttpResultBase{TMessage}"/> result with default <see cref="string"/> error messages.
        /// </summary>
        /// <param name="statusCode">Http status code.</param>
        /// <returns>Successful <see cref="HttpResultBase{TMessage}"/> result with default <see cref="string"/> error messages.</returns>
        public static HttpResultBase<string> CreateSuccess(HttpStatusCode statusCode = HttpStatusCode.OK)
            => new HttpResultBase<string>(true, statusCode);

        /// <summary>
        /// Creates successful <see cref="HttpResultBase{TMessage}"/> result.
        /// </summary>
        /// <param name="statusCode">Http status code.</param>
        /// <typeparam name="TMessage">Type of error message.</typeparam>
        /// <returns>Successful <see cref="HttpResultBase{TMessage}"/> result.</returns>
        public static HttpResultBase<TMessage> CreateSuccess<TMessage>(HttpStatusCode statusCode = HttpStatusCode.OK)
            => new HttpResultBase<TMessage>(true, statusCode);

        /// <summary>
        /// Creates successful <see cref="HttpResultBase{TData,TMessage}"/> result with <see cref="string"/> error messages.
        /// </summary>
        /// <param name="data">Type of data.</param>
        /// <param name="statusCode">Http status code.</param>
        /// <typeparam name="TData">Type of data.</typeparam>
        /// <returns>Successful <see cref="HttpResultBase{TData,TMessage}"/> result with <see cref="string"/> error messages.</returns>
        public static HttpResultBase<TData, string> CreateSuccess<TData>(TData data, HttpStatusCode statusCode = HttpStatusCode.OK)
            => new HttpResultBase<TData, string>(true, statusCode, data);

        /// <summary>
        /// Creates successful <see cref="HttpResultBase{TData,TMessage}"/> result.
        /// </summary>
        /// <param name="data">Value of data.</param>
        /// <param name="statusCode">Http status code.</param>
        /// <typeparam name="TData">Type of data.</typeparam>
        /// <typeparam name="TMessage">Type of error message.</typeparam>
        /// <returns>Successful <see cref="HttpResultBase{TData,TMessage}"/> result.</returns>
        public static HttpResultBase<TData, TMessage> CreateSuccess<TData, TMessage>(TData data, HttpStatusCode statusCode = HttpStatusCode.OK)
            => new HttpResultBase<TData, TMessage>(true, statusCode, data);

        /// <summary>
        /// Creates failure <see cref="HttpResultBase{TMessage}"/> result with default <see cref="string"/> error messages.
        /// </summary>
        /// <param name="errorMessage">Message that represent errors.</param>
        /// <param name="statusCode">Http status code.</param>
        /// <param name="exception">Exception that represents error.</param>
        /// <returns>Failure <see cref="HttpResultBase{TMessage}"/> result with default <see cref="string"/> error messages.</returns>
        public static HttpResultBase<string> CreateFailure(
            string errorMessage,
            HttpStatusCode statusCode = HttpStatusCode.BadRequest,
            Exception? exception = null)
            => new HttpResultBase<string>(false, statusCode, new[] { errorMessage }, exception);

        /// <summary>
        /// Creates failure <see cref="HttpResultBase{TMessage}"/> result with default <see cref="string"/> error messages.
        /// </summary>
        /// <param name="errorMessages">Message collection that represent errors.</param>
        /// <param name="statusCode">Http status code.</param>
        /// <param name="exception">Exception that represents error.</param>
        /// <returns>Failure <see cref="HttpResultBase{TMessage}"/> result with default <see cref="string"/> error messages.</returns>
        public static HttpResultBase<string> CreateFailure(
            IEnumerable<string> errorMessages,
            HttpStatusCode statusCode = HttpStatusCode.BadRequest,
            Exception? exception = null)
            => new HttpResultBase<string>(false, statusCode, errorMessages, exception);

        /// <summary>
        /// Creates failure <see cref="HttpResultBase{TMessage}"/> result.
        /// </summary>
        /// <param name="errorMessage">Message that represent errors.</param>
        /// <param name="statusCode">Http status code.</param>
        /// <param name="exception">Exception that represents error.</param>
        /// <typeparam name="TMessage">Type of error message.</typeparam>
        /// <returns>Failure <see cref="HttpResultBase{TMessage}"/> result.</returns>
        public static HttpResultBase<TMessage> CreateFailure<TMessage>(
            TMessage errorMessage,
            HttpStatusCode statusCode = HttpStatusCode.BadRequest,
            Exception? exception = null)
            => new HttpResultBase<TMessage>(false, statusCode, new[] { errorMessage }, exception);

        /// <summary>
        /// Creates failure <see cref="HttpResultBase{TMessage}"/> result.
        /// </summary>
        /// <param name="errorMessages">Message collection that represent errors.</param>
        /// <param name="statusCode">Http status code.</param>
        /// <param name="exception">Exception that represents error.</param>
        /// <typeparam name="TMessage">Type of error message.</typeparam>
        /// <returns>Failure <see cref="HttpResultBase{TMessage}"/> result.</returns>
        public static HttpResultBase<TMessage> CreateFailure<TMessage>(
            IEnumerable<TMessage> errorMessages,
            HttpStatusCode statusCode = HttpStatusCode.BadRequest,
            Exception? exception = null)
            => new HttpResultBase<TMessage>(false, statusCode, errorMessages, exception);

        /// <summary>
        /// Creates failure <see cref="HttpResultBase{TData,TMessage}"/> result.
        /// </summary>
        /// <param name="errorMessage">Message that represent errors.</param>
        /// <param name="statusCode">Http status code.</param>
        /// <param name="exception">Exception that represents error.</param>
        /// <typeparam name="TData">Type of data.</typeparam>
        /// <typeparam name="TMessage">Type of error message.</typeparam>
        /// <returns>Failure <see cref="HttpResultBase{TData,TMessage}"/> result.</returns>
        public static HttpResultBase<TData, TMessage> CreateFailure<TData, TMessage>(
            TMessage errorMessage,
            HttpStatusCode statusCode = HttpStatusCode.BadRequest,
            Exception? exception = null)
            => new HttpResultBase<TData, TMessage>(
                false,
                statusCode,
                default!,
                new[] { errorMessage },
                exception);

        /// <summary>
        /// Creates failure <see cref="HttpResultBase{TData,TMessage}"/> result.
        /// </summary>
        /// <param name="errorMessages">Message collection that represent errors.</param>
        /// <param name="statusCode">Http status code.</param>
        /// <param name="exception">Exception that represents error.</param>
        /// <typeparam name="TData">Type of data.</typeparam>
        /// <typeparam name="TMessage">Type of error message.</typeparam>
        /// <returns>Failure <see cref="HttpResultBase{TData,TMessage}"/> result.</returns>
        public static HttpResultBase<TData, TMessage> CreateFailure<TData, TMessage>(
            IEnumerable<TMessage> errorMessages,
            HttpStatusCode statusCode = HttpStatusCode.BadRequest,
            Exception? exception = null)
            => new HttpResultBase<TData, TMessage>(false, statusCode, default!, errorMessages, exception);
    }
}