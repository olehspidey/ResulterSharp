namespace Resulter.Abstract.Generic
{
    using System;
    using System.Collections.Generic;

    public interface IFailureResult<out TMessage> : IExceptionResult
    {
        IReadOnlyCollection<TMessage> ErrorMessages { get; }
    }
}