namespace Resulter.Factories
{
    using System;
    using System.Collections.Generic;
    using Resulter.Generic;

    /// <summary>
    /// Represents the factory for result object instantiation.
    /// </summary>
    public static class ResultFactory
    {
        /// <summary>
        /// Creates successful result with <see cref="string"/> error messages.
        /// </summary>
        /// <returns>Successful result.</returns>
        public static Result<string> CreateSuccess()
            => new Result<string>(true);

        /// <summary>
        /// Creates successful result.
        /// </summary>
        /// <typeparam name="TMessage">Type of error message.</typeparam>
        /// <returns>Successful result.</returns>
        public static Result<TMessage> CreateSuccess<TMessage>()
            => new Result<TMessage>(true);

        /// <summary>
        /// Creates successful result.
        /// </summary>
        /// <param name="data">Value of data.</param>
        /// <typeparam name="TData">Type of data.</typeparam>
        /// <typeparam name="TMessage">Type of error messages.</typeparam>
        /// <returns>Successful result.</returns>
        public static Result<TData, TMessage> CreateSuccess<TData, TMessage>(TData data)
            => new Result<TData, TMessage>(true, data);

        /// <summary>
        /// Creates successful result with default <value>string</value> error messages.
        /// </summary>
        /// <param name="data">Value of data.</param>
        /// <typeparam name="TData">Type of data.</typeparam>
        /// <returns>Successful result.</returns>
        public static Result<TData, string> CreateSuccess<TData>(TData data)
            => new Result<TData, string>(true, data);

        /// <summary>
        /// Creates failure result with default <value>string</value> error messages.
        /// </summary>
        /// <param name="errorMessage">Message that represents error.</param>
        /// <param name="exception">Exception that represents error.</param>
        /// <returns>Failure error.</returns>
        public static Result<string> CreateFailure(string errorMessage, Exception? exception = null)
            => new Result<string>(false, new[] { errorMessage }, exception);

        /// <summary>
        /// Creates failure result with default <value>string</value> error messages.
        /// </summary>
        /// <param name="errorMessages">Messages that represent errors.</param>
        /// <param name="exception">Exception that represents error.</param>
        /// <returns>Failure error.</returns>
        public static Result<string> CreateFailure(IEnumerable<string> errorMessages, Exception? exception = null)
            => new Result<string>(false, errorMessages, exception);

        /// <summary>
        /// Creates failure result.
        /// </summary>
        /// <param name="errorMessage">Message that represents error.</param>
        /// <param name="exception">Exception that represents error.</param>
        /// <typeparam name="TMessage">Type of error message.</typeparam>
        /// <returns>Failure error.</returns>
        public static Result<TMessage> CreateFailure<TMessage>(TMessage errorMessage, Exception? exception = null)
            => new Result<TMessage>(false, new[] { errorMessage }, exception);

        /// <summary>
        /// Creates failure result.
        /// </summary>
        /// <param name="errorMessages">Messages that represent errors.</param>
        /// <param name="exception">Exception that represents error.</param>
        /// <typeparam name="TMessage">Type of error message.</typeparam>
        /// <returns>Failure error.</returns>
        public static Result<TMessage> CreateFailure<TMessage>(IEnumerable<TMessage> errorMessages, Exception? exception = null)
            => new Result<TMessage>(false, errorMessages, exception);

        /// <summary>
        /// Creates failure result.
        /// </summary>
        /// <param name="errorMessage">Message that represents error.</param>
        /// <param name="exception">Exception that represents error.</param>
        /// <typeparam name="TData">Type of data.</typeparam>
        /// <typeparam name="TMessage">Type of error message.</typeparam>
        /// <returns>Failure error.</returns>
        public static Result<TData, TMessage> CreateFailure<TData, TMessage>(TMessage errorMessage, Exception? exception = null)
            => new Result<TData, TMessage>(false, default!, new[] { errorMessage }, exception);

        /// <summary>
        /// Creates failure result.
        /// </summary>
        /// <param name="errorMessage">Message that represents error.</param>
        /// <param name="exception">Exception that represents error.</param>
        /// <typeparam name="TData">Type of data.</typeparam>
        /// <typeparam name="TMessage">Type of error message.</typeparam>
        /// <returns>Failure error.</returns>
        public static Result<TData, TMessage> CreateFailure<TData, TMessage>(IEnumerable<TMessage> errorMessage, Exception? exception = null)
            => new Result<TData, TMessage>(false, default!, errorMessage, exception);
    }
}