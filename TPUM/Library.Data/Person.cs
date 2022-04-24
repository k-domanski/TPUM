using System;
using Library.Data.Interface;

namespace Library.Data
{
    public class Person : IPerson
    {
        private Guid _id;
        private string _firstName;
        private string _surname;

        public Person(Guid id, string firstName, string surname)
        {
            _id = id;
            _firstName = firstName;
            _surname = surname;
        }

        public Guid GetID()
        {
            return _id;
        }

        public string GetFirstName()
        {
            return _firstName;
        }

        public string GetSurname()
        {
            return _surname;
        }

        public bool Equals(IPerson other)
        {
            return GetID() == other.GetID();
        }
    }
}
