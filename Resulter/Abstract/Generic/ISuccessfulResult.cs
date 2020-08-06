namespace Resulter.Abstract.Generic
{
    public interface ISuccessfulResult<out TData>
    {
        TData Data { get; }
    }
}