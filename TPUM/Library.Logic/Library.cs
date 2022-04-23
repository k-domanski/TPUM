using System.Collections.Generic;
using System.Reflection;
using Library.Data;
using Library.Data.Interface;
using Library.Logic.Factories;
using Library.Logic.Filters;
using Library.Logic.Interface;

namespace Library.Logic
{
    public class Library : ILibrary
    {
        public ILibraryDataLayer dataLayer { get; private set; }

        public IBooksManager booksManager { get; private set; }
        public IPersonsManager personsManager { get; private set; }
        public ILendingsManager lendingsManager { get; private set; }

        public IFilter<BookInfo> bookAvailableFilter { get; }

        public Library(ILibraryDataLayer dataLayer)
        {
            this.dataLayer = dataLayer;
            booksManager = new BooksManager(this);
            personsManager = new PersonsManager(this);
            lendingsManager = new LendingsManager(this);

            bookAvailableFilter = new BookAvailabilityFilter(true);

            AddInitialLibraryData();
        }

        public IBooksManager GetBooksManager()
        {
            return booksManager;
        }

        public IPersonsManager GetPersonsManager()
        {
            return personsManager;
        }

        public ILendingsManager GetLendingsManager()
        {
            return lendingsManager;
        }

        public static ILibrary CreateDefault()
        {
            return new Library(LibraryDataLayer.CreateDefault());
        }

        internal void AddInitialLibraryData()
        {
            booksManager.CreateBook(new BookInfo { isbn = "1234-567-890-157", author = "Adam Mickiewicz", title = "Pan Tadeusz" });
            booksManager.CreateBook(new BookInfo { isbn = "1234-567-890-157", author = "Stefan Żeromski", title = "Ludzie bezdomni" });
            booksManager.CreateBook(new BookInfo { isbn = "1234-567-890-157", author = "Stefan Żeromski", title = "Ludzie bezdomni" });
            booksManager.CreateBook(new BookInfo { isbn = "1234-567-890-157", author = "Stefan Żeromski", title = "Ludzie bezdomni" });
            booksManager.CreateBook(new BookInfo { isbn = "1234-567-890-157", author = "Stefan Żeromski", title = "Ludzie bezdomni" });
            booksManager.CreateBook(new BookInfo { isbn = "1234-567-890-157", author = "Stefan Żeromski", title = "Ludzie bezdomni" });
            booksManager.CreateBook(new BookInfo { isbn = "1234-567-890-157", author = "Stefan Żeromski", title = "Ludzie bezdomni" });
            booksManager.CreateBook(new BookInfo { isbn = "1234-567-890-157", author = "Stefan Żeromski", title = "Ludzie bezdomni" });
            booksManager.CreateBook(new BookInfo { isbn = "1234-567-890-157", author = "Stefan Żeromski", title = "Ludzie bezdomni" });
            booksManager.CreateBook(new BookInfo { isbn = "1234-567-890-157", author = "Stefan Żeromski", title = "Ludzie bezdomni" });
            booksManager.CreateBook(new BookInfo { isbn = "1234-567-890-157", author = "Stefan Żeromski", title = "Ludzie bezdomni" });
            booksManager.CreateBook(new BookInfo { isbn = "1234-567-890-157", author = "Stefan Żeromski", title = "Ludzie bezdomni" });
        }

        // Conversion functions
        internal static BookInfo ToBookInfo(IBook book)
        {
            return new BookInfo
            {
                id = book.GetBookID(),
                isbn = book.GetISBN(),
                author = book.GetAuthor(),
                title = book.GetTitle(),
                isAvailable = book.IsAvailable()
            };
        }


        internal static PersonInfo ToPersonInfo(IPerson person)
        {
            return new PersonInfo
            {
                id = person.GetID(),
                firstName = person.GetFirstName(),
                surname = person.GetSurname()
            };
        }

        internal static LendingInfo ToLendingInfo(ILending lending)
        {
            return new LendingInfo
            {
                bookID = lending.GetBookID(),
                personID = lending.GetPersonID()
            };
        }

        internal static Book ToBook(BookInfo info)
        {
            return new Book(info.id, info.isbn, info.author, info.title);
        }

        internal static Person ToPerson(PersonInfo info)
        {
            return new Person(info.id, info.firstName, info.surname);
        }

        internal static Lending ToLending(LendingInfo info)
        {
            return new Lending(info.personID, info.bookID);
        }
    }
}