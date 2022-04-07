using System;
using System.Collections.Generic;

namespace Library.Data.Interface
{
    public interface IPersonsRepository
    {
        bool AddPerson(Guid id, string firstName, string surname);
        bool RemovePerson(Guid id);
        List<IPerson> FindPersonByPredicate(Predicate<IPerson> predicate);
    }
}