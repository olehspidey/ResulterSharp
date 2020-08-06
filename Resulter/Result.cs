namespace Resulter
{
    using System;
    using System.Collections.Generic;
    using Resulter.Abstract;
    using Resulter.Abstract.Generic;

    public class Result<TMessage> : ISuccessfulResult, IFailureResult<TMessage>, IResult
    {
        protected Result()
        {
        }

        IReadOnlyCollection<TMessage> IFailureResult<TMessage>.Messages => MessagesList;

        Exception? IExceptionResult.Exception => Exception;

        public bool IsSuccessful { get; protected set; }

        protected List<TMessage> MessagesList { get; set; } = new List<TMessage>();

        protected Exception? Exception { get; set; }

        public static Result<TMessage> CreateFailed(TMessage message, Exception? exception = null)
            => new Result<TMessage>
            {
                MessagesList = new List<TMessage> { message },
                Exception = exception,
            };

        public static Result<TMessage> CreateFailed(
            IEnumerable<TMessage> messages,
            Exception? exception = null)
            => new Result<TMessage>
            {
                MessagesList = new List<TMessage>(messages),
                Exception = exception,
            };

        public static Result<TMessage> CreateSuccess()
            => new Result<TMessage>
            {
                IsSuccessful = true,
            };
    }
}