using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Library.Data.Interface;

namespace Library.Data.UTest
{
    internal class ValidPersonFactory : IPersonFactory
    {
        public IPerson Create()
        {
            return new Person(Guid.NewGuid(), "Ala", "Kot");
        }
    }

    internal class InvalidPersonFactory : IPersonFactory
    {
        public IPerson Create()
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

        //TODO: More tests
    }
}
