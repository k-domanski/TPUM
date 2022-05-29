using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Library.DataServer.Interface;

namespace Library.DataServer.UTest
{
    internal class ValidPersonFactory : IPersonFactory
    {
        public IPerson Create()
        {
            return new Person(Guid.NewGuid(), "Ala", "Ma Kota");
        }
    }

    internal class InvalidPersonFactory : IPersonFactory
    {
        public IPerson Create()
        {
            return new Person(Guid.Empty, "Ala", "Ma Kota");
        }
    }

    [TestClass]
    public class PersonRepositoryTest
    {
        private IPersonFactory _validFactory;
        private IPersonFactory _invalidFactory;
        
        [TestInitialize]
        public void Initialize()
        {
            _validFactory = new ValidPersonFactory();
            _invalidFactory = new InvalidPersonFactory();
        }

        [TestMethod]
        public void AddPerson_ValidPersonFactory_ReturnsTrue()
        {
            IPersonsRepository repository = new PersonsRepository();

            bool addResult1 = repository.AddPerson(_validFactory.Create());
            Assert.AreEqual(true, addResult1);

            bool addResult2 = repository.AddPerson(_validFactory.Create());
            Assert.AreEqual(true, addResult2);
        }

        [TestMethod]
        public void AddPerson_InvalidPersonFactory_ReturnsTrue()
        {
            IPersonsRepository repository = new PersonsRepository();

            bool addResult1 = repository.AddPerson(_invalidFactory.Create());
            Assert.AreEqual(true, addResult1);

            bool addResult2 = repository.AddPerson(_invalidFactory.Create());
            Assert.AreEqual(false, addResult2);
        }
    }
}
