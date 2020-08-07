namespace Resulter.Abstract
{
    using System;

    /// <summary>
    /// Represents interface of exception result.
    /// </summary>
    public interface IExceptionResult
    {
        Exception? Exception { get; }
    }
}