using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Library.DataServer.Interface;

namespace Library.DataServer.UTest
{
    internal class ValidBookFactory : IBookFactory
    {
        public IBook Create()
        {
            return new Book(Guid.NewGuid(), "123 456 789 0123", "Ala", "Ma Kota", true);
        }
    }

    internal class InvalidBookFactory : IBookFactory
    {
        public IBook Create()
        {
            return new Book(Guid.Empty, "123 456 789 0123", "Ala", "Ma Kota", true);
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
        public void AddBook_ValidBookFactory_ReturnsTrue()
        {
            IBooksRepository repository = new BooksRepository();

            bool addResult1 = repository.AddBook(_validFactory.Create());
            Assert.AreEqual(true, addResult1);

            bool addResult2 = repository.AddBook(_validFactory.Create());
            Assert.AreEqual(true, addResult2);
        }

        [TestMethod]
        public void AddBook_InvalidBookFactory_ReturnsFalse()
        {
            IBooksRepository repository = new BooksRepository();

            bool addResult1 = repository.AddBook(_invalidFactory.Create());
            Assert.AreEqual(true, addResult1);

            bool addResult2 = repository.AddBook(_invalidFactory.Create());
            Assert.AreEqual(false, addResult2);
        }
    }
}
