using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Library.Logic;
using Library.Logic.Filters;
using Library.Logic.Interface;

namespace Library.Model
{
    public class ModelLayer
    {
        private IFilter<BookInfo> activeBookFilter = new PassFilter<BookInfo>();

        public ObservableCollection<Book> books { get; private set; }
        public ObservableCollection<Person> users { get; private set; }
        public ObservableCollection<Lending> lendings { get; private set; }
        public ObservableCollection<Message> messages { get; private set; }

        public static ModelLayer CreateDefault()
        {
            return new ModelLayer(Logic.Library.CreateDefault());
        }

        public ModelLayer CreateCopy()
        {
            ModelLayer model = new ModelLayer(library);
            model.books = new ObservableCollection<Book>(library.GetBooksManager().GetBooks(new PassFilter<BookInfo>()).ConvertAll(ModelLayer.ToBook));
            model.users = new ObservableCollection<Person>(library.GetPersonsManager().GetPersons(new PassFilter<PersonInfo>()).ConvertAll(ModelLayer.ToPerson));
            model.lendings = new ObservableCollection<Lending>(library.GetLendingsManager().GetLendings(new PassFilter<LendingInfo>()).ConvertAll(ModelLayer.ToLending));
            return model;
        }

        private ILibrary library { get; }
        public ModelLayer(ILibrary library)
        {
            this.library = library;

            library.onBookAdded += HandleBookAdded;
            library.onPersonAdded += HandlePersonAdded;
            library.onLendingAdded += HandleLendingAdded;

            library.onBookRemoved += HandleBookRemoved;
            library.onPersonRemoved += HandlePersonRemoved;
            library.onLendingRemoved += HandleLendingRemoved;

            library.onConnectionMessage += HandleConnectionMessage;

            books = new ObservableCollection<Book>();
            users = new ObservableCollection<Person>();
            lendings = new ObservableCollection<Lending>();
            messages = new ObservableCollection<Message>();

            //Test Messages
            //messages.Add (new Message {message = "Message 1" });
            //messages.Add (new Message {message = "Message 2" });
            //messages.Add (new Message {message = "Message 3" });

            library.Initialize();
        }

        private void HandleConnectionMessage(string obj)
        {
            messages.Add(new Message { message = obj });
        }

        public IEnumerable<Book> filteredBooks => library.GetBooksManager().GetBooks(activeBookFilter).ConvertAll(ModelLayer.ToBook);

        public IEnumerable<Person> filteredUsers => library.GetPersonsManager().GetPersons(new PassFilter<PersonInfo>()).ConvertAll(ModelLayer.ToPerson);

        public IEnumerable<Lending> filteredLendings => library.GetLendingsManager().GetLendings(new PassFilter<LendingInfo>()).ConvertAll(ModelLayer.ToLending);

        public void ShouldApplyOnlyAvailableFilter(bool apply)
        {
            if (apply)
            {
                activeBookFilter = new BookAvailabilityFilter(true);
            }
            else
            {
                activeBookFilter = new PassFilter<BookInfo>();
            }

            RefreshBooks();
        }

        public void Connect()
        {
            library.Connect(new Uri("ws://localhost:8888"));
        }

        private void RefreshBooks()
        {
            books.Clear();
            foreach (Book book in filteredBooks)
            {
                books.Add(book);
            }
        }

        private void RefreshPersons()
        {
            users.Clear();
            foreach (Person person in filteredUsers)
            {
                users.Add(person);
            }
        }

        private void RefreshLendings()
        {
            lendings.Clear();
            foreach (Lending lending in filteredLendings)
            {
                lending.bookAuthor = lending.bookTitle = lending.userName = lending.userSurname = "Not Found";
                var books = library.GetBooksManager().GetBooks(new BookIDFilter(lending.bookID));
                var persons = library.GetPersonsManager().GetPersons(new PersonIDFilter(lending.userID));
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
        }

        internal void HandleBookAdded(BookInfo info)
        {
            books.Add(ModelLayer.ToBook(info));
            RefreshBooks();
        }

        internal void HandlePersonAdded(PersonInfo info)
        {
            users.Add(ModelLayer.ToPerson(info));
            RefreshPersons();
        }

        internal void HandleLendingAdded(LendingInfo info)
        {
            RefreshBooks();
            RefreshLendings();
        }

        internal void HandleBookRemoved(BookInfo info)
        {
            books.Remove(ModelLayer.ToBook(info));
            RefreshBooks();
        }

        internal void HandlePersonRemoved(PersonInfo info)
        {
            users.Remove(ModelLayer.ToPerson(info));
            RefreshPersons();
        }


        internal void HandleLendingRemoved(LendingInfo info)
        {
            lendings.Remove(ModelLayer.ToLending(info));
            RefreshBooks();
            RefreshLendings();
        }

        public void CreateBook(Book book)
        {
            if (book == null)
            {
                return;
            }

            library.GetBooksManager().CreateBook(ToBookInfo(book));
        }

        public void CreateUser(Person user)
        {
            if (user == null)
            {
                return;
            }

            library.GetPersonsManager().CreatePerson(ToPersonInfo(user));
        }

        public bool CanCreateLending(Lending lending)
        {
            if (lending == null)
            {
                return false;
            }

            return library.CanLendBook(lending.bookID);
        }

        public void CreateLending(Lending lending)
        {
            if (lending == null)
            {
                return;
            }

            library.GetLendingsManager().CreateLending(ToLendingInfo(lending));
        }

        internal static Book ToBook(BookInfo bookInfo)
        {
            return new Book
            {
                id = bookInfo.id,
                author = bookInfo.author,
                title = bookInfo.title,
                isbn = bookInfo.isbn,
                isAvailable = bookInfo.isAvailable,
                availability = bookInfo.isAvailable ? "Dostępna" : "Wypożyczona"
            };
        }

        internal static BookInfo ToBookInfo(Book book)
        {
            return new BookInfo { author = book.author, title = book.title, id = book.id, isbn = book.isbn, isAvailable = true };
        }

        internal static Person ToPerson(PersonInfo personInfo)
        {
            return new Person { id = personInfo.id, firstName = personInfo.firstName, lastName = personInfo.surname };
        }

        internal static PersonInfo ToPersonInfo(Person person)
        {
            return new PersonInfo { firstName = person.firstName, surname = person.lastName };
        }

        internal static Lending ToLending(LendingInfo lendingInfo)
        {
            return new Lending { bookID = lendingInfo.bookID, userID = lendingInfo.personID };
        }

        internal static LendingInfo ToLendingInfo(Lending lending)
        {
            return new LendingInfo { bookID = lending.bookID, personID = lending.userID };
        }
    }
}
