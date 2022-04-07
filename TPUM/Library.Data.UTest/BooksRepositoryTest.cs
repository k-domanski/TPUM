using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Library.Data;
using Library.Data.Interface;

namespace Library.Data.UTest
{
    internal class ValidBookFactory : IBookFactory
    {
        public IBook CreateBook(Guid isbn, string author, string title)
        {
            return new Book(isbn, author, title);
        }
    }

    internal class InvalidBookFactory : IBookFactory
    {
        public IBook CreateBook(Guid isbn, string author, string title)
        {
            return new Book(Guid.Empty, "ala", "ma kota");
        }
    }

    [TestClass]
    public class BooksRepositoryTest
    {
        private IBookFactory _validFactory;
        private IBookFactory _invalidFactory;

        [TestInitialize]
        public void Initialize()
        {
            _validFactory = new ValidBookFactory();
            _invalidFactory = new InvalidBookFactory();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructRepository_NullBookFactory_ThrowArgumentNullException()
        {
            IBookRepository repository = new BooksRepository(null);
        }

        [TestMethod]
        public void ConstructRepository_ValidBookFactory_NoThrow()
        {
            IBookRepository repository = new BooksRepository(_validFactory);
        }

        [TestMethod]
        public void AddBook_ValidBookFactory_ReturnsTrue()
        {
            IBookRepository repository = new BooksRepository(_validFactory);

            bool addResult1 = repository.AddBook(Guid.NewGuid(), "Tom Smith", "Yes or No");
            Assert.AreEqual(true, addResult1);

            bool addResult2 = repository.AddBook(Guid.NewGuid(), "Tom Smith", "Yes or No");
            Assert.AreEqual(true, addResult2);
        }

        [TestMethod]
        public void AddBook_InvalidBookFactory_ReturnsFalse()
        {
            IBookRepository repository = new BooksRepository(_invalidFactory);

            bool addResult1 = repository.AddBook(Guid.NewGuid(), "Tom Smith", "Yes or No");
            Assert.AreEqual(true, addResult1);

            bool addResult2 = repository.AddBook(Guid.NewGuid(), "Tom Smith", "Yes or No");
            Assert.AreEqual(false, addResult2);
        }

        //TODO: Tests for book query
    }
}
