namespace Resulter.Factories
{
    using System;
    using System.Collections.Generic;
    using Default;
    using Default.Generic;

    public class ResultFactory
    {
        /// <summary>
        /// Creates successful <see cref="Result"/> result.
        /// </summary>
        /// <returns>Successful result.</returns>
        public static Result CreateSuccess()
            => new(true);

        /// <summary>
        /// Creates successful <see cref="Result{TData}"/> result.
        /// </summary>
        /// <param name="data">Value of data.</param>
        /// <typeparam name="TData">Type of data.</typeparam>
        /// <returns>Successful result.</returns>
        public static Result<TData> CreateSuccess<TData>(TData data)
            => new(true, data);

        /// <summary>
        /// Creates failure <see cref="Result"/> result.
        /// </summary>
        /// <param name="errorCode">Error code that represents error.</param>
        /// <param name="exception">Exception that represents error.</param>
        /// <returns>Failure error.</returns>
        public static Result CreateFailure(string errorCode, Exception? exception = null)
            => new(
                false,
                new[] { new ErrorMessage(errorCode, null) },
                exception);

        /// <summary>
        /// Creates failure <see cref="Result"/> result.
        /// </summary>
        /// <param name="errorMessage">Represents error message.</param>
        /// <param name="exception">Exception that represents error.</param>
        /// <returns>Failure error.</returns>
        public static Result CreateFailure(ErrorMessage errorMessage, Exception? exception = null)
            => new(
                false,
                new[] { errorMessage },
                exception);

        /// <summary>
        /// Creates failure <see cref="Result{TData}"/> result.
        /// </summary>
        /// <param name="errorCode">Error code that represents error.</param>
        /// <param name="errorMessage">Error message that describes error.</param>
        /// <param name="exception">Exception that represents error.</param>
        /// <typeparam name="TData">Type of data.</typeparam>
        /// <returns>Failure error.</returns>
        public static Result<TData> CreateFailure<TData>(string errorCode, string errorMessage, Exception? exception = null)
            => new(
                false,
                default,
                new[] { new ErrorMessage(errorCode, errorMessage) },
                exception);

        /// <summary>
        /// Creates failure <see cref="Result"/> result.
        /// </summary>
        /// <param name="errorMessages">Error message that describes errors.</param>
        /// <param name="exception">Exception that represents error.</param>
        /// <typeparam name="TData">Type of data.</typeparam>
        /// <returns>Failure error.</returns>
        public static Result<TData> CreateFailure<TData>(IEnumerable<ErrorMessage> errorMessages, Exception? exception = null)
            => new(
                false,
                default,
                errorMessages,
                exception);

        /// <summary>
        /// Creates failure <see cref="Result"/> result.
        /// </summary>
        /// <param name="errorCode">Error code that represents error.</param>
        /// <param name="exception">Exception that represents error.</param>
        /// <typeparam name="TData">Type of data.</typeparam>
        /// <returns>Failure error.</returns>
        public static Result<TData> CreateFailure<TData>(string errorCode, Exception? exception = null)
            => new(
                false,
                default!,
                new[] { new ErrorMessage(errorCode, null) },
                exception);

        /// <summary>
        /// Creates failure <see cref="Result"/> result.
        /// </summary>
        /// <param name="errorMessage">Represents error message.</param>
        /// <param name="exception">Exception that represents error.</param>
        /// <typeparam name="TData">Type of data.</typeparam>
        /// <returns>Failure error.</returns>
        public static Result<TData> CreateFailure<TData>(ErrorMessage errorMessage, Exception? exception = null)
            => new(
                false,
                default!,
                new[] { errorMessage },
                exception);

        /// <summary>
        /// Creates failure <see cref="Result"/> result.
        /// </summary>
        /// <param name="errorCode">Error code that represents error.</param>
        /// <param name="errorMessage">Error message that describes error.</param>
        /// <param name="exception">Exception that represents error.</param>
        /// <returns>Failure error.</returns>
        public static Result CreateFailure(string errorCode, string errorMessage, Exception? exception = null)
            => new(
                false,
                new[] { new ErrorMessage(errorCode, errorMessage) },
                exception);

        /// <summary>
        /// Creates failure <see cref="Result"/> result.
        /// </summary>
        /// <param name="errorMessages">Error message that describes errors.</param>
        /// <param name="exception">Exception that represents error.</param>
        /// <returns>Failure error.</returns>
        public static Result CreateFailure(IEnumerable<ErrorMessage> errorMessages, Exception? exception = null)
            => new(
                false,
                errorMessages,
                exception);
    }
}