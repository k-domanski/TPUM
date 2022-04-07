using System;
using System.Collections.Generic;
using Library.Data.Interface;

namespace Library.Data
{
    public class PersonsRepository : IPersonsRepository
    {
        private IPersonFactory _personFactory;
        private List<IPerson> persons;

        public PersonsRepository(IPersonFactory personFactory)
        {
            _personFactory = personFactory;
            if (_personFactory == null)
            {
                throw new ArgumentNullException(nameof(personFactory), "Person Factory can't be null");
            }

            persons = new List<IPerson>();
        }
        public bool AddPerson(Guid id, string firstName, string surname)
        {
            return true;
        }

        public bool RemovePerson(Guid id)
        {
            return persons.RemoveAll(person => person.GetID() == id) > 0;
        }

        public List<IPerson> FindPersonByPredicate(Predicate<IPerson> predicate)
        {
            return persons.FindAll(predicate);
        }
    }
}