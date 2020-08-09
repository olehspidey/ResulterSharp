namespace Resulter.Http
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using Resulter.Http.Abstract;

    /// <summary>
    /// Represents the model of http result.
    /// </summary>
    /// <typeparam name="TMessage">Type of error message.</typeparam>
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

        /// <summary>
        /// Gets http status code.
        /// </summary>
        public HttpStatusCode StatusCode { get; }
    }
}