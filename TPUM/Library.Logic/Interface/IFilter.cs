namespace Library.Logic.Interface
{
    public interface IFilter<T>
    {
        bool Match(T item);
    }
}