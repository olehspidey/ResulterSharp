namespace Resulter.Http.Fabrics
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using Resulter.Http;
    using Resulter.Http.Generic;

    public static class HttpResultFabric
    {
        public static HttpResult<string> CreateSuccess(HttpStatusCode statusCode = HttpStatusCode.OK)
            => new HttpResult<string>(true, statusCode);

        public static HttpResult<TMessage> CreateSuccess<TMessage>(HttpStatusCode statusCode = HttpStatusCode.OK)
            => new HttpResult<TMessage>(true, statusCode);

        public static HttpResult<TData, string> CreateSuccess<TData>(TData data, HttpStatusCode statusCode = HttpStatusCode.OK)
            => new HttpResult<TData, string>(true, statusCode, data);

        public static HttpResult<TData, TMessage> CreateSuccess<TData, TMessage>(TData data, HttpStatusCode statusCode = HttpStatusCode.OK)
            => new HttpResult<TData, TMessage>(true, statusCode, data);

        public static HttpResult<string> CreateFailure(
            string errorMessage,
            HttpStatusCode statusCode = HttpStatusCode.BadRequest,
            Exception? exception = null)
            => new HttpResult<string>(false, statusCode, new[] { errorMessage }, exception);

        public static HttpResult<string> CreateFailure(
            IEnumerable<string> errorMessages,
            HttpStatusCode statusCode = HttpStatusCode.BadRequest,
            Exception? exception = null)
            => new HttpResult<string>(false, statusCode, errorMessages, exception);

        public static HttpResult<TMessage> CreateFailure<TMessage>(
            TMessage errorMessage,
            HttpStatusCode statusCode = HttpStatusCode.BadRequest,
            Exception? exception = null)
            => new HttpResult<TMessage>(false, statusCode, new[] { errorMessage }, exception);

        public static HttpResult<TMessage> CreateFailure<TMessage>(
            IEnumerable<TMessage> errorMessages,
            HttpStatusCode statusCode = HttpStatusCode.BadRequest,
            Exception? exception = null)
            => new HttpResult<TMessage>(false, statusCode, errorMessages, exception);

        public static HttpResult<TData, TMessage> CreateFailure<TData, TMessage>(
            TMessage errorMessage,
            HttpStatusCode statusCode = HttpStatusCode.BadRequest,
            Exception? exception = null)
            => new HttpResult<TData, TMessage>(
                false,
                statusCode,
                default!,
                new[] { errorMessage },
                exception);

        public static HttpResult<TData, TMessage> CreateFailure<TData, TMessage>(
            IEnumerable<TMessage> errorMessage,
            HttpStatusCode statusCode = HttpStatusCode.BadRequest,
            Exception? exception = null)
            => new HttpResult<TData, TMessage>(false, statusCode, default!, errorMessage, exception);
    }
}