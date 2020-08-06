namespace Resulter.Abstract
{
    using System;

    public interface IExceptionResult
    {
        Exception? Exception { get; }
    }
}