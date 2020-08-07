namespace Resulter.Extensions
{
    using System;
    using Resulter.Abstract;
    using Resulter.Abstract.Generic;
    using Resulter.Generic;

    /// <summary>
    /// Represents extensions for result models.
    /// </summary>
    public static class ResultExtensions
    {
        /// <summary>
        /// Checks if result is successful. Returns true when result is successful else false.
        /// When returns true <see cref="data"/> has "default" value.
        /// </summary>
        /// <param name="result">Result model.</param>
        /// <param name="data">Result data.</param>
        /// <typeparam name="TData">Type of data.</typeparam>
        /// <typeparam name="TMessage">Type of error message.</typeparam>
        /// <returns>Returns true when result is successful else false.</returns>
        public static bool IsSuccessful<TData, TMessage>(this Result<TData, TMessage> result, out TData data)
        {
            if (((IResult)result).IsSuccessful)
            {
                data = ((ISuccessfulResult<TData>)result).Data;

                return true;
            }

            data = default!;

            return false;
        }

        /// <summary>
        /// Checks if result is failure. Returns true when result is failure else false.
        /// </summary>
        /// <param name="result">Result model.</param>
        /// <param name="failureResult">Failure result model.</param>
        /// <typeparam name="TData">Type of data.</typeparam>
        /// <typeparam name="TMessage">Type of error message.</typeparam>
        /// <returns>Returns true when result is failure else false.</returns>
        public static bool IsFailure<TData, TMessage>(this Result<TData, TMessage> result, out IFailureResult<TMessage> failureResult)
        {
            if (!((IResult)result).IsSuccessful)
            {
                failureResult = result;

                return true;
            }

            failureResult = default!;

            return false;
        }

        /// <summary>
        /// Checks if result is failure. Returns true when result is failure else false.
        /// </summary>
        /// <param name="result">Result model.</param>
        /// <param name="failureResult">Failure result model.</param>
        /// <typeparam name="TMessage">Type of error message.</typeparam>
        /// <returns>Returns true when result is failure else false.</returns>
        public static bool IsFailure<TMessage>(this Result<TMessage> result, out IFailureResult<TMessage> failureResult)
        {
            if (!result.IsSuccessful)
            {
                failureResult = result;

                return true;
            }

            failureResult = default!;

            return false;
        }

        /// <summary>
        /// Throw exception when result is failure and exception is not null.
        /// </summary>
        /// <param name="result">Exception result.</param>
        /// <exception cref="Exception">Exception from <see cref="result"/>.</exception>
        public static void ThrowIfException(this IExceptionResult result)
        {
            if (result.Exception != null)
                throw result.Exception;
        }
    }
}