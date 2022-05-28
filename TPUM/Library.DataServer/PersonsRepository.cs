using System;
using System.Collections.Generic;
using Library.DataServer.Interface;

namespace Library.DataServer
{
    public class PersonsRepository : IPersonsRepository
    {
        public event Action<IPerson> onPersonAdded;
        public event Action<IPerson> onPersonRemoved;
        private List<IPerson> _persons;
        private readonly object _dataLock = new object();

        public PersonsRepository()
        {
            _persons = new List<IPerson>();
        }

        public List<IPerson> GetPersons()
        {
            lock (_dataLock)
            {
                return new List<IPerson>(_persons);
            }
        }

        public bool AddPerson(IPerson person)
        {
            lock (_dataLock)
            {
                if (_persons.Contains(person))
                {
                    return false;
                }
                _persons.Add(person);
                onPersonAdded?.Invoke(person);
                return true;
            }
        }

        public bool RemovePerson(IPerson person)
        {
            lock (_dataLock)
            {
                if (_persons.Remove(person))
                {
                    onPersonRemoved?.Invoke(person);
                    return true;
                }
                return false;
            }
        }

        public List<IPerson> FindPersonsByPredicate(Predicate<IPerson> predicate)
        {
            lock (_dataLock)
            {
                return _persons.FindAll(predicate);
            }
        }
    }
}