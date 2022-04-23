﻿using System;
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
            simulation.Start();

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
            booksManager.CreateBook(new BookInfo { isbn = "1234-567-890-157", author = "Adam Mickiewicz", title = "Pan Tadeusz" });
            booksManager.CreateBook(new BookInfo { isbn = "1234-567-890-157", author = "Stefan Żeromski", title = "Ludzie bezdomni" });
            booksManager.CreateBook(new BookInfo { isbn = "1234-567-890-157", author = "Stefan Żeromski", title = "Ludzie bezdomni" });
            booksManager.CreateBook(new BookInfo { isbn = "1234-567-890-157", author = "Stefan Żeromski", title = "Ludzie bezdomni" });
            booksManager.CreateBook(new BookInfo { isbn = "1234-567-890-157", author = "Stefan Żeromski", title = "Ludzie bezdomni" });
            booksManager.CreateBook(new BookInfo { isbn = "1234-567-890-157", author = "Stefan Żeromski", title = "Ludzie bezdomni" });
            booksManager.CreateBook(new BookInfo { isbn = "1234-567-890-157", author = "Stefan Żeromski", title = "Ludzie bezdomni" });
            booksManager.CreateBook(new BookInfo { isbn = "1234-567-890-157", author = "Mariano Italiano", title = "Przepis na spaghetti" });
            booksManager.CreateBook(new BookInfo { isbn = "1234-567-890-157", author = "Stefan Żeromski", title = "Ludzie bezdomni" });
            booksManager.CreateBook(new BookInfo { isbn = "1234-567-890-157", author = "Stefan Żeromski", title = "Ludzie bezdomni" });
            booksManager.CreateBook(new BookInfo { isbn = "1234-567-890-157", author = "Stefan Żeromski", title = "Ludzie bezdomni" });
            booksManager.CreateBook(new BookInfo { isbn = "1234-567-890-157", author = "Stefan Żeromski", title = "Ludzie bezdomni" });

            personsManager.CreatePerson(new PersonInfo { firstName = "Stefan", surname = "Kowalski" });
            personsManager.CreatePerson(new PersonInfo { firstName = "Stefan", surname = "Kowalski" });
            personsManager.CreatePerson(new PersonInfo { firstName = "Stefan", surname = "Kowalski" });
            personsManager.CreatePerson(new PersonInfo { firstName = "Stefan", surname = "Kowalski" });
            personsManager.CreatePerson(new PersonInfo { firstName = "Stefan", surname = "Kowalski" });
            personsManager.CreatePerson(new PersonInfo { firstName = "Stefan", surname = "Kowalski" });
            personsManager.CreatePerson(new PersonInfo { firstName = "Stefan", surname = "Kowalski" });
            personsManager.CreatePerson(new PersonInfo { firstName = "Stefan", surname = "Kowalski" });
            personsManager.CreatePerson(new PersonInfo { firstName = "Stefan", surname = "Kowalski" });
            personsManager.CreatePerson(new PersonInfo { firstName = "Stefan", surname = "Kowalski" });
            personsManager.CreatePerson(new PersonInfo { firstName = "Stefan", surname = "Kowalski" });

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