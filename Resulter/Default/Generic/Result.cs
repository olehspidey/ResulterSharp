namespace Resulter.Default.Generic
{
    using System;
    using System.Collections.Generic;
    using Resulter.Generic;

    public class Result<TData> : ResultBase<TData, ErrorMessage>
    {
        public Result(
            bool isSuccessful,
            TData? data = default,
            IEnumerable<ErrorMessage>? errorMessages = null,
            Exception? exception = null)
            : base(isSuccessful, data, errorMessages, exception)
        {
        }
    }
}