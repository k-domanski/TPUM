namespace Library.DataServer.Interface
{
    public interface ILibraryDataLayer
    {
        IBooksRepository GetBooksRepository();
        IPersonsRepository GetPersonsRepository();
        ILendingsRepository GetLendingsRepository();
    }
}