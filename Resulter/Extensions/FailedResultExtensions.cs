namespace Resulter.Extensions
{
    using System.Collections.Generic;
    using System.Linq;
    using Resulter.Abstract;
    using Resulter.Abstract.Generic;
    using Resulter.Fabrics;

    public static class FailedResultExtensions
    {
        public static IFailureResult<TMessage> WithError<TMessage>(
            this IFailureResult<TMessage> failureResult,
            TMessage error)
            => WithErrors(failureResult, new[] { error });

        public static IFailureResult<TMessage> WithErrors<TMessage>(
            this IFailureResult<TMessage> failureResult,
            IEnumerable<TMessage> errors)
            => ResultFabric.CreateFailure(
                failureResult.ErrorMessages.Concat(errors),
                failureResult.Exception);

        public static IFailureResult<TMessage> WithErrors<TMessage>(
            this IFailureResult<TMessage> failureResult,
            params TMessage[] errors)
            => WithErrors(failureResult, errors);

        public static ISuccessfulResult ToSuccessfulResult<TMessage>(this IFailureResult<TMessage> failureResult)
            => ResultFabric.CreateSuccess<TMessage>();

        public static ISuccessfulResult<TData> ToSuccessfulResult<TData, TMessage>(
            this IFailureResult<TMessage> failureResult,
            TData data)
            => ResultFabric.CreateSuccess<TData, TMessage>(data);
    }
}