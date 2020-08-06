namespace Resulter.Http.Generic
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using Resulter.Generic;
    using Resulter.Http.Abstract;

    public class HttpResult<TData, TMessage> : Result<TData, TMessage>, IHttpResult
    {
        protected internal HttpResult(
            bool isSuccessful,
            HttpStatusCode statusCode,
            TData data = default,
            IEnumerable<TMessage>? errorMessages = null,
            Exception? exception = null)
            : base(isSuccessful, data, errorMessages, exception)
        {
            StatusCode = statusCode;
        }

        public HttpStatusCode StatusCode { get; }
    }
}