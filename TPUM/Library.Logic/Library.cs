using Library.Data.Interface;
using Library.Logic.Interface;

namespace Library.Logic
{
    public class Library
    {
        public ILibraryDataLayer dataLayer { get; private set; }

        public IBooksManager booksManager { get; private set; }
        public IPersonsManager personsManager { get; private set; }
        public ILendingsManager lendingsManager { get; private set; }

        

        public Library(ILibraryDataLayer dataLayer)
        {
            this.dataLayer = dataLayer;
            booksManager = new BooksManager(this);
        }
    }
}