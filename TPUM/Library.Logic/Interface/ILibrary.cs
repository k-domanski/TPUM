using Library.Logic.Interface;

namespace Library.Logic
{
    public interface ILibrary
    {
        IBooksManager GetBooksManager();
        IPersonsManager GetPersonsManager();
        ILendingsManager GetLendingsManager();
    }
}