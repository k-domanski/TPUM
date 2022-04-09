namespace Library.Data.Interface
{
    public interface ILibraryDataLayer
    {
        IBooksRepository GetBooksRepository();
        IPersonsRepository GetPersonsRepository();
        ILendingsRepository GetLendingsRepository();
    }
}