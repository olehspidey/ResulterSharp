namespace Resulter.Http
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using Resulter.Http.Abstract;

    public class HttpResult<TMessage> : Result<TMessage>, IHttpResult
    {
        public HttpStatusCode StatusCode { get; private set; }

        public static new HttpResult<TMessage> CreateSuccess()
            => new HttpResult<TMessage>
            {
                StatusCode = HttpStatusCode.OK,
                IsSuccessful = true,
            };

        public static HttpResult<TMessage> CreateSuccess(HttpStatusCode statusCode)
            => new HttpResult<TMessage>
            {
                StatusCode = statusCode,
                IsSuccessful = true,
            };

        public static new HttpResult<TMessage> CreateFailed(TMessage message, Exception? exception = null)
            => new HttpResult<TMessage>
            {
                MessagesList = new List<TMessage>
                {
                    message,
                },
                Exception = exception,
                StatusCode = HttpStatusCode.BadRequest,
            };

        public static HttpResult<TMessage> CreateFailed(TMessage message, HttpStatusCode statusCode, Exception? exception = null)
            => new HttpResult<TMessage>
            {
                MessagesList = new List<TMessage>
                {
                    message,
                },
                Exception = exception,
                StatusCode = statusCode,
            };

        public static HttpResult<TMessage> CreateFailed(IEnumerable<TMessage> messages, HttpStatusCode statusCode, Exception? exception = null)
            => new HttpResult<TMessage>
            {
                MessagesList = new List<TMessage>(messages),
                Exception = exception,
                StatusCode = statusCode,
            };

        public static new HttpResult<TMessage> CreateFailed(IEnumerable<TMessage> messages, Exception? exception = null)
            => new HttpResult<TMessage>
            {
                MessagesList = new List<TMessage>(messages),
                Exception = exception,
                StatusCode = HttpStatusCode.BadRequest,
            };
    }
}