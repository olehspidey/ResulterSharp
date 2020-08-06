namespace Resulter.Http
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using Resulter.Http.Abstract;

    public class HttpResult<TMessage> : Result<TMessage>, IHttpResult
    {
        public HttpResult(
            bool isSuccessful,
            HttpStatusCode statusCode,
            IEnumerable<TMessage>? errorMessages = null,
            Exception? exception = null)
            : base(isSuccessful, errorMessages, exception)
        {
            StatusCode = statusCode;
        }

        public HttpStatusCode StatusCode { get; }
    }
}