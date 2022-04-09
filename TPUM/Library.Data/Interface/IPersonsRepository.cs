using System;
using System.Collections.Generic;

namespace Library.Data.Interface
{
    public interface IPersonsRepository
    {
        bool AddPerson(IPerson person);
        bool RemovePerson(IPerson person);
        List<IPerson> FindPersonByPredicate(Predicate<IPerson> predicate);
    }
}