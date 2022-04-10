using System;
using System.Collections.Generic;

namespace Library.Data.Interface
{
    public interface IPersonsRepository
    {
        List<IPerson> GetPersons();
        bool AddPerson(IPerson person);
        bool RemovePerson(IPerson person);
        List<IPerson> FindPersonsByPredicate(Predicate<IPerson> predicate);
    }
}