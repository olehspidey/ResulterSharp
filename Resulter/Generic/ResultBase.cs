namespace Resulter.Generic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Abstract;
    using Resulter.Abstract.Generic;

    /// <summary>
    /// Represents the model of result.
    /// </summary>
    /// <typeparam name="TData">Type of data.</typeparam>
    /// <typeparam name="TMessage">Type of error message.</typeparam>
    public class ResultBase<TData, TMessage> : ISuccessfulResult<TData>, IFailureResult<TMessage>, IResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResultBase{TData,TMessage}"/> class.
        /// </summary>
        /// <param name="isSuccessful">Is result successful.</param>
        /// <param name="data">Data value.</param>
        /// <param name="errorMessages">List of error messages.</param>
        /// <param name="exception">Error exception.</param>
        public ResultBase(
            bool isSuccessful,
            TData? data = default,
            IEnumerable<TMessage>? errorMessages = null,
            Exception? exception = null)
        {
            Data = data!;
            IsSuccessful = isSuccessful;
            ErrorMessagesList = errorMessages == null ? new List<TMessage>() : errorMessages.ToList();
            Exception = exception;
        }

        public bool IsSuccessful { get; }

        /// <summary>
        /// Gets value of data.
        /// </summary>
        TData ISuccessfulResult<TData>.Data => Data;

        /// <summary>
        /// Gets error messages list.
        /// </summary>
        IReadOnlyCollection<TMessage> IFailureResult<TMessage>.ErrorMessages => ErrorMessagesList;

        /// <summary>
        /// Gets error exception.
        /// </summary>
        Exception? IExceptionResult.Exception => Exception;

        /// <summary>
        /// Gets a value indicating whether status of result is successful.
        /// </summary>
        bool IResult.IsSuccessful => IsSuccessful;

        protected List<TMessage> ErrorMessagesList { get; }

        protected Exception? Exception { get; }

        protected TData Data { get; }
    }
}