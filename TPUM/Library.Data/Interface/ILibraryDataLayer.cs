namespace Library.Data.Interface
{
    public interface ILibraryDataLayer
    {
        IBooksRepository GetBookRepository();
        IPersonsRepository GetPersonsRepository();
        ILendingsRepository GetLendingsRepository();
    }
}