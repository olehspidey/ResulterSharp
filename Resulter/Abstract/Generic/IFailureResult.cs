namespace Resulter.Abstract.Generic
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents the interface of failure result.
    /// </summary>
    /// <typeparam name="TMessage">Type of error message.</typeparam>
    public interface IFailureResult<out TMessage> : IExceptionResult
    {
        IReadOnlyCollection<TMessage> ErrorMessages { get; }
    }
}