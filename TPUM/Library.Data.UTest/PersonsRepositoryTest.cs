using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Library.Data.Interface;

namespace Library.Data.UTest
{
    internal class ValidPersonFactory : IPersonFactory
    {
        public IPerson CreatePerson(Guid id, string firstName, string surname)
        {
            return new Person(id, firstName, surname);
        }
    }

    internal class InvalidPersonFactory : IPersonFactory
    {
        public IPerson CreatePerson(Guid id, string firstName, string surname)
        {
            return new Person(Guid.Empty, "Ala", "Kot");
        }
    }

    [TestClass]
    public class PersonsRepositoryTest
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
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructRepository_NullBookFactory_ThrowArgumentNullException()
        {
            IPersonsRepository repository = new PersonsRepository(null);
        }

        //TODO: More tests
    }
}
