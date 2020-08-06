namespace Resulter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Resulter.Abstract;
    using Resulter.Abstract.Generic;

    public class Result<TMessage> : ISuccessfulResult, IFailureResult<TMessage>, IResult
    {
        public Result(bool isSuccessful, IEnumerable<TMessage>? errorMessages = null, Exception? exception = null)
        {
            IsSuccessful = isSuccessful;
            ErrorMessageList = errorMessages == null ? new List<TMessage>() : errorMessages.ToList();
            Exception = exception;
        }

        IReadOnlyCollection<TMessage> IFailureResult<TMessage>.ErrorMessages => ErrorMessageList;

        Exception? IExceptionResult.Exception => Exception;

        public bool IsSuccessful { get; }

        protected List<TMessage> ErrorMessageList { get; }

        protected Exception? Exception { get; set; }
    }
}