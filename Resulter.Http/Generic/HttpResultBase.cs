namespace Resulter.Http.Generic
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using Resulter.Generic;
    using Abstract;

    /// <summary>
    /// Represents the model of http result.
    /// </summary>
    /// <typeparam name="TData">Type of data.</typeparam>
    /// <typeparam name="TMessage">Type of error message.</typeparam>
    public class HttpResultBase<TData, TMessage> : Result<TData, TMessage>, IHttpResult
    {
        protected internal HttpResultBase(
            bool isSuccessful,
            HttpStatusCode statusCode,
            TData data = default,
            IEnumerable<TMessage>? errorMessages = null,
            Exception? exception = null)
            : base(isSuccessful, data, errorMessages, exception)
        {
            StatusCode = statusCode;
        }

        /// <summary>
        /// Gets http status code.
        /// </summary>
        public HttpStatusCode StatusCode { get; }
    }
}