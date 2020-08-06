namespace Resulter.Http.Generic
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using Resulter.Generic;
    using Resulter.Http.Abstract;

    public class HttpResult<TData, TMessage> : Result<TData, TMessage>, IHttpResult
    {
        public HttpStatusCode StatusCode { get; private set; }

        public static new HttpResult<TData, TMessage> CreateSuccess(TData data)
            => new HttpResult<TData, TMessage>
            {
                StatusCode = HttpStatusCode.OK,
                IsSuccessful = true,
                Data = data,
            };

        public static HttpResult<TData, TMessage> CreateSuccess(TData data, HttpStatusCode statusCode)
            => new HttpResult<TData, TMessage>
            {
                StatusCode = statusCode,
                IsSuccessful = true,
                Data = data,
            };

        public static new HttpResult<TData, TMessage> CreateFailed(TMessage message, Exception? exception = null)
            => new HttpResult<TData, TMessage>
            {
                MessagesList = new List<TMessage>
                {
                    message,
                },
                Exception = exception,
                StatusCode = HttpStatusCode.BadRequest,
            };

        public static HttpResult<TData, TMessage> CreateFailed(TMessage message, HttpStatusCode statusCode, Exception? exception = null)
            => new HttpResult<TData, TMessage>
            {
                MessagesList = new List<TMessage>
                {
                    message,
                },
                StatusCode = statusCode,
                Exception = exception,
            };

        public static new HttpResult<TData, TMessage> CreateFailed(IEnumerable<TMessage> messages, Exception? exception = null)
            => new HttpResult<TData, TMessage>
            {
                MessagesList = new List<TMessage>(messages),
                Exception = exception,
                StatusCode = HttpStatusCode.BadRequest,
            };

        public static HttpResult<TData, TMessage> CreateFailed(IEnumerable<TMessage> messages, HttpStatusCode statusCode, Exception? exception = null)
            => new HttpResult<TData, TMessage>
            {
                MessagesList = new List<TMessage>(messages),
                StatusCode = statusCode,
                Exception = exception,
            };
    }
}