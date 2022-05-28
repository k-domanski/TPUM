using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.DataServer;
using Library.DataServer.Interface;

namespace Library.LogicServer.Factories
{
    public class CreatePersonFactory : IPersonFactory
    {
        private PersonInfo person;

        public CreatePersonFactory(PersonInfo initData)
        {
            person = initData;
        }

        public IPerson Create()
        {
            return new Person(Guid.NewGuid(), person.firstName, person.surname);
        }
    }
}
