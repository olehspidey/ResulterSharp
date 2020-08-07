namespace Resulter.Generic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Resulter.Abstract;
    using Resulter.Abstract.Generic;

    public class Result<TData, TMessage> : ISuccessfulResult<TData>, IFailureResult<TMessage>, IResult
    {
        public Result(
            bool isSuccessful,
            TData data = default,
            IEnumerable<TMessage>? errorMessages = null,
            Exception? exception = null)
        {
            Data = data;
            IsSuccessful = isSuccessful;
            ErrorMessagesList = errorMessages == null ? new List<TMessage>() : errorMessages.ToList();
            Exception = exception;
        }

        TData ISuccessfulResult<TData>.Data => Data;

        IReadOnlyCollection<TMessage> IFailureResult<TMessage>.ErrorMessages => ErrorMessagesList;

        Exception? IExceptionResult.Exception => Exception;

        bool IResult.IsSuccessful => IsSuccessful;

        protected List<TMessage> ErrorMessagesList { get; }

        protected Exception? Exception { get; }

        protected TData Data { get; } = default!;

        protected bool IsSuccessful { get; }
    }
}