namespace Resulter.Extensions
{
    using System;
    using Abstract;
    using Generic;
    using Resulter.Abstract.Generic;

    /// <summary>
    /// Represents extensions for result models.
    /// </summary>
    public static class ResultExtensions
    {
        /// <summary>
        /// Checks if result is successful. Returns true when result is successful else false.
        /// When returns true <see cref="data"/> has "default" value.
        /// </summary>
        /// <param name="resultBase">Result model.</param>
        /// <param name="data">Result data.</param>
        /// <typeparam name="TData">Type of data.</typeparam>
        /// <typeparam name="TMessage">Type of error message.</typeparam>
        /// <returns>Returns true when result is successful else false.</returns>
        public static bool IsSuccessful<TData, TMessage>(this ResultBase<TData, TMessage> resultBase, out TData data)
        {
            if (((IResult)resultBase).IsSuccessful)
            {
                data = ((ISuccessfulResult<TData>)resultBase).Data;

                return true;
            }

            data = default!;

            return false;
        }

        /// <summary>
        /// Checks if result is failure. Returns true when result is failure else false.
        /// </summary>
        /// <param name="resultBase">Result model.</param>
        /// <param name="failureResult">Failure result model.</param>
        /// <typeparam name="TData">Type of data.</typeparam>
        /// <typeparam name="TMessage">Type of error message.</typeparam>
        /// <returns>Returns true when result is failure else false.</returns>
        public static bool IsFailure<TData, TMessage>(this ResultBase<TData, TMessage> resultBase, out IFailureResult<TMessage> failureResult)
        {
            if (!((IResult)resultBase).IsSuccessful)
            {
                failureResult = resultBase;

                return true;
            }

            failureResult = default!;

            return false;
        }

        /// <summary>
        /// Checks if result is failure. Returns true when result is failure else false.
        /// </summary>
        /// <param name="resultBase">Result model.</param>
        /// <param name="failureResult">Failure result model.</param>
        /// <typeparam name="TMessage">Type of error message.</typeparam>
        /// <returns>Returns true when result is failure else false.</returns>
        public static bool IsFailure<TMessage>(this ResultBase<TMessage> resultBase, out IFailureResult<TMessage> failureResult)
        {
            if (!resultBase.IsSuccessful)
            {
                failureResult = resultBase;

                return true;
            }

            failureResult = default!;

            return false;
        }

        /// <summary>
        /// Throw exception when result is failure and exception is not null.
        /// </summary>
        /// <param name="resultBase">Result model.</param>
        /// <exception cref="Exception">Exception from <see cref="resultBase"/>.</exception>
        /// <typeparam name="TMessage">Type of error message.</typeparam>
        /// <returns>Same <see cref="ResultBase{TMessage}"/>.</returns>
        public static ResultBase<TMessage> ThrowIfException<TMessage>(this ResultBase<TMessage> resultBase)
        {
            if (resultBase is IExceptionResult { Exception: { } } exceptionResult)
                throw exceptionResult.Exception;

            return resultBase;
        }

        /// <summary>
        /// Throw exception when result is failure and exception is not null.
        /// </summary>
        /// <param name="resultBase">Result model.</param>
        /// <typeparam name="TData">Type of data.</typeparam>
        /// <typeparam name="TMessage">Type of error message.</typeparam>
        /// <returns>Same <see cref="ResultBase{TData,TMessage}"/>.</returns>
        public static ResultBase<TData, TMessage> ThrowIfException<TData, TMessage>(this ResultBase<TData, TMessage> resultBase)
        {
            if (resultBase is IExceptionResult { Exception: { } } exceptionResult)
                throw exceptionResult.Exception;

            return resultBase;
        }
    }
}