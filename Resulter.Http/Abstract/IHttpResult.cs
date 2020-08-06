namespace Resulter.Http.Abstract
{
    using System.Net;

    public interface IHttpResult
    {
        public HttpStatusCode StatusCode { get; }
    }
}