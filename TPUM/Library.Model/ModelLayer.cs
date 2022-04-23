using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Logic;
using Library.Logic.Filters;

namespace Library.Model
{
    public class ModelLayer
    {
        private readonly object _lock = new object();

        public ObservableCollection<Book> books { get; private set; }
        public ObservableCollection<Person> users { get; private set; }
        public ObservableCollection<Lending> lendings { get; private set; }

        public static ModelLayer CreateDefault()
        {
            return new ModelLayer(Logic.Library.CreateDefault());
        }

        public ILibrary library { get; }
        public ModelLayer(ILibrary library)
        {
            this.library = library;

            library.onBookAdded += HandleBookAdded;
            library.onPersonAdded += HandlePersonAdded;
            library.onLendingAdded += HandleLendingAdded;

            library.onBookRemoved += HandleBookRemoved;
            library.onPersonRemoved += HandlePersonRemoved;
            library.onLendingRemoved += HandleLendingRemoved;

            books = new ObservableCollection<Book>();
            users = new ObservableCollection<Person>();
            lendings = new ObservableCollection<Lending>();

            library.Initialize();
        }

        public IEnumerable<Book> book => library.GetBooksManager().GetBooks(new PassFilter<BookInfo>()).ConvertAll(ModelLayer.ToBook);

        public IEnumerable<Person> user => library.GetPersonsManager().GetPersons(new PassFilter<PersonInfo>()).ConvertAll(ModelLayer.ToPerson);

        public IEnumerable<Lending> lending => library.GetLendingsManager().GetLendings(new PassFilter<LendingInfo>()).ConvertAll(ModelLayer.ToLending);

        internal void HandleBookAdded(BookInfo info)
        {
            books.Add(ModelLayer.ToBook(info));
        }

        internal void HandlePersonAdded(PersonInfo info)
        {
            users.Add(ModelLayer.ToPerson(info));
        }

        internal void HandleLendingAdded(LendingInfo info)
        {
            Lending lending = ToLending(info);
            lending.bookAuthor = lending.bookTitle = lending.userName = lending.userSurname = "Not Found";
            var books = library.GetBooksManager().GetBooks(new BookIDFilter(info.bookID));
            var persons = library.GetPersonsManager().GetPersons(new PersonIDFilter(info.personID));
            if (books.Count == 1)
            {
                lending.bookAuthor = books[0].author;
                lending.bookTitle = books[0].title;
            }

            if (persons.Count == 1)
            {
                lending.userName = persons[0].firstName;
                lending.userSurname = persons[0].surname;
            }

            lendings.Add(lending);
        }

        internal void HandleBookRemoved(BookInfo info)
        {
            books.Remove(ModelLayer.ToBook(info));
        }

        internal void HandlePersonRemoved(PersonInfo info)
        {
            users.Remove(ModelLayer.ToPerson(info));
        }


        internal void HandleLendingRemoved(LendingInfo info)
        {
            lendings.Remove(ModelLayer.ToLending(info));
        }

        public void CreateBook(Book book)
        {
            library.GetBooksManager().CreateBook(ToBookInfo(book));
        }

        internal static Book ToBook(BookInfo bookInfo)
        {
            return new Book { id = bookInfo.id, author = bookInfo.author, title = bookInfo.title, isbn = bookInfo.isbn };
        }

        internal static BookInfo ToBookInfo(Book book)
        {
            return new BookInfo { author = book.author, title = book.title, id = book.id, isbn = book.isbn, isAvailable = true };
        }

        internal static Person ToPerson(PersonInfo personInfo)
        {
            return new Person { id = personInfo.id, firstName = personInfo.firstName, lastName = personInfo.surname };
        }

        internal static Lending ToLending(LendingInfo lendingInfo)
        {
            return new Lending { bookID = lendingInfo.bookID, userID = lendingInfo.personID };
        }
    }
}
