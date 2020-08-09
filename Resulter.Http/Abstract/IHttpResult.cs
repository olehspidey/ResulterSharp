namespace Resulter.Http.Abstract
{
    using System.Net;

    /// <summary>
    /// Represents interface of http result.
    /// </summary>
    public interface IHttpResult
    {
        /// <summary>
        /// Gets http status code of result.
        /// </summary>
        public HttpStatusCode StatusCode { get; }
    }
}