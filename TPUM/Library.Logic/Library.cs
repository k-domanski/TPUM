using System;
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
        public event Action<BookInfo> onBookAdded;
        public event Action<PersonInfo> onPersonAdded;
        public event Action<LendingInfo> onLendingAdded;
        public event Action<BookInfo> onBookRemoved;
        public event Action<PersonInfo> onPersonRemoved;
        public event Action<LendingInfo> onLendingRemoved;

        public ILibraryDataLayer dataLayer { get; private set; }
        public IBooksManager booksManager { get; private set; }
        public IPersonsManager personsManager { get; private set; }
        public ILendingsManager lendingsManager { get; private set; }

        public IFilter<BookInfo> bookAvailableFilter { get; }

        private Simulation simulation;

        public Library(ILibraryDataLayer dataLayer)
        {
            this.dataLayer = dataLayer;
            booksManager = new BooksManager(this);
            personsManager = new PersonsManager(this);
            lendingsManager = new LendingsManager(this);

            bookAvailableFilter = new BookAvailabilityFilter(true);

            dataLayer.GetBooksRepository().onBookAdded += HandleBookAdded;
            dataLayer.GetPersonsRepository().onPersonAdded += HandlePersonAdded;
            dataLayer.GetLendingsRepository().onLendingAdded += HandleLendingAdded;

            dataLayer.GetBooksRepository().onBookRemoved += HandleBookRemoved;
            dataLayer.GetPersonsRepository().onPersonRemoved += HandlePersonRemoved;
            dataLayer.GetLendingsRepository().onLendingRemoved += HandleLendingRemoved;
        }


        public void Initialize()
        {
            AddInitialLibraryData();
            simulation = new Simulation(this, 2.0f);
            //simulation.Start();

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

        public bool LendBook(Guid bookID, Guid personID)
        {
            return lendingsManager.CreateLending(new LendingInfo { bookID = bookID, personID = personID });
        }

        public bool ReturnBook(LendingInfo lending)
        {
            return lendingsManager.RemoveLending(lending);
        }

        public static ILibrary CreateDefault()
        {
            return new Library(LibraryDataLayer.CreateDefault());
        }

        internal void AddInitialLibraryData()
        {
            booksManager.CreateBook(new BookInfo { isbn = "345-078-234-654-2", author = "Adam Mickiewicz", title = "Pan Tadeusz" });
            booksManager.CreateBook(new BookInfo { isbn = "456-672-096-135-9", author = "John Doe", title = "Yes or No" });
            booksManager.CreateBook(new BookInfo { isbn = "457-838-495-325-6", author = "Stephenie Meyer", title = "The Chemist" });
            booksManager.CreateBook(new BookInfo { isbn = "678-325-256-632-8", author = "Philip Pullman", title = "La Belle Sauvage" });
            booksManager.CreateBook(new BookInfo { isbn = "548-261-156-636-4", author = "Ann Patchett", title = "These Precious Days: Essays" });
            booksManager.CreateBook(new BookInfo { isbn = "416-563-563-793-3", author = "Eleanor Catton", title = "The Luminaries" });
            booksManager.CreateBook(new BookInfo { isbn = "456-987-236-132-1", author = "Brit Bennett", title = "The Vanishing Half" });
            booksManager.CreateBook(new BookInfo { isbn = "896-694-513-163-3", author = "Mariano Italiano", title = "Przepis na spaghetti" });
            booksManager.CreateBook(new BookInfo { isbn = "633-672-987-564-3", author = "Rick Riordan", title = "The Kane Chronicles: The Red Pyramid" });
            booksManager.CreateBook(new BookInfo { isbn = "961-649-985-321-5", author = "Aprilynne Pike", title = "Wings" });
            booksManager.CreateBook(new BookInfo { isbn = "984-126-951-345-8", author = "Lev Grossman", title = "The Magician's Land" });
            booksManager.CreateBook(new BookInfo { isbn = "269-567-619-943-5", author = "Kate Atkinson", title = "Life After Life" });

            personsManager.CreatePerson(new PersonInfo { firstName = "Stefan", surname = "Kowalski" });
            personsManager.CreatePerson(new PersonInfo { firstName = "Robin", surname = "Miller" });
            personsManager.CreatePerson(new PersonInfo { firstName = "Kenneth", surname = "Gallego" });
            personsManager.CreatePerson(new PersonInfo { firstName = "Karolina", surname = "Michalska" });
            personsManager.CreatePerson(new PersonInfo { firstName = "Elżbieta", surname = "Kozłowska" });
            personsManager.CreatePerson(new PersonInfo { firstName = "Barbara", surname = "Pawlak" });
            personsManager.CreatePerson(new PersonInfo { firstName = "Ludwik", surname = "Sobczak" });
            personsManager.CreatePerson(new PersonInfo { firstName = "Felicjan", surname = "Jabłoński" });
            personsManager.CreatePerson(new PersonInfo { firstName = "Agnieszka", surname = "Jaworska" });
            personsManager.CreatePerson(new PersonInfo { firstName = "Krysia", surname = "Walczak" });
            personsManager.CreatePerson(new PersonInfo { firstName = "Marcelina", surname = "Grabowska" });

            lendingsManager.CreateLending(new LendingInfo
            {
                bookID = booksManager.GetBooks(new PassFilter<BookInfo>())[0].id,
                personID = personsManager.GetPersons(new PassFilter<PersonInfo>())[0].id
            });

            lendingsManager.CreateLending(new LendingInfo
            {
                bookID = booksManager.GetBooks(new PassFilter<BookInfo>())[1].id,
                personID = personsManager.GetPersons(new PassFilter<PersonInfo>())[1].id
            });
            lendingsManager.CreateLending(new LendingInfo
            {
                bookID = booksManager.GetBooks(new PassFilter<BookInfo>())[2].id,
                personID = personsManager.GetPersons(new PassFilter<PersonInfo>())[2].id
            });
            lendingsManager.CreateLending(new LendingInfo
            {
                bookID = booksManager.GetBooks(new PassFilter<BookInfo>())[3].id,
                personID = personsManager.GetPersons(new PassFilter<PersonInfo>())[3].id
            });

        }

        void HandleBookAdded(IBook book)
        {
            onBookAdded?.Invoke(Library.ToBookInfo(book));
        }

        void HandlePersonAdded(IPerson person)
        {
            onPersonAdded?.Invoke(Library.ToPersonInfo(person));
        }

        void HandleLendingAdded(ILending lending)
        {
            onLendingAdded?.Invoke(Library.ToLendingInfo(lending));
        }

        void HandleBookRemoved(IBook book)
        {
            onBookRemoved?.Invoke(Library.ToBookInfo(book));
        }

        void HandlePersonRemoved(IPerson person)
        {
            onPersonRemoved?.Invoke(Library.ToPersonInfo(person));
        }

        void HandleLendingRemoved(ILending lending)
        {
            onLendingRemoved?.Invoke(Library.ToLendingInfo(lending));
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
            return new Book(info.id, info.isbn, info.author, info.title, info.isAvailable);
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