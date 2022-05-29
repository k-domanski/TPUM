using Microsoft.VisualStudio.TestTools.UnitTesting;
using Library.DataServer.Interface;
using Library.DataServer;
using System;

namespace Library.LogicServer.UTest
{
    internal class ValidDataLayer : ILibraryDataLayer
    {
        public IBooksRepository GetBooksRepository()
        {
            return new BooksRepository();
        }

        public ILendingsRepository GetLendingsRepository()
        {
            return new LendingsRepository();
        }

        public IPersonsRepository GetPersonsRepository()
        {
            return new PersonsRepository();
        }
    }

    [TestClass]
    public class LibraryTest
    {
        private ILibraryDataLayer _validDataLayer;

        [TestInitialize]
        public void Initialize()
        {
            _validDataLayer = new ValidDataLayer();
        }

        [TestMethod]
        public void AddValidBook_Library_ReturnsTrue()
        {
            ILibrary library = new Library(_validDataLayer);
            BookInfo validBook = new BookInfo
            {
                author = "Stefan",
                id = Guid.NewGuid(),
                isAvailable = true,
                isbn = "123 456 789 0123",
                title = "Ludzie Bezdomni"
            };
            bool addResult = library.GetBooksManager().CreateBook(validBook);
            Assert.AreEqual(true, addResult);
        }

        [TestMethod]
        public void AddInvalidBook_Library_ReturnsFalse()
        {
            ILibrary library = new Library(_validDataLayer);

            BookInfo invalidBook = new BookInfo
            {
                author = string.Empty,
                id = Guid.NewGuid(),
                isAvailable = true,
                isbn = "123 456 789 0123",
                title = "Ludzie Bezdomni"
            };
            bool addResult = library.GetBooksManager().CreateBook(invalidBook);
            Assert.AreEqual(false, addResult);
        }

        [TestMethod]
        public void CanLendBook_ReturnsTrue()
        {
            ILibrary library = new Library(_validDataLayer);

            BookInfo invalidBook = new BookInfo
            {
                author = "Stefan Żeromski",
                id = Guid.NewGuid(),
                isAvailable = false,
                isbn = "123 456 789 0123",
                title = "Ludzie Bezdomni"
            };
            bool addResult = library.GetBooksManager().CreateBook(invalidBook);
            bool canLend = library.CanLendBook(invalidBook.id);
            Assert.AreEqual(false, canLend);
        }

        [TestMethod]
        public void CreateLending_ReturnsTrue()
        {
            ILibrary library = new Library(_validDataLayer);

            BookInfo validBook = new BookInfo
            {
                author = "Stefan Żeromski",
                id = Guid.NewGuid(),
                isAvailable = false,
                isbn = "123 456 789 0123",
                title = "Ludzie Bezdomni"
            };

            PersonInfo validPerson = new PersonInfo
            {
                firstName = "Maciej",
                surname = "Kowalski",
                id = Guid.NewGuid()
            };

            bool bbook = library.GetBooksManager().CreateBook(validBook);
            bool bperson = library.GetPersonsManager().CreatePerson(validPerson);

            bool lendingResult = library.LendBook(validBook.id, validPerson.id);
            Assert.AreEqual(false, lendingResult);
        }
    }
}
