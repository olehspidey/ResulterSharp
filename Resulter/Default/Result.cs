namespace Resulter.Default
{
    using System;
    using System.Collections.Generic;

    public class Result : ResultBase<ErrorMessage>
    {
        public Result(
            bool isSuccessful,
            IEnumerable<ErrorMessage>? errorMessages = null,
            Exception? exception = null)
            : base(isSuccessful, errorMessages, exception)
        {
        }
    }
}