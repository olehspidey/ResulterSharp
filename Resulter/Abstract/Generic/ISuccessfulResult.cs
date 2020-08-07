namespace Resulter.Abstract.Generic
{
    /// <summary>
    /// Represent the interface of successful result.
    /// </summary>
    /// <typeparam name="TData">Type of data.</typeparam>
    public interface ISuccessfulResult<out TData>
    {
        TData Data { get; }
    }
}