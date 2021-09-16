namespace Resulter.Extensions
{
    using System.Collections.Generic;
    using System.Linq;
    using Abstract;
    using Factories;
    using Resulter.Abstract.Generic;

    /// <summary>
    /// Represents extensions for failure results.
    /// </summary>
    public static class FailedResultExtensions
    {
        /// <summary>
        /// Creates new failure result from existed <see cref="failureResult"/> with additional error.
        /// </summary>
        /// <param name="failureResult">Failure result.</param>
        /// <param name="error">Message that represents error.</param>
        /// <typeparam name="TMessage">Type of error message.</typeparam>
        /// <returns>New failure result from existed <see cref="failureResult"/>.</returns>
        public static IFailureResult<TMessage> WithError<TMessage>(
            this IFailureResult<TMessage> failureResult,
            TMessage error)
            => WithErrors(failureResult, new[] { error });

        /// <summary>
        /// Creates new failure result from existed <see cref="failureResult"/> with additional errors.
        /// </summary>
        /// <param name="failureResult">Failure result.</param>
        /// <param name="errors">Messages that represent errors.</param>
        /// <typeparam name="TMessage">Type of error message.</typeparam>
        /// <returns>New failure result from existed <see cref="failureResult"/>.</returns>
        public static IFailureResult<TMessage> WithErrors<TMessage>(
            this IFailureResult<TMessage> failureResult,
            IEnumerable<TMessage> errors)
            => ResultFactoryBase.CreateFailure(
                failureResult.ErrorMessages.Concat(errors),
                failureResult.Exception);

        /// <summary>
        /// Creates new failure result from existed <see cref="failureResult"/> with additional errors.
        /// </summary>
        /// <param name="failureResult">Failure result.</param>
        /// <param name="errors">Messages that represent errors.</param>
        /// <typeparam name="TMessage">Type of error message.</typeparam>
        /// <returns>New failure result from existed <see cref="failureResult"/>.</returns>
        public static IFailureResult<TMessage> WithErrors<TMessage>(
            this IFailureResult<TMessage> failureResult,
            params TMessage[] errors)
            => WithErrors(failureResult, new List<TMessage>(errors));

        /// <summary>
        /// Creates new successful result from failure result.
        /// </summary>
        /// <param name="failureResult">Failure result model.</param>
        /// <typeparam name="TMessage">Type of error message.</typeparam>
        /// <returns>New successful result from failure result.</returns>
        public static ISuccessfulResult ToSuccessfulResult<TMessage>(this IFailureResult<TMessage> failureResult)
            => ResultFactoryBase.CreateSuccess<TMessage>();

        /// <summary>
        /// Creates new successful result from failure result.
        /// </summary>
        /// <param name="failureResult">Failure result model.</param>
        /// <param name="data">Value of data.</param>
        /// <typeparam name="TData">Type of data.</typeparam>
        /// <typeparam name="TMessage">Type of error message.</typeparam>
        /// <returns>New successful result from failure result.</returns>
        public static ISuccessfulResult<TData> ToSuccessfulResult<TData, TMessage>(
            this IFailureResult<TMessage> failureResult,
            TData data)
            => ResultFactoryBase.CreateSuccess<TData, TMessage>(data);
    }
}