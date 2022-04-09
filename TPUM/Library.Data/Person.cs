﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}