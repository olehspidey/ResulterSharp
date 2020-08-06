namespace Resulter.Extensions
{
    using System.Collections.Generic;
    using System.Linq;
    using Resulter.Abstract.Generic;

    public static class FailedResultExtensions
    {
        public static IFailureResult<TMessage> WithError<TMessage>(
            this IFailureResult<TMessage> failureResult,
            TMessage error)
            => Result<TMessage>.CreateFailed(
                new List<TMessage>(failureResult
                    .Messages
                    .Concat(new[]
                    {
                        error,
                    })), failureResult.Exception);

        public static IFailureResult<TMessage> WithErrors<TMessage>(
            this IFailureResult<TMessage> failureResult,
            IEnumerable<TMessage> errors)
            => Result<TMessage>.CreateFailed(
                new List<TMessage>(failureResult
                    .Messages
                    .Concat(errors)), failureResult.Exception);

        public static IFailureResult<TMessage> WithError<TMessage>(
            this IFailureResult<TMessage> failureResult,
            params TMessage[] errors)
            => Result<TMessage>.CreateFailed(
                new List<TMessage>(failureResult
                    .Messages
                    .Concat(errors)), failureResult.Exception);
    }
}