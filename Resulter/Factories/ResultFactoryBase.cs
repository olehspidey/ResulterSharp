namespace Resulter.Factories
{
    using System;
    using System.Collections.Generic;
    using Generic;

    /// <summary>
    /// Represents the factory for <see cref="ResultBase{TMessage}"/> and <see cref="ResultBase{TData,TMessage}"/> result objects instantiation.
    /// </summary>
    public static class ResultFactoryBase
    {
        /// <summary>
        /// Creates successful <see cref="ResultBase{TMessage}"/> result with default <see cref="string"/> error messages.
        /// </summary>
        /// <returns>Successful result.</returns>
        public static ResultBase<string> CreateSuccess()
            => new(true);

        /// <summary>
        /// Creates successful <see cref="ResultBase{TMessage}"/> result.
        /// </summary>
        /// <typeparam name="TMessage">Type of error message.</typeparam>
        /// <returns>Successful result.</returns>
        public static ResultBase<TMessage> CreateSuccess<TMessage>()
            => new(true);

        /// <summary>
        /// Creates successful <see cref="ResultBase{TData,TMessage}"/> result.
        /// </summary>
        /// <param name="data">Value of data.</param>
        /// <typeparam name="TData">Type of data.</typeparam>
        /// <typeparam name="TMessage">Type of error messages.</typeparam>
        /// <returns>Successful result.</returns>
        public static ResultBase<TData, TMessage> CreateSuccess<TData, TMessage>(TData data)
            => new(true, data);

        /// <summary>
        /// Creates successful <see cref="ResultBase{TData,TMessage}"/> result with default <see cref="string"/> error messages.
        /// </summary>
        /// <param name="data">Value of data.</param>
        /// <typeparam name="TData">Type of data.</typeparam>
        /// <returns>Successful result.</returns>
        public static ResultBase<TData, string> CreateSuccess<TData>(TData data)
            => new(true, data);

        /// <summary>
        /// Creates failure <see cref="ResultBase{TMessage}"/> result with default <see cref="string"/> error messages.
        /// </summary>
        /// <param name="errorMessage">Message that represents error.</param>
        /// <param name="exception">Exception that represents error.</param>
        /// <returns>Failure error.</returns>
        public static ResultBase<string> CreateFailure(string errorMessage, Exception? exception = null)
            => new(false, new[] { errorMessage }, exception);

        /// <summary>
        /// Creates failure <see cref="ResultBase{TMessage}"/> result with default <see cref="string"/> error messages.
        /// </summary>
        /// <param name="errorMessages">Message collection that represent errors.</param>
        /// <param name="exception">Exception that represents error.</param>
        /// <returns>Failure error.</returns>
        public static ResultBase<string> CreateFailure(IEnumerable<string> errorMessages, Exception? exception = null)
            => new(false, errorMessages, exception);

        /// <summary>
        /// Creates failure <see cref="ResultBase{TMessage}"/> result.
        /// </summary>
        /// <param name="errorMessage">Message that represents error.</param>
        /// <param name="exception">Exception that represents error.</param>
        /// <typeparam name="TMessage">Type of error message.</typeparam>
        /// <returns>Failure error.</returns>
        public static ResultBase<TMessage> CreateFailure<TMessage>(TMessage errorMessage, Exception? exception = null)
            => new ResultBase<TMessage>(false, new[] { errorMessage }, exception);

        /// <summary>
        /// Creates failure <see cref="ResultBase{TMessage}"/> result.
        /// </summary>
        /// <param name="errorMessages">Message collection that represent errors.</param>
        /// <param name="exception">Exception that represents error.</param>
        /// <typeparam name="TMessage">Type of error message.</typeparam>
        /// <returns>Failure error.</returns>
        public static ResultBase<TMessage> CreateFailure<TMessage>(IEnumerable<TMessage> errorMessages, Exception? exception = null)
            => new(false, errorMessages, exception);

        /// <summary>
        /// Creates failure <see cref="ResultBase{TData,TMessage}"/> result.
        /// </summary>
        /// <param name="errorMessage">Message that represents error.</param>
        /// <param name="exception">Exception that represents error.</param>
        /// <typeparam name="TData">Type of data.</typeparam>
        /// <typeparam name="TMessage">Type of error message.</typeparam>
        /// <returns>Failure error.</returns>
        public static ResultBase<TData, TMessage> CreateFailure<TData, TMessage>(TMessage errorMessage, Exception? exception = null)
            => new ResultBase<TData, TMessage>(false, default!, new[] { errorMessage }, exception);

        /// <summary>
        /// Creates failure <see cref="ResultBase{TData,TMessage}"/> result.
        /// </summary>
        /// <param name="errorMessages">Message collection that represents errors.</param>
        /// <param name="exception">Exception that represents error.</param>
        /// <typeparam name="TData">Type of data.</typeparam>
        /// <typeparam name="TMessage">Type of error message.</typeparam>
        /// <returns>Failure error.</returns>
        public static ResultBase<TData, TMessage> CreateFailure<TData, TMessage>(IEnumerable<TMessage> errorMessages, Exception? exception = null)
            => new(false, default!, errorMessages, exception);
    }
}