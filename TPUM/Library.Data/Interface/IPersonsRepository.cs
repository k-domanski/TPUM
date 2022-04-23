﻿using System;
using System.Collections.Generic;

namespace Library.Data.Interface
{
    public interface IPersonsRepository
    {
        event Action<IPerson> onPersonAdded;
        List<IPerson> GetPersons();
        bool AddPerson(IPerson person);
        bool RemovePerson(IPerson person);
        List<IPerson> FindPersonsByPredicate(Predicate<IPerson> predicate);
    }
}