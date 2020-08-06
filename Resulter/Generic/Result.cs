namespace Resulter.Generic
{
    using System;
    using System.Collections.Generic;
    using Resulter.Abstract;
    using Resulter.Abstract.Generic;

    public class Result<TData, TMessage> : ISuccessfulResult<TData>, IFailureResult<TMessage>, IResult
    {
        TData ISuccessfulResult<TData>.Data => Data;

        IReadOnlyCollection<TMessage> IFailureResult<TMessage>.Messages => MessagesList;

        Exception? IExceptionResult.Exception => Exception;

        bool IResult.IsSuccessful => IsSuccessful;

        protected List<TMessage> MessagesList { get; set; } = new List<TMessage>();

        protected Exception? Exception { get; set; }

        protected TData Data { get; set; } = default!;

        protected bool IsSuccessful { get; set; }

        public static Result<TData, TMessage> CreateFailed(TMessage message, Exception? exception = null)
            => new Result<TData, TMessage>
            {
                MessagesList = new List<TMessage> { message },
                Exception = exception,
            };

        public static Result<TData, TMessage> CreateFailed(
            IEnumerable<TMessage> messages,
            Exception? exception = null)
            => new Result<TData, TMessage>
            {
                MessagesList = new List<TMessage>(messages),
                Exception = exception,
            };

        public static Result<TData, TMessage> CreateSuccess(TData data)
            => data is null
                ? throw new ArgumentNullException(nameof(data))
                : new Result<TData, TMessage>
                {
                    Data = data,
                    IsSuccessful = true,
                };
    }
}