namespace Library.LogicServer.Interface
{
    public interface IFilter<T>
    {
        bool Match(T item);
    }
}