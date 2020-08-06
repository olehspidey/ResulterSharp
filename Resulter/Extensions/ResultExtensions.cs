namespace Resulter.Extensions
{
    using Resulter.Abstract;
    using Resulter.Abstract.Generic;
    using Resulter.Generic;

    public static class ResultExtensions
    {
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

        public static void ThrowIfException<TMessage>(this IExceptionResult result)
        {
            if (result.Exception != null)
                throw result.Exception;
        }
    }
}