using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Data;
using Library.Data.Interface;

namespace Library.Logic.Factories
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
