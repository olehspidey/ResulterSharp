namespace Resulter.Fabrics
{
    using System;
    using System.Collections.Generic;
    using Resulter.Generic;

    public static class ResultFabric
    {
        public static Result<string> CreateSuccess()
            => new Result<string>(true);

        public static Result<TMessage> CreateSuccess<TMessage>()
            => new Result<TMessage>(true);

        public static Result<TData, TMessage> CreateSuccess<TData, TMessage>(TData data)
            => new Result<TData, TMessage>(true, data);

        public static Result<string> CreateFailure(string errorMessage, Exception? exception = null)
            => new Result<string>(false, new[] { errorMessage }, exception);

        public static Result<string> CreateFailure(IEnumerable<string> errorMessages, Exception? exception = null)
            => new Result<string>(false, errorMessages, exception);

        public static Result<TMessage> CreateFailure<TMessage>(TMessage errorMessage, Exception? exception = null)
            => new Result<TMessage>(false, new[] { errorMessage }, exception);

        public static Result<TMessage> CreateFailure<TMessage>(IEnumerable<TMessage> errorMessages, Exception? exception = null)
            => new Result<TMessage>(false, errorMessages, exception);

        public static Result<TData, TMessage> CreateFailure<TData, TMessage>(TMessage errorMessage, Exception? exception = null)
            => new Result<TData, TMessage>(false, default!, new[] { errorMessage }, exception);

        public static Result<TData, TMessage> CreateFailure<TData, TMessage>(IEnumerable<TMessage> errorMessage, Exception? exception = null)
            => new Result<TData, TMessage>(false, default!, errorMessage, exception);
    }
}