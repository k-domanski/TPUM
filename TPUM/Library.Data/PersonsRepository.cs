﻿using System;
using System.Collections.Generic;
using Library.Data.Interface;

namespace Library.Data
{
    public class PersonsRepository : IPersonsRepository
    {
        public event Action<IPerson> onPersonAdded;
        public event Action<IPerson> onPersonRemoved;
        private List<IPerson> _persons;

        public PersonsRepository()
        {
            _persons = new List<IPerson>();
        }


        public List<IPerson> GetPersons()
        {
            return _persons;
        }

        public bool AddPerson(IPerson person)
        {
            if (_persons.Contains(person))
            {
                return false;
            }
            _persons.Add(person);
            onPersonAdded?.Invoke(person);
            return true;
        }

        public bool RemovePerson(IPerson person)
        {
            if (_persons.Remove(person))
            {
                onPersonRemoved?.Invoke(person);
                return true;
            }
            return false;
        }

        public List<IPerson> FindPersonsByPredicate(Predicate<IPerson> predicate)
        {
            return _persons.FindAll(predicate);
        }
    }
}