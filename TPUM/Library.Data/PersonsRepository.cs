using System;
using System.Collections.Generic;
using Library.Data.Interface;

namespace Library.Data
{
    public class PersonsRepository : IPersonsRepository
    {
        private List<IPerson> _persons;

        public PersonsRepository()
        {
            _persons = new List<IPerson>();
        }

        public bool AddPerson(IPerson person)
        {
            if (_persons.Contains(person))
            {
                return false;
            }
            _persons.Add(person);
            return true;
        }

        public bool RemovePerson(IPerson person)
        {
            return _persons.Remove(person);
        }

        public List<IPerson> FindPersonByPredicate(Predicate<IPerson> predicate)
        {
            return _persons.FindAll(predicate);
        }
    }
}