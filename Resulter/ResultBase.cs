namespace Resulter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Abstract;
    using Resulter.Abstract.Generic;

    /// <summary>
    /// Represents the model of result.
    /// </summary>
    /// <typeparam name="TMessage">Type of error message.</typeparam>
    public class ResultBase<TMessage> : ISuccessfulResult, IFailureResult<TMessage>, IResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResultBase{TMessage}"/> class.
        /// </summary>
        /// <param name="isSuccessful">Is result successful.</param>
        /// <param name="errorMessages">List of error messages.</param>
        /// <param name="exception">Error exception.</param>
        public ResultBase(bool isSuccessful, IEnumerable<TMessage>? errorMessages = null, Exception? exception = null)
        {
            IsSuccessful = isSuccessful;
            ErrorMessageList = errorMessages == null ? new List<TMessage>() : errorMessages.ToList();
            Exception = exception;
        }

        /// <summary>
        /// Gets error messages list.
        /// </summary>
        IReadOnlyCollection<TMessage> IFailureResult<TMessage>.ErrorMessages => ErrorMessageList;

        /// <summary>
        /// Gets error exception.
        /// </summary>
        Exception? IExceptionResult.Exception => Exception;

        /// <summary>
        /// Gets a value indicating whether status of result is successful.
        /// </summary>
        public bool IsSuccessful { get; }

        protected List<TMessage> ErrorMessageList { get; }

        protected Exception? Exception { get; set; }
    }
}